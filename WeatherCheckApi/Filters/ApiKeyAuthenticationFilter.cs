using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WeatherCheckApi.Application.Constants;
using WeatherCheckApi.Infrastructure.Data.DB;
using WeatherCheckApi.Responses;

namespace WeatherCheckApi.Filters
{
    public class ApiKeyAuthenticationFilter : IAuthorizationFilter
    {
        private readonly DataContext _dataContext;

        public ApiKeyAuthenticationFilter(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Items["User"] = null;

            if (!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var extractedApiKey))
            {
                context.Result = new UnauthorizedObjectResult(new UnauthorizationResponse(MessageConstants.ApiKeyMissing));
                return;
            }

            if(extractedApiKey.ToString() == string.Empty)
            {
                context.Result = new UnauthorizedObjectResult(new UnauthorizationResponse(MessageConstants.ApiKeyMissing));
                return;
            }

            var extractedApiKeyToBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(extractedApiKey.ToString()));

            var user = _dataContext.Users.Where(u => u.Token == extractedApiKeyToBase64).FirstOrDefault();

            if (user == null)
            {
                context.Result = new UnauthorizedObjectResult(new UnauthorizationResponse(MessageConstants.InvalidApiKey));
                return;
            }

            context.HttpContext.Items["User"] = user;

        }
    }
}
