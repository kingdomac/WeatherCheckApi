using System.Net;
using System.Text;
using System.Text.Json;
using WeatherCheckApi.Application.Constants;
using WeatherCheckApi.Application.DTO;
using WeatherCheckApi.Responses;
using WeatherCheckApi.Test.Common;
using WeatherCheckApi.Test.Responses;

namespace WeatherCheckApi.Test.Weather
{
    public class WeatherTest
    {
        //private readonly HttpClient _client;
        //private readonly string? _token = "9dee746e3c814052bc3840dfbd77c8c4";
        //private readonly Shared _shared;
        //public WeatherTest()
        //{
        //    _client = new HttpClient
        //    {
        //        BaseAddress = new Uri("https://localhost:7061") // Update with your API's base URL
        //    };
        //    _shared = new Shared();
        //}

        //[Fact]
        //public async void GetWeatherOfCity_ShouldReturnOK_WhenAuthUserAndValidCity()
        //{
        //    var authUser = await _shared.Login("user@mail.com", "password123");
        //    var authToken = authUser.Token;
        //    //var authToken = _token;

        //    _client.DefaultRequestHeaders.Add(AuthConstants.ApiKeyHeaderName, authToken);


        //    var response = await _client.GetAsync("/api/weather/current?city=Beirut");
        //    var contentStream = await response.Content.ReadAsStreamAsync();

        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };

        //    var contentDeserialized = await JsonSerializer.DeserializeAsync<WeatherApiDto>(contentStream, options);


        //    response.EnsureSuccessStatusCode();
        //    Assert.Equal("Beirut", contentDeserialized.CityName);
        //}

        //[Fact]
        //public async void GetWeatherOfCity_ShouldReturnUnAuthorized_WhenMissingToken()
        //{
        //    //var authUser = await Login("user@mail.com", "password123");
        //    var authToken = "";

        //    _client.DefaultRequestHeaders.Add(AuthConstants.ApiKeyHeaderName, authToken);


        //    var response = await _client.GetAsync("/api/weather/current?city=Beirut");
        //    var contentStream = await response.Content.ReadAsStreamAsync();

        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };

        //    var contentDeserialized = await JsonSerializer.DeserializeAsync<UnauthorizationResponse>(contentStream, options);

        //    Assert.Equal((int)HttpStatusCode.Unauthorized, contentDeserialized?.Status);
        //    Assert.NotNull(contentDeserialized?.Error);
        //    Assert.Equal(MessageConstants.ApiKeyMissing, contentDeserialized?.Error);
        //}

        //[Fact]
        //public async void GetWeatherOfCity_ShouldReturnUnAuthorized_WhenIvalidToken()
        //{
        //    //var authUser = await Login("user@mail.com", "password123");
        //    var authToken = "123we1ewe21eqw";

        //    _client.DefaultRequestHeaders.Add(AuthConstants.ApiKeyHeaderName, authToken);


        //    var response = await _client.GetAsync("/api/weather/current?city=Beirut");
        //    var contentStream = await response.Content.ReadAsStreamAsync();

        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };

        //    var contentDeserialized = await JsonSerializer.DeserializeAsync<UnauthorizationResponse>(contentStream, options);

        //    Assert.Equal((int)HttpStatusCode.Unauthorized, contentDeserialized?.Status);
        //    Assert.NotNull(contentDeserialized?.Error);
        //    Assert.Equal(MessageConstants.InvalidApiKey, contentDeserialized?.Error);
        //}

        //[Fact]
        //public async void GetWeatherOfCity_ShouldReturnBadRequest_WhenAuthUserAndEmptyCity()
        //{
        //    var authUser = await _shared.Login("user@mail.com", "password123");
        //    var authToken = authUser.Token;
        //    //var authToken = _token;

        //    _client.DefaultRequestHeaders.Add(AuthConstants.ApiKeyHeaderName, authToken);


        //    var response = await _client.GetAsync("/api/weather/current?city=");
        //    var contentStream = await response.Content.ReadAsStreamAsync();

        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };
        //    var errorContent = await JsonSerializer.DeserializeAsync<ValidationErrorResponse>(contentStream, options);

        //    Assert.NotNull(errorContent);
        //    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        //    Assert.Equal("The city field is required.", errorContent.Errors["city"][0]);
        //}

        //[Fact]
        //public async void GetWeatherOfCity_ShouldReturnBadRequest_WhenUnauthUser()
        //{

        //    var response = await _client.GetAsync("/api/weather/current?city=Beirut");
        //    var contentStream = await response.Content.ReadAsStreamAsync();

        //    Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        //}

        //[Fact]
        //public async void CreateWeatherOfCity_ShouldReturnOK_WhenAuthUserAndValidPayload()
        //{
        //    var authUser = await _shared.Login("user@mail.com", "password123");
        //    var authToken = authUser.Token;
        //    //var authToken = _token;

        //    _client.DefaultRequestHeaders.Add(AuthConstants.ApiKeyHeaderName, authToken);

        //    CreateWeatherRequest createWeatherRequest = new CreateWeatherRequest(
        //        CityName: "Texas City",
        //        Humidity: 23,
        //        TemperatureC: 10,
        //        RequestDateTime: DateTime.UtcNow,
        //        WindSpeedKm: 82
        //    );

        //    var json = System.Text.Json.JsonSerializer.Serialize(createWeatherRequest);
        //    var content = new StringContent(
        //        json,
        //        Encoding.UTF8,
        //        "application/json"
        //    );

        //    var response = await _client.PostAsync("/api/weather/current", content);
        //    var contentStream = await response.Content.ReadAsStreamAsync();

        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };

        //    var contentDeserialized = await JsonSerializer.DeserializeAsync<WeatherApiDto>(contentStream, options);

        //    Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        //    Assert.Equal("Texas City", contentDeserialized.CityName);
        //}

        //[Fact]
        //public async void CreateWeatherOfCity_ShouldReturnOK_WhenAuthUserAndEmtpyCity()
        //{
        //    var authUser = await _shared.Login("user@mail.com", "password123");
        //    var authToken = authUser.Token;
        //    //var authToken = _token;

        //    _client.DefaultRequestHeaders.Add(AuthConstants.ApiKeyHeaderName, authToken);

        //    CreateWeatherRequest createWeatherRequest = new CreateWeatherRequest(
        //        CityName: "",
        //        Humidity: 23,
        //        TemperatureC: 10,
        //        RequestDateTime: DateTime.UtcNow,
        //        WindSpeedKm: 82
        //    );

        //    var json = System.Text.Json.JsonSerializer.Serialize(createWeatherRequest);
        //    var content = new StringContent(
        //        json,
        //        Encoding.UTF8,
        //        "application/json"
        //    );

        //    var response = await _client.PostAsync("/api/weather/current", content);
        //    var contentStream = await response.Content.ReadAsStreamAsync();

        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };

        //    var contentDeserialized = await JsonSerializer.DeserializeAsync<ValidationErrorResponse>(contentStream, options);

        //    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        //    Assert.Equal("The CityName field is required.", contentDeserialized.Errors["CityName"][0]);
        //}

        //[Fact]
        //public async void GetWeatherHistoryOfCity_ShouldReturnOK_WhenAuthUserAndValidCity()
        //{
        //    var authUser = await _shared.Login("user@mail.com", "password123");
        //    var authToken = authUser.Token;
        //    //var authToken = _token;

        //    _client.DefaultRequestHeaders.Add(AuthConstants.ApiKeyHeaderName, authToken);


        //    var response = await _client.GetAsync("/api/weather/history?city=Beirut");
        //    var contentStream = await response.Content.ReadAsStreamAsync();

        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };

        //    var contentDeserialized = await JsonSerializer.DeserializeAsync<List<WeatherApiDto>>(contentStream, options);

        //    response.EnsureSuccessStatusCode();
        //    ////Assert.True(contentDeserialized?.Count > 0);
        //    //Assert.Equal("Beirut", contentDeserialized[0].CityName);
        //}

    }
}
