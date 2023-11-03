using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;
using System.Text.Json;
using WeatherCheckApi.Exceptions;

namespace WeatherCheckApi.Middlewares
{
    public static class ProblemDetailsMiddlewareExtensions
    {
        public static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/problem+json";

                    var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = feature?.Error;

                    var problemDetails = new ProblemDetails
                    {
                        Title = "An error occurred",
                        Status = (int)HttpStatusCode.InternalServerError,
                        //Detail = exception?.Message,
                    };

                    if (exception is ApiException customException)
                    {
                        problemDetails.Status = (int)customException.Status;
                        problemDetails.Title = customException.Message;
                        problemDetails.Extensions.Add("errors", customException.Errors);
                        context.Response.StatusCode = (int)customException.Status;
                    }


                    var options = context.RequestServices.GetRequiredService<IOptions<JsonSerializerOptions>>();
                    var json = JsonSerializer.Serialize(problemDetails, options.Value);
                    await context.Response.WriteAsync(json);
                });
            });
        }
    }
}
