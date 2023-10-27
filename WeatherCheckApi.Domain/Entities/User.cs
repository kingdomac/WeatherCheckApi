using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCheckApi.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }

        public ICollection<Weather>? Weathers { get; set; }
    }
}
