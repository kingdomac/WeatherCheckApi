using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeatherCheckApi.Application.Constants;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Exceptions;
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

            if(await _authService.CheckIfUserAlreadyxist(user))
            {
                return BadRequest(new {error = MessageConstants.UserAlreadyRegistered});
            }

            var isRegistered = await _authService.Register(user);

            if (!isRegistered) return BadRequest();

            return Ok(new SuccessResponse(MessageConstants.RegistrationSuccess));
        }
    }
}
