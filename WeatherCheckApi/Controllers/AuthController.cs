using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Domain.Interfaces;
using WeatherCheckApi.Infrastructure.Data.DB;
using WeatherCheckApi.Requests;
using WeatherCheckApi.Utility.Helpers;

namespace WeatherCheckApi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        public AuthController(DataContext dataContext, IUserRepo userRepo, IMapper mapper)
        {
            _dataContext = dataContext;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userRepo.GetUserByEmailAsync(loginRequest.Email);

            if (user == null) return BadRequest("Invalid email/password");

            if (!PasswordHelper.Verify(loginRequest.Password, user.Password)) return BadRequest("Invalid email/password");

            // TODO Generate Token
            string token = TokenHelper.Generate();

            // Token encoding
            var tokenEncoded = TokenHelper.Encode(token);
            user.Token = tokenEncoded;

            var isUpdated = await _userRepo.UpdateUserAsync(user);

            if (!isUpdated)
            {
                ModelState.AddModelError("", "Internal server error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = token;

            return Ok(userDto);
        }
    }
}
