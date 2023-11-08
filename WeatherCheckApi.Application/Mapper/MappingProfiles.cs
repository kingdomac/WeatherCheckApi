using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Domain.Entities;

namespace WeatherCheckApi.Application.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Weather, WeatherDto>().ReverseMap();
            CreateMap<CreateWeatherDto, Weather>().ReverseMap();

        }
    }
}
