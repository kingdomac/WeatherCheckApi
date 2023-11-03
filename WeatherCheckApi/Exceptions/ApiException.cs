using System.Net;

namespace WeatherCheckApi.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode Status { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }

        public ApiException(HttpStatusCode statusCode, string message, Dictionary<string, string[]> errors = null) : base(message)
        {
            Status = statusCode;
            Errors = errors;
        }
    }
}
