using Extensions.ServiceCollectionExtensions;
using Extensions.ApplicationBuilderExtensions;
using Models;
using Models.Factories;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IJwtSettingsFactory _jwtSettingsFactory;
    
    public Startup(IConfiguration configuration, IJwtSettingsFactory jwtSettingsFactory)
    {
        _configuration = configuration;
        _jwtSettingsFactory = jwtSettingsFactory;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        
        services
            .UseLogging()
            .UsePostgreSQL(connectionString)
            .UseRedis(_configuration)
            .UseIdentity()
            .UseJwt(_jwtSettingsFactory)
            .UseCors(_configuration)
            .UseMinio(_configuration)
            .UseFactories()
            .UseServices()
            .AddHttpContextAccessor()
            .UseSignalR()
            .AddControllers();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app
            .UseHttpsRedirection()
            .UseRouting()
            .UseStaticFiles()
            .UseErrorLogging()
            .UseCustomCors()
            .UseAuth();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHub<ChatHub>("/chathub");
        });
    }
}