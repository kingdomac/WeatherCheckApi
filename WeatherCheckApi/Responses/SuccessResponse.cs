namespace WeatherCheckApi.Responses
{
    public class SuccessResponse
    {
        public string Title { get; }
        public int Status { get; }
        public string? Message { get; }

        public SuccessResponse(string message)
        {
            Status = StatusCodes.Status200OK;
            Title = "Success";
            Message = message;
        }
    }
}
