using Microsoft.EntityFrameworkCore;

namespace Models.Factories
{
    public interface IMigrationFactory
    {
        Task MigrateAsync<T>(string title = "DbContext") where T : DbContext;
    }
}