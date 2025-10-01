using Microsoft.EntityFrameworkCore;

namespace Services
{
    public interface IDataBaseService
    {
        Task MigrateAsync<T>(string title = "DbContext") where T : DbContext;
    }
}