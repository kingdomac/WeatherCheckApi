
namespace WeatherCheckApi.Domain.Interfaces
{
    public interface IWeatherApi
    {
        public Task<HttpResponseMessage> GetWeatherByCity(string city);
    }
}
