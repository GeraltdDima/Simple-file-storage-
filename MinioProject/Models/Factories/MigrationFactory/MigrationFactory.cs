using Microsoft.EntityFrameworkCore;

namespace Models.Factories
{
    public class MigrationFactory : IMigrationFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MigrationFactory> _logger;
        
        public MigrationFactory(IServiceProvider serviceProvider, ILogger<MigrationFactory> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task MigrateAsync<T>(string title = "DbContext") where T : DbContext
        {
            _logger.LogInformation($"Migrating {title}");
            
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<T>();
                
                await dbContext.Database.MigrateAsync();
            }
            
            _logger.LogInformation($"Migrated {title} successfully");
        }
    }
}