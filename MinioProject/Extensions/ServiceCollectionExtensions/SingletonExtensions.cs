using Microsoft.AspNetCore.Identity.UI.Services;
using Models;

namespace Extensions.ServiceCollectionExtensions
{
    public static class SingletonExtensions
    {
        public static IServiceCollection UseSingleton(this IServiceCollection services)
        {
            services.AddSingleton<IEmailSender, EmailSender>();

            return services;
        }
    }
}