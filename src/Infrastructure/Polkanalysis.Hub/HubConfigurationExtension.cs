namespace Polkanalysis.Hub
{
    public static class HubConfigurationExtension
    {
        public static IServiceCollection AddSignalRServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSignalR();
                //.AddStackExchangeRedis(configuration.GetConnectionString("Redis"));
            return services;
        }

        public static IApplicationBuilder UseSignalRConfiguration(this IApplicationBuilder app)
        {
            // Ajoute le middleware SignalR
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<PolkanalysisHub>("/polkanalysishub");
            });

            return app;
        }
    }
}
