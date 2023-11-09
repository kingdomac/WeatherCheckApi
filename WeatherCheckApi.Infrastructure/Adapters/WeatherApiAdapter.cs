using WeatherCheckApi.Domain.Interfaces;

namespace WeatherCheckApi.Infrastructure.Adapters
{
    public class WeatherApiAdapter : IWeatherApi
    {
        private readonly IWeatherApiProvider _weatherApiProvider;

        public WeatherApiAdapter(IWeatherApiProvider weatherApiProvider)
        {
            _weatherApiProvider = weatherApiProvider ;
        }

        public async Task<HttpResponseMessage> GetWeatherByCity(string city)
        {
            return await _weatherApiProvider.GetWeatherByCity(city);
        }
    }
}
