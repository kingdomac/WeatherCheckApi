namespace WeatherCheckApi.Responses
{
    public record UnauthorizationResponse
    {
        public string Title { get; }
        public int Status { get;}
        public string? Error { get; }

        public UnauthorizationResponse(string error)
        {
            Status = StatusCodes.Status401Unauthorized;
            Title = "Unauthorized";
            Error = error;
        }
    }
}
