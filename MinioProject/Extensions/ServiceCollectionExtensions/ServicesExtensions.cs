using Services;

namespace Extensions.ServiceCollectionExtensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection UseServices(this IServiceCollection services)
        {
            services
                .AddScoped<IBucketsService, BucketsService>()
                .AddScoped<IMinioService, MinioService>();
            
            return services;
        }
    }
}