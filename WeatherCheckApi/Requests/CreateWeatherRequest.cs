using System.ComponentModel.DataAnnotations;

namespace WeatherCheckApi.Requests
{
    public record CreateWeatherRequest(
         [Required] string CityName,
         [Required] float TemperatureC,
         float WindSpeedKm,
         int Humidity,
         DateTime RequestDateTime
    );
}
