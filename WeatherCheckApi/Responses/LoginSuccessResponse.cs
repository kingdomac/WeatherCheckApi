namespace WeatherCheckApi.Responses
{
    public class LoginSuccessResponse
    {
        public string Title { get; }
        public int Status { get; }
        public string? Message { get; }
        public string? Token { get; }

        public LoginSuccessResponse(string message, string? token)
        {
            Status = StatusCodes.Status200OK;
            Title = "Success";
            Message = message;
            Token = token;
        }
    }
}
