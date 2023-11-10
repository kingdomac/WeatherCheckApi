using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Domain.Entities;

namespace WeatherCheckApi.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(LoginUserDto user);
        Task<(ApplicationUser identityUser, bool success)> Login(LoginUserDto user);
        string GenerateTokenString(ApplicationUser user);
    }
}
