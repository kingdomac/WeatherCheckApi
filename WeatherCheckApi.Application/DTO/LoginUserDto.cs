using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCheckApi.Application.DTO
{
    public class LoginUserDto
    {
        [Required, EmailAddress]
        public required string Email {  get; set; }
        [Required] 
        public required string Password { get; set; }
    }
}
