using System.Text.Json;
using Models;

namespace Services.Middleware
{
    public class ErrorLoggingService
    {
        private readonly ILogger<ErrorLoggingService> _logger;
        private readonly RequestDelegate _next;
        
        public ErrorLoggingService(RequestDelegate next, ILogger<ErrorLoggingService> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            
            catch (Exception e)
            {
                _logger.LogError(e, "An unhandled exception has occurred.");
                await HandleExceptionAsync(context, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorResponse = new ErrorLoggingDto(exception.Message, exception.GetType().ToString());
            var json = JsonSerializer.Serialize(errorResponse);
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            
            return context.Response.WriteAsync(json);
        }
    }
}