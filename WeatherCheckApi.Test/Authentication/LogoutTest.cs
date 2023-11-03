using WeatherCheckApi.Test.Common;

namespace WeatherCheckApi.Test.Authentication
{
    public class LogoutTest
    {
        private readonly HttpClient _client;
        private readonly string? _token = "fc78bf14287c40bb805316c8433670a5";

        public LogoutTest()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(Shared.BaseAddress) // Update with your API's base URL
            };
        }

        //[Fact]
        //public async Task Logout_ShouldReturnOk_WhenValidCredentials()
        //{
        //    var shared = new Shared();
        //    var authUser = await shared.Login("user@mail.com", "password123");
        //    var authToken = authUser.Token;
        //    //var authToken = _token;
        //    _client.DefaultRequestHeaders.Add(AuthConstants.ApiKeyHeaderName, authToken);
        //    var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
        //    var response = await _client.PostAsync("/api/logout", content);

        //    Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        //}
    }
}
