using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCheckApi.Application.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public string? Token { get; set; }
    }
}
