using Minio;
using Models;

namespace Extensions.ServiceCollectionExtensions
{
    public static class MinioExtensions
    {
        public static IServiceCollection UseMinio(this IServiceCollection services, IConfiguration configuration)
        {
            var minioSettings = configuration.GetSection("Minio").Get<MinioSettingsDto>();

            services.AddMinio(options =>
            {
                options.WithEndpoint(minioSettings.Endpoint);
                options.WithCredentials(minioSettings.AccessKey, minioSettings.SecretKey);
                options.WithSSL(minioSettings.UseSSL);
                options.Build();
            });
            
            return services;
        }
    }
}