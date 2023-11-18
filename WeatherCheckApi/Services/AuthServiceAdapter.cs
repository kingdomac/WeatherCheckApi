using System.Net.Http;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Interfaces;

namespace WeatherCheckApi.Services
{
    public class AuthServiceAdapter : IAuthServiceAdapter
    {
       private readonly IAuthIndentityServerServiceProvider _serviceProvider;

        public AuthServiceAdapter(IAuthIndentityServerServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<bool> Register(RegisterUserDto user)
        {
            bool isRegistered = await _serviceProvider.Register(user);

            if(!isRegistered) return false;

            return true;
        }

        public async Task<string> Login(LoginUserDto loginUserDto)
        {
            string loginResult = await _serviceProvider.Login(loginUserDto);

            return loginResult;
        }
    }
}
