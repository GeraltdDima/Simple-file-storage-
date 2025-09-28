using Services.Middleware;

namespace Extensions.ApplicationBuilderExtensions
{
    public static class ErrorLoggingExtensions
    {
        public static IApplicationBuilder UseErrorLogging(this IApplicationBuilder app) =>
            app.UseMiddleware<ErrorLoggingService>();
    }
}