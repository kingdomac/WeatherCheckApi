using System.Net;
using System.Text;
using System.Text.Json;
using WeatherCheckApi.Application.Constants;
using WeatherCheckApi.Test.Responses;

namespace WeatherCheckApi.Test.Authentication
{
    public class LoginTest
    {
        //private readonly HttpClient _client;

        //public LoginTest()
        //{
        //    _client = new HttpClient
        //    {
        //        BaseAddress = new Uri("https://localhost:7061") // Update with your API's base URL
        //    };
        //}

        //[Fact]
        //public async void Login_ShouldReturnBadRequest_WhenEmptyEmail()
        //{
        //    var loginRequest = new LoginRequest("", "password123");

        //    var json = System.Text.Json.JsonSerializer.Serialize(loginRequest);
        //    var content = new StringContent(
        //        json,
        //        Encoding.UTF8,
        //        "application/json"
        //    );

        //    var response = await _client.PostAsync("/api/login", content);

        //    var contentStream = await response.Content.ReadAsStreamAsync();

        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };
        //    var errorContent = await JsonSerializer.DeserializeAsync<ValidationErrorResponse>(contentStream, options);

        //    // Assert that the response status code is Bad Request (HTTP 400)
        //    Assert.NotNull(errorContent);
        //    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode); ;
        //    Assert.True(errorContent.Errors?.ContainsKey("Email"));
        //    Assert.Contains("The Email field is required.", errorContent.Errors["Email"][0]);
        //    Assert.Contains("The Email field is not a valid e-mail address.", errorContent.Errors["Email"][1]);
        //}

        //[Fact]
        //public async void Login_ShouldReturnBadRequest_WhenInvalidEmail()
        //{
        //    var loginRequest = new LoginRequest("tytyt", "password123");

        //    var json = System.Text.Json.JsonSerializer.Serialize(loginRequest);
        //    var content = new StringContent(
        //        json,
        //        Encoding.UTF8,
        //        "application/json"
        //    );

        //    var response = await _client.PostAsync("/api/login", content);

        //    var contentStream = await response.Content.ReadAsStreamAsync();

        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };
        //    var errorContent = await JsonSerializer.DeserializeAsync<ValidationErrorResponse>(contentStream, options);

        //    // Assert that the response status code is Bad Request (HTTP 400)
        //    Assert.NotNull(errorContent);
        //    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode); ;
        //    Assert.True(errorContent.Errors?.ContainsKey("Email"));
        //    Assert.Contains("The Email field is not a valid e-mail address.", errorContent.Errors["Email"][0]);
        //}

        //[Fact]
        //public async void Login_ShouldReturnBadRequest_WhenEmptyPassword()
        //{
        //    var loginRequest = new LoginRequest("user2@mail.com", "");

        //    var json = System.Text.Json.JsonSerializer.Serialize(loginRequest);
        //    var content = new StringContent(
        //        json,
        //        Encoding.UTF8,
        //        "application/json"
        //    );

        //    var response = await _client.PostAsync("/api/login", content);

        //    var contentStream = await response.Content.ReadAsStreamAsync();

        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };
        //    var errorContent = await JsonSerializer.DeserializeAsync<ValidationErrorResponse>(contentStream, options);

        //    // Assert that the response status code is Bad Request (HTTP 400)
        //    Assert.NotNull(errorContent);
        //    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        //    Assert.True(errorContent.Errors?.ContainsKey("Password"));
        //    Assert.Contains("The Password field is required.", errorContent.Errors["Password"][0]);
        //}

        //[Fact]
        //public async void Login_ShouldReturnBadRequest_WhenInvalidCredentials()
        //{
        //    var loginRequest = new LoginRequest("usersda@mail.com", "sadwerwe23");

        //    var json = System.Text.Json.JsonSerializer.Serialize(loginRequest);
        //    var content = new StringContent(
        //        json,
        //        Encoding.UTF8,
        //        "application/json"
        //    );

        //    var response = await _client.PostAsync("/api/login", content);

        //    var contentStream = await response.Content.ReadAsStreamAsync();

        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };
        //    var errorContent = await JsonSerializer.DeserializeAsync<ValidationErrorResponse>(contentStream, options);

        //    // Assert that the response status code is Bad Request (HTTP 400)
        //    Assert.NotNull(errorContent);
        //    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        //    Assert.Contains(MessageConstants.InvalidEmailAddress, errorContent.Errors["Email"][0]);
        //}

        //[Fact]
        //public async void Login_ShouldReturnSuccess_WhenValidCredentials()
        //{
        //    var loginRequest = new LoginRequest("user2@mail.com", "password123");

        //    var json = System.Text.Json.JsonSerializer.Serialize(loginRequest);
        //    var content = new StringContent(
        //        json,
        //        Encoding.UTF8,
        //        "application/json"
        //    );

        //    var response = await _client.PostAsync("/api/login", content);
        //    var contentStream = await response.Content.ReadAsStreamAsync();

        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    };
        //    var contentDeserialized = await JsonSerializer.DeserializeAsync<AuthenticationCredentialReposne>(contentStream, options);

        //    response.EnsureSuccessStatusCode();
        //    Assert.NotNull(contentDeserialized.Token);


        //}

    }
}
