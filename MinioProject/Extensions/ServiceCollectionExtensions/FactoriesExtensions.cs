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
                .AddScoped<IUploadFactory, UploadFactory>()
                .AddScoped<IMigrationFactory, MigrationFactory>()
                .AddScoped<IEmailConfirmFactory, EmailConfirmFactory>()
                .AddScoped<IRefreshTokenFactory, RefreshTokenFactory>()
                .AddScoped<IAccessTokenFactory, AccessTokenFactory>()
                .AddScoped<IClaimsFactory, ClaimsFactory>()
                .AddScoped<IRegisterFactory, RegisterFactory>()
                .AddScoped<IRoleFactory, RoleFactory>()
                .AddScoped<ICookieOptionsFactory, CookieOptionsFactory>()
                .AddScoped<ICookieFactory, CookieFactory>()
                .AddScoped<ILoginFactory, LoginFactory>()
                .AddScoped<ISignalRMessageFactory, SignalRMessageFactory>()
                .AddScoped<IJwtSettingsFactory, JwtSettingsFactory>();
            
            return services;
        }
    }
}