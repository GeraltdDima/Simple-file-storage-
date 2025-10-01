namespace Extensions.ServiceCollectionExtensions
{
    public static class RedisExtensions
    {
        public static IServiceCollection UseRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["RedisConnection"];
                options.InstanceName = "RedisInstance";
            });
            
            return services;
        }
    }
}