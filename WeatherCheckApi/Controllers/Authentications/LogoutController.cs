using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeatherCheckApi.Domain.Entities;
using WeatherCheckApi.Domain.Interfaces;
using WeatherCheckApi.Filters;

namespace WeatherCheckApi.Controllers.Authentications
{
    [Route("api/logout")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyAuthenticationFilter))]
    public class LogoutController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public LogoutController(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Logout()
        {

            var user = HttpContext.Items["User"];
            if (user == null) return BadRequest();

            var userModel = _mapper.Map<User>(user);

            var isTokenDeleted = await _userRepo.DeleteUserTokenAsync(userModel);

            if (!isTokenDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();

        }
    }
}
