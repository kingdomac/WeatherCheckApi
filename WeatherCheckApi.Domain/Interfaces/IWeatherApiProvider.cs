using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCheckApi.Domain.Interfaces
{
    public interface IWeatherApiProvider
    {
        public Task<HttpResponseMessage> GetWeatherByCity(string city);
    }
}
