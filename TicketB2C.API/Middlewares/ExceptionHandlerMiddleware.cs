using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicketB2C.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (InvalidOperationException ex)
            {
                var error = new OutputError()
                {
                    ErrorCode = "NOT_FOUND_ERROR",
                    ErrorMessage = "Resource not Found!"
                };

                //Log this exception
                logger.LogError(ex, $"{error.ErrorCode} : {ex.Message}");
                // Return a custom error response
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsJsonAsync(error);

            }
            catch (Exception ex)
            {
                var error = new OutputError()
                {
                    ErrorCode = "GENERIC_ERROR",
                    ErrorMessage = "An error occurred while processing the request"
                };
                //Log this exception
                logger.LogError(ex, $"{error.ErrorCode} : {ex.Message}");
                // Return a custom error response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsJsonAsync(error);

            }
        }
    }
}
