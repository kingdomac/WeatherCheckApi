using System.ComponentModel.DataAnnotations;

namespace WeatherCheckApi.Requests
{
    public record CreateWeatherRequest(
         [Required] string CityName,
         [Required] float TemperatureCelsius,
         float WindSpeedKph,
         int Humidity,
         DateTime RequestDateTime
    );
}
