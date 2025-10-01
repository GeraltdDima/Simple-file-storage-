using Services;

namespace Extensions.ServiceCollectionExtensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection UseServices(this IServiceCollection services)
        {
            services
                .AddScoped<IBucketsService, BucketsService>()
                .AddScoped<IMinioService, MinioService>()
                .AddScoped<IDataBaseService, DataBaseService>()
                .AddScoped<IJwtService, JwtService>()
                .AddScoped<ICookieService, CookieService>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<ISignalRService, SignalRService>()
                .AddScoped<ISmtpService, SmtpService>();
            
            return services;
        }
    }
}