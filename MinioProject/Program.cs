using Extensions.ConfigurationExtensions;
using Context;
using Services;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args);
        var builder = host.Build();
        
        await MigrateAsync(builder.Services);

        await builder.RunAsync();
    }
    
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(config =>
            {
                config.UseConfigs();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

    public static async Task MigrateAsync(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbService = scope.ServiceProvider.GetRequiredService<IDataBaseService>();
            
            await dbService.MigrateAsync<UserDbContext>("UserDbContext");
        }
    }
}