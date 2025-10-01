namespace Extensions.ServiceCollectionExtensions
{
    public static class SignalRExtensions
    {
        public static IServiceCollection UseSignalR(this IServiceCollection services)
        {
            services.AddSignalR();
            
            return services;
        }
    }
}