using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Domain.Entities;

namespace WeatherCheckApi.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterUserDto user);
        Task<(ApplicationUser identityUser, bool success)> Login(LoginUserDto user);
        string GenerateTokenString(ApplicationUser user);
        Task<bool> CheckIfUserAlreadyxist(RegisterUserDto user);
    }
}
