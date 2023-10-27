using AutoMapper;
using WeatherCheckApi.Domain.Entities;
using WeatherCheckApi.Requests;

namespace WeatherCheckApi.Mapper
{
    public class PresentationMappingProfile : Profile
    {
        public PresentationMappingProfile()
        {
            CreateMap<CreateWeatherRequest, Weather>();
        }
    }
}
