using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCheckApi.Application.DTO
{
    public class WeatherDto
    {
        public int Id { get; set; }
        public required string CityName { get; set; }
        public float TemperatureCelsius { get; set; }
        public float WindSpeedKph { get; set; }
        public int Humidity { get; set; }
        public DateTime RequestDateTime { get; set; }
    }
}
