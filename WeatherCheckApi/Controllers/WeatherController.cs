using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Domain.Entities;
using WeatherCheckApi.Domain.Interfaces;
using WeatherCheckApi.Filters;
using WeatherCheckApi.Infrastructure.Data.DB;
using WeatherCheckApi.Requests;
using WeatherCheckApi.Services;

namespace WeatherCheckApi.Controllers
{
    [Route("api/weather")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyAuthenticationFilter))]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherApiRepo _weatherApiRepo;
        private readonly IWeatherRepo _weatherRepo;
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public WeatherController(IWeatherApiRepo weatherApiRepo, DataContext dataContext, IWeatherRepo weatherRepo, IUserRepo userRepo, IMapper mapper)
        {
            _weatherApiRepo = weatherApiRepo;
            _weatherRepo = weatherRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpGet("current")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WeatherApiDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWeatherOfCity([FromQuery] string city)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _weatherApiRepo.GetWeatherByCity(city);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                ModelState.AddModelError("", "Result not found");
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);

            }

            var responseContent = response.Content.ReadAsStringAsync().Result;


            if (responseContent is null) return NotFound();

            var weatherApiResponseDeserialized = WeatherApiService.Deserialize(responseContent);
            //var weatherApiResponseDeserialized = JsonSerializer.Deserialize<WeatherApiResponse>(responseContent);

            //var weatherResponse = WeatherMapper.MapResponseToApiDto(weatherApiResponseDeserialized);
            var weatherResponse = WeatherApiService.MapResponseToApiDto(weatherApiResponseDeserialized);

            return Ok(weatherResponse);

        }

        [HttpPost("current")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Weather))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateWeatherOfCity(CreateWeatherRequest weatherCreate)
        {
            //var weatherModel = WeatherMapper.MapCreateRequestToModel(weather);
            var weatherModel = _mapper.Map<Weather>(weatherCreate);

            var currentUser = HttpContext.Items["User"] as User;

            weatherModel.User = await _userRepo.GetUserAsync(currentUser.Id);

            var isCreated = await _weatherRepo.CreateHistoryAsync(weatherModel);

            if (!isCreated)
            {
                ModelState.AddModelError("", "History creation failed. Internal server error");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return Created("create_success", new { weatherModel.Id });

        }

        [HttpGet("history")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<WeatherDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWeatherHistoryOfCityAsync([FromQuery] string city)
        {
            if (!ModelState.IsValid || city == null) return BadRequest(ModelState);

            var currentUser = HttpContext.Items["User"] as User;

            var weathers = await _weatherRepo.GetHistoryOfCityAsync(city, currentUser.Id);

            // Create a collection of WeatherDto objects by manually mapping the data
            //var weatherDtos = WeatherMapper.MapCollectionOfModelToDto(weathers);
            var weatherDtos = _mapper.Map<List<WeatherDto>>(weathers);

            return Ok(weatherDtos);
        }
    }
}
