using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherCheckApi.Requests;
using WeatherCheckApi.Test.Responses;

namespace WeatherCheckApi.Test.Common
{
    public class Shared
    {
        public static readonly string BaseAddress = "https://localhost:7061";
        public static string? _token = "9dee746e3c814052bc3840dfbd77c8c4";

        private readonly HttpClient _client;

        public Shared()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(Shared.BaseAddress) // Update with your API's base URL
            };
        }

        public async Task<AuthenticationCredentialReposne?> Login(string email, string password)
        {
            var loginRequest = new LoginRequest(email, password);

            var json = System.Text.Json.JsonSerializer.Serialize(loginRequest);
            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _client.PostAsync("/api/login", content);
            var contentStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var contentDeserialized = await JsonSerializer.DeserializeAsync<AuthenticationCredentialReposne>(contentStream, options);

            return contentDeserialized;
        }
    }
}
