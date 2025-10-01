using Models;

namespace Extensions.ServiceCollectionExtensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection UseCors(this IServiceCollection services, IConfiguration configuration)
        {
            var corsSettings = configuration.GetSection("Cors").Get<CorsSettingsDto>();

            var origins = corsSettings
                .Policies
                .SelectMany(policy => policy.AllowedOrigins)
                .ToArray();

            services.AddCors(options =>
            {
                foreach (var policy in corsSettings.Policies)
                {
                    options.AddPolicy(policy.PolicyName, policyOptions =>
                    {
                        policyOptions
                            .WithOrigins(policy.AllowedOrigins)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
                }
                
                options.AddPolicy("AllConfiguredPolicies", policyOptions =>
                {
                    policyOptions
                        .WithOrigins(origins)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
            
            return services;
        }
    }
}