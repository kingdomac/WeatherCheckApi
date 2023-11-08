using Microsoft.AspNetCore.Mvc;
using WeatherCheckApi.Application.Constants;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Interfaces;
using WeatherCheckApi.Responses;

namespace WeatherCheckApi.Controllers.Authentications
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAuthService _authService;

        public RegisterController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginUserDto user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var isRegistered = await _authService.Register(user);

            if (!isRegistered) return BadRequest();

            return Ok(new SuccessResponse(MessageConstants.RegistrationSuccess));
        }
    }
}
