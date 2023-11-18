using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Domain.Entities;

namespace WeatherCheckApi.Interfaces
{
    public interface IAuthServiceAdapter
    {
        public Task<bool> Register(RegisterUserDto user);
        public Task<string> Login(LoginUserDto loginUserDto);
    }
}
