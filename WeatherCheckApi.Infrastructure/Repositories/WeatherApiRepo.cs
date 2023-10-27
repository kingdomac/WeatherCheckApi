using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCheckApi.Domain.Interfaces;

namespace WeatherCheckApi.Infrastructure.Repositories
{
    public class WeatherApiRepo : IWeatherApiRepo
    {
        private readonly string _apiKey = "9086fdede1e048cd8c5180347232510";


        public async Task<HttpResponseMessage> GetWeatherByCity(string city)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json");

            var response = await httpClient.GetAsync($"?key={_apiKey}&q={city}");

            return response;
        }
    }
}
