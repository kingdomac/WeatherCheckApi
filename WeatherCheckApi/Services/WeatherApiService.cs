using System.Text.Json;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Responses;

namespace WeatherCheckApi.Services
{
    public class WeatherApiService
    {
        public static WeatherApiDto MapResponseToApiDto(WeatherApiResponse response)
        {
            var weatherResponse = new WeatherApiDto
            {
                CityName = response.location.CityName,
                TemperatureCelsius = response.current.TemperatureCelsius,
                WindSpeedKph = response.current.WindSpeedKph,
                Humidity = response.current.Humidity,
                RequestDateTime = DateTime.Now
            };

            return weatherResponse;

        }

        public static WeatherApiResponse Deserialize(string stringResponse)
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
