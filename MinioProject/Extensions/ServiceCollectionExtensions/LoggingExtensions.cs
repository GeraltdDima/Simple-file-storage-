namespace Extensions.ServiceCollectionExtensions
{
    public static class LoggingExtensions
    {
        public static IServiceCollection UseLogging(this IServiceCollection services)
        {
            services.AddLogging(options =>
            {
                options.AddConsole();
                options.AddDebug();
            });
            
            return services;
        }
    }
}