using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeatherCheckApi.Application.Constants;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Exceptions;
using WeatherCheckApi.Interfaces;
using WeatherCheckApi.Responses;

namespace WeatherCheckApi.Controllers.Authentications
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IAuthService _authService;
        public LoginController(IAuthService authService)
        {

            _authService = authService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(LoginUserDto user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var (identityUser, success) = await _authService.Login(user);

            if (!success)
            {
                var errors = new Dictionary<string, string[]> {
                    {"Email", new[] { MessageConstants.InvalidEmailAddress } }
                };
                throw new ApiException(HttpStatusCode.BadRequest, MessageConstants.InvalidCredentials, errors);
            }

            var tokenString = _authService.GenerateTokenString(identityUser);

            return Ok(new LoginSuccessResponse(MessageConstants.LoginSuccess, tokenString));
        }
    }
}
