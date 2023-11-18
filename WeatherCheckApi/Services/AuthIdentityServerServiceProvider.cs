using IdentityModel.Client;
using System.Net.Http;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Interfaces;

namespace WeatherCheckApi.Services
{
    public class AuthIdentityServerServiceProvider : IAuthIndentityServerServiceProvider
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AuthIdentityServerServiceProvider(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<bool> Register(RegisterUserDto user)
        {
            var registrationReposne = await _httpClient.PostAsJsonAsync($"{_configuration.GetSection("IdentityServer:Authority").Value}/api/account/register", user);

            if (!registrationReposne.IsSuccessStatusCode) return false;

            return true;
        }

        public async Task<string> Login(LoginUserDto loginUserDto)
        {
            var disco = await _httpClient.GetDiscoveryDocumentAsync(_configuration.GetSection("IdentityServer:Authority").Value); // IdentityServer4 URL

            var tokenResponse = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = _configuration.GetSection("IdentityServer:ClientId").Value,
                ClientSecret = _configuration.GetSection("IdentityServer:ClientSecrets").Value,
                UserName = loginUserDto.Email,
                Password = loginUserDto.Password,
                Scope = "WeatherCheckApi"
            });

            if (tokenResponse.IsError)
            {
                // Handle token request error
                return string.Empty;
            }

            var accessToken = tokenResponse.AccessToken;

            // Use the accessToken to make requests to your API
            //_httpClient.SetBearerToken(accessToken);

            return accessToken;
        }
    }
}
