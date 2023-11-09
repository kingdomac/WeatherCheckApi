using WeatherCheckApi.Domain.Interfaces;

namespace WeatherCheckApi.Infrastructure.Adapters
{
    public class WeatherApiProvider : IWeatherApiProvider
    {
        private readonly string _apiKey = "9086fdede1e048cd8c5180347232510";
        private readonly HttpClient _httpClient;

        public WeatherApiProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetWeatherByCity(string city)
        {
            _httpClient.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json");

            var response = await _httpClient.GetAsync($"?key={_apiKey}&q={city}");

            return response;
        }
    }
}
