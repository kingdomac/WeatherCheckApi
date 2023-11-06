using System.Text;
using WeatherCheckApi.Application.Constants;
using WeatherCheckApi.Infrastructure.Data.DB;

namespace WeatherCheckApi.Middlewares
{
    public class ApiKeyAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly DataContext _dataContext;

        public ApiKeyAuthenticationMiddleware(RequestDelegate next, DataContext dataContext)
        {
            _next = next;
            _dataContext = dataContext;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var excludedRoutes = new List<string> { "/api/login", /* Add more excluded routes as needed */ };

            // Check if the request path is in the list of excluded routes
            if (excludedRoutes.Contains(context.Request.Path))
            {
                await _next(context);
                return;
            }

            context.Items["User"] = null;
            Console.WriteLine("inside middleware");

            if (!context.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var extractedApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync(MessageConstants.ApiKeyMissing);
                return;
            }

            if (extractedApiKey.ToString() == string.Empty)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync(MessageConstants.ApiKeyMissing);
                return;
            }

            var extractedApiKeyToBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(extractedApiKey.ToString()));

            //var user = _dataContext.Users.Where(u => u.Token == extractedApiKeyToBase64).FirstOrDefault();

            //if (user == null)
            //{
            //    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //    await context.Response.WriteAsync(MessageConstants.InvalidApiKey);
            //    return;
            //}

            //context.Items["User"] = user;

            await _next(context);
        }
    }
}
