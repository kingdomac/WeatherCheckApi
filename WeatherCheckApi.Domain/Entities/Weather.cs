using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCheckApi.Domain.Entities
{
    public class Weather
    {
        public int Id { get; set; }
        public required string CityName { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public float WindSpeedKm { get; set; }

        public int Humidity { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public float TemperatureC { get; set; }

        public DateTime RequestDateTime { get; set; }

        public DateTime CreatedAt;

        public User? User { get; set; }
    }
}
