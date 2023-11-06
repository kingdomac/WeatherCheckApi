using Microsoft.AspNetCore.Identity;
using WeatherCheckApi.Requests;

namespace WeatherCheckApi.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(LoginRequest user);
        Task<(IdentityUser identityUser, bool success)> Login(LoginRequest user);
        string GenerateTokenString(IdentityUser user);
    }
}
