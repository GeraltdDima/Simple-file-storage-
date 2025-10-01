using Models;

namespace Extensions.ApplicationBuilderExtensions
{
    public static class CorsExtensions
    {
        public static IApplicationBuilder UseCustomCors(this IApplicationBuilder app)
        {
            app.UseCors("AllConfiguredPolicies");
            
            return app;
        }
    }
}