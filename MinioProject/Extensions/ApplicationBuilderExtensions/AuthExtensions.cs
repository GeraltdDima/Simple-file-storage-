namespace Extensions.ApplicationBuilderExtensions
{
    public static class AuthExtensions
    {
        public static IApplicationBuilder UseAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            
            return app;
        }
    }
}