using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCheckApi.Domain.Entities;

namespace WeatherCheckApi.Infrastructure.Data.DB
{
    public class DataContext : DbContext
    {
        //private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
           
        }

        public DbSet<Weather> Weathers { get; set; }
        //public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(_configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Weather>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
