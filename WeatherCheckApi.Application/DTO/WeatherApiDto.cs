using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCheckApi.Application.DTO
{
    public class WeatherApiDto
    {
        public required string CityName { get; set; }
        public float TemperatureC { get; set; }
        public float WindSpeedKm { get; set; }
        public int Humidity { get; set; }

        public DateTime RequestDateTime { get; set; }
    }
}
