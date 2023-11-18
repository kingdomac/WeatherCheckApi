using WeatherCheckApi.Application.DTO;

namespace WeatherCheckApi.Interfaces
{
    public interface IAuthIndentityServerServiceProvider
    {
        public Task<bool> Register(RegisterUserDto user);
        public Task<string> Login(LoginUserDto loginUserDto);
    }
}
