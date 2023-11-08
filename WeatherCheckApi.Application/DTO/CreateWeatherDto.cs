using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCheckApi.Application.DTO
{
    public class CreateWeatherDto
    {
        [Required]
        public required string CityName { get; set; }
        [Required] 
        public float TemperatureC { get; set; }
        public float WindSpeedKm { get; set; }
        public int Humidity { get; set; }
        public DateTime RequestDateTime { get; set; }
    }
}
