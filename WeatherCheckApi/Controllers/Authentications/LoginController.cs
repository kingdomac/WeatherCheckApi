using AutoMapper;
using IdentityModel.Client;
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

        private readonly IAuthServiceAdapter _authService;
        public LoginController(IAuthServiceAdapter authService)
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

            string token = await _authService.Login(user);

            if (string.IsNullOrEmpty(token))
            {
                var errors = new Dictionary<string, string[]> {
                        {"Email", new[] { MessageConstants.InvalidEmailAddress } }
                    };
                throw new ApiException(HttpStatusCode.BadRequest, MessageConstants.InvalidCredentials, errors);
            };

            return Ok(new LoginSuccessResponse(MessageConstants.LoginSuccess, token));

        }
    }
}
