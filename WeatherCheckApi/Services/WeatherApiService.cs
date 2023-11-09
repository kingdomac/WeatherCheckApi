using System.Text.Json;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Responses;

namespace WeatherCheckApi.Services
{
    public class WeatherApiService
    {
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
