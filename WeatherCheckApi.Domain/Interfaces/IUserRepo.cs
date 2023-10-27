using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCheckApi.Domain.Entities;

namespace WeatherCheckApi.Domain.Interfaces
{
    public interface IUserRepo
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserAsync(int id);
        Task<User> GetUserByTokenAsync(string Token);

        Task<bool> UpdateUserAsync(User user);

        Task<bool> Save();
    }
}
