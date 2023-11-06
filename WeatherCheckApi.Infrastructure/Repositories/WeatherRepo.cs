using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCheckApi.Domain.Entities;
using WeatherCheckApi.Domain.Interfaces;
using WeatherCheckApi.Infrastructure.Data.DB;

namespace WeatherCheckApi.Infrastructure.Repositories
{
    public class WeatherRepo : IWeatherRepo
    {
        private readonly DataContext _dataContext;

        public WeatherRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> CreateHistoryAsync(Weather weather)
        {
            _dataContext.Weathers.Add(weather);
            return await saveAsync();
        }

        public async Task<ICollection<Weather>> GetHistoryOfCityAsync(string city, string userId)
        {
            return await _dataContext.Weathers
                .Where(w => w.CityName.Trim().ToLower().Contains(city.Trim().ToLower()) && w.User.Id == userId)
                .OrderByDescending(w => w.RequestDateTime)
                .ToListAsync();
        }

        public async Task<bool> saveAsync()
        {
            var saved = await _dataContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
