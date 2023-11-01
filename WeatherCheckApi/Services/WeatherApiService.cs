using System.Text.Json;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Responses;

namespace WeatherCheckApi.Services
{
    public class WeatherApiService
    {
        private readonly string _apiKey = "9086fdede1e048cd8c5180347232510";

        public async Task<HttpResponseMessage> GetWeatherByCity(string city)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json");

            var response = await httpClient.GetAsync($"?key={_apiKey}&q={city}");

            return response;
        }

        public  WeatherApiDto MapResponseToApiDto(WeatherApiResponse response)
        {
            var weatherResponse = new WeatherApiDto
            {
                CityName = response.location.CityName,
                TemperatureC = response.current.TemperatureC,
                WindSpeedKm = response.current.WindSpeedKm,
                Humidity = response.current.Humidity,
                RequestDateTime = DateTime.Now
            };

            return weatherResponse;

        }

        public  WeatherApiResponse Deserialize(string stringResponse)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var weatherApiResponse = JsonSerializer.Deserialize<WeatherApiResponse>(stringResponse, options);

            return weatherApiResponse is not null ? weatherApiResponse : new WeatherApiResponse();
        }
    }
}
