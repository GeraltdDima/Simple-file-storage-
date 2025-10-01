using Context;
using Microsoft.EntityFrameworkCore;

namespace Extensions.ServiceCollectionExtensions
{
    public static class PostgreSQLExtensions
    {
        public static IServiceCollection UsePostgreSQL(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            
            return services;
        }
    }
}