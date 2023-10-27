using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCheckApi.Domain.Entities;
using WeatherCheckApi.Domain.Interfaces;
using WeatherCheckApi.Infrastructure.Data.DB;
using WeatherCheckApi.Utility.Helpers;

namespace WeatherCheckApi.Infrastructure.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext _dataContext;

        public UserRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dataContext.Users.Where(u => u.Email == email).FirstOrDefaultAsync();

        }

        public async Task<User> GetUserByTokenAsync(string token)
        {
            var encodedToken = TokenHelper.Encode(token);

            return await _dataContext.Users.Where(u => u.Token == encodedToken).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _dataContext.Users.Update(user);
            return await Save();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync();
            return saved > 0;

        }
    }
}
