using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using WeatherCheckApi.Application.Constants;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Domain.Entities;
using WeatherCheckApi.Domain.Interfaces;
using WeatherCheckApi.Exceptions;
using WeatherCheckApi.Infrastructure.Data.DB;
using WeatherCheckApi.Services;

namespace WeatherCheckApi.Controllers
{
    [Route("api/weather")]
    [ApiController]
    [Authorize]
    //[ServiceFilter(typeof(ApiKeyAuthenticationFilter))]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepo _weatherRepo;
        private readonly IMapper _mapper;
        private readonly IWeatherApi _weatherApi;
        private readonly WeatherApiService _weatherApiService;
        private readonly UserManager<IdentityUser> _userManager;

        public WeatherController(DataContext dataContext,
            IWeatherRepo weatherRepo,
            IMapper mapper,
            IWeatherApi weatherApi,
            WeatherApiService weatherApiService
,
            UserManager<IdentityUser> userManager)
        {
            _weatherRepo = weatherRepo;
            _mapper = mapper;
            _weatherApi = weatherApi;
            _weatherApiService = weatherApiService;
            _userManager = userManager;
        }

        [HttpGet("current")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WeatherApiDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetWeatherOfCity([FromQuery] string city)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _weatherApi.GetWeatherByCity(city);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", MessageConstants.ResultNotFound);
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);

            }

            var responseContent = response.Content.ReadAsStringAsync().Result;


            if (responseContent is null) return NotFound();

            var weatherApiResponseDeserialized = _weatherApiService.Deserialize(responseContent);

            var weatherResponse = _weatherApiService.MapResponseToApiDto(weatherApiResponseDeserialized);

            return Ok(weatherResponse);

        }

        [HttpPost("current")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WeatherDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> CreateWeatherOfCity(CreateWeatherDto weatherCreate)
        {
            
            var weatherModel = _mapper.Map<Weather>(weatherCreate);
            
            var identityUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var identityUser = await _userManager.FindByIdAsync(identityUserId ?? "");

            weatherModel.User = identityUser ?? new IdentityUser();

            var isCreated = await _weatherRepo.CreateHistoryAsync(weatherModel);

            if (!isCreated)
            {
                var errors = new Dictionary<string, string[]> {
                    {"Error", new[] { MessageConstants.InvalidEmailAddress } }
                };
                throw new ApiException(HttpStatusCode.InternalServerError, MessageConstants.CreationFailed, errors);
                
            }

            var weatherDto = _mapper.Map<WeatherDto>(weatherModel);

            return Created("create_success", weatherDto);

        }

        [HttpGet("history")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<WeatherDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetWeatherHistoryOfCityAsync([FromQuery] string city)
        {
            if (!ModelState.IsValid || city == null) return BadRequest(ModelState);

            var identityUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

            var weathers = await _weatherRepo.GetHistoryOfCityAsync(city, identityUserId);

            // Create a collection of WeatherDto objects by mapping the data
            var weatherDtos = _mapper.Map<List<WeatherDto>>(weathers);

            return Ok(weatherDtos);
        }
    }
}
