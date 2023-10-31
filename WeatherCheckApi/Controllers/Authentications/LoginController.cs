using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeatherCheckApi.Application.Constants;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Domain.Interfaces;
using WeatherCheckApi.Requests;
using WeatherCheckApi.Services;
using WeatherCheckApi.Utility.Helpers;

namespace WeatherCheckApi.Controllers.Authentications
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        public LoginController(IUserRepo userRepo, IMapper mapper)
        {
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

            if (user == null) return BadRequest(MessageConstants.InvalidEmailAddress);

            if (!PasswordHelper.Verify(loginRequest.Password, user.Password)) return BadRequest(MessageConstants.InvalidEmailAddress);

            string token = TokenHelper.Generate();

            // Token encoding
            var tokenEncoded = TokenHelper.Encode(token);
            user.Token = tokenEncoded;

            var isUpdated = await _userRepo.UpdateUserAsync(user);

            if (!isUpdated)
            {
                ModelState.AddModelError("", MessageConstants.InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = token;

            return Ok(userDto);
        }
    }
}
