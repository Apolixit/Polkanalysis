using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Hub
{
    [ExcludeFromCodeCoverage]
    public static class HubConfigurationExtension
    {
        public static IServiceCollection AddPolkanalysisSignalRServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSignalR();

            services.AddSingleton<IHubConnection, HubConnectionWrapper>();

            var hubConfig = configuration.GetSection("PolkanalysisHub").Get<HubConfig>() ?? throw new InvalidOperationException("PolkanalysisHub section is not defined in appSettings.json");
            services.AddSingleton(sp =>
            {
                var hubBuilder = new HubConnectionBuilder();

                if (hubConfig.IsActivated)
                {
                    hubBuilder
                    .WithUrl(hubConfig.Url)
                   .WithAutomaticReconnect();
                }

                var connection = hubBuilder.Build();
                connection.StartAsync().Wait();

                return connection;
            });

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
