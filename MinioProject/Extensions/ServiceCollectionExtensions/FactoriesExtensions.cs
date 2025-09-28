using Models.Factories;

namespace Extensions.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseFactories(this IServiceCollection services)
        {
            services
                .AddScoped<IBucketsFactory, BucketsFactory>()
                .AddScoped<IDownloadFactory, DownloadFactory>()
                .AddScoped<IGetObjectArgsFactory, GetObjectArgsFactory>()
                .AddScoped<IPutObjectArgsFactory, PutObjectArgsFactory>()
                .AddScoped<IUploadFactory, UploadFactory>();
            
            return services;
        }
    }
}