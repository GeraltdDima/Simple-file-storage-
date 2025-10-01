using Models.Factories;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class DataBaseService : IDataBaseService
    {
        private IMigrationFactory _migrationFactory;
        
        public DataBaseService(IMigrationFactory migrationFactory)
        {
            _migrationFactory = migrationFactory;
        }
        
        public async Task MigrateAsync<T>(string title = "DbContext") where T : DbContext =>
            await _migrationFactory.MigrateAsync<T>(title);
    }
}