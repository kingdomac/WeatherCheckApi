using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Domain.Entities;
using WeatherCheckApi.Interfaces;

namespace WeatherCheckApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<bool> Register(LoginUserDto user)
        {
            
            var identityUSer = new ApplicationUser
            {
                UserName = user.Email,
                Email = user.Email
            };

            var result = await _userManager.CreateAsync(identityUSer, user.Password);

            return result.Succeeded;
        }

        public async Task<(ApplicationUser identityUser, bool success)> Login(LoginUserDto user)
        {

            var identityUser = await _userManager.FindByEmailAsync(user.Email);
            if (identityUser is null)
            {
                return (new ApplicationUser(), false);
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(identityUser, user.Password);
            if (!isPasswordValid)
            {
                return (new ApplicationUser(), false);
            }

            return (identityUser, isPasswordValid);
        }

        public string GenerateTokenString(ApplicationUser user)
        {
            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

            SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred
                );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }

        public async Task<bool> CheckIfUserAlreadyxist(LoginUserDto user)
        {
            var userDb =  await _userManager.FindByEmailAsync(user.Email);

            if (userDb is not null) return true;

            return false;
            
        }
    }
}
