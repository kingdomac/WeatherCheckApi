using Microsoft.AspNetCore.Identity;
using WeatherCheckApi.Application.DTO;

namespace WeatherCheckApi.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(LoginUserDto user);
        Task<(IdentityUser identityUser, bool success)> Login(LoginUserDto user);
        string GenerateTokenString(IdentityUser user);
    }
}
