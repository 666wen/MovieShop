using ApplicationCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieShopAPI.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    //????ILogger have not do DI in programmer to implement by SeriLog?????
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionMiddleware> _logger;
        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                // read info from the HttpContext object and log it some where
                _logger.LogInformation("Inside the Middleware");
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // First catch the exception
                // check the exception type, message,
                // check stacktrace, where the exception happned
                // when the exception happened
                // for which URL and which Http method (controller, action method)
                // for which user, if user is loged in


                var exceptionDetails = new ErrorModel
                {
                    Message = ex.Message,
                    // StackTrace = ex.StackTrace,
                    ExceptionDateTime = DateTime.UtcNow,
                    // ExceptionType = ex.GetType().ToString(),
                    Path = httpContext.Request.Path,
                    HttpRequestType = httpContext.Request.Method,
                    User = httpContext.User.Identity.IsAuthenticated ? httpContext.User.Identity.Name : null
                };


                // Save all this information some where, text files, json files or Database
                // -Sytem.IO to create text files
                // -asp.net core has builtin logging mechanism, (ILogger) which can be used by any 3rdy party log provide
                // *SeriLog* and NLog --popular log library. SeriLog implement the build-in interface Ilogger.
                // Send email to Dev Team when exception happens eg: support@antra.com
                _logger.LogError("Exception happened, log this to text or Json files using SeriLog");

                // return http status code 500
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var result = JsonSerializer.Serialize<ErrorModel>(exceptionDetails);
                await httpContext.Response.WriteAsync(result);
                // httpContext.Response.Redirect("/home/error")

                //return _next(httpContext);  //before next step, run above program.
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            //add customed middleware method to IapplicationBuilder as extension method!!
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
