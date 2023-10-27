using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCheckApi.Domain.Entities;

namespace WeatherCheckApi.Domain.Interfaces
{
    public interface IWeatherRepo
    {
        Task<ICollection<Weather>> GetHistoryOfCityAsync(string city, int userId);
        Task<bool> CreateHistoryAsync(Weather weather);
        Task<bool> saveAsync();
    }
}
