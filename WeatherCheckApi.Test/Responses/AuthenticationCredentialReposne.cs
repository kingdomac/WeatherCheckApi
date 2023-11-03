using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCheckApi.Test.Responses
{
    public class AuthenticationCredentialReposne
    {
        public int Id { get; set; }

        public required string Email { get; set; }

        public required string Token { get; set; }
    }
}
