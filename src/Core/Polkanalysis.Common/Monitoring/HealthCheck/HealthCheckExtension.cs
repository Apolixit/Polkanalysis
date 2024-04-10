using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Infrastructure.Database;

namespace Polkanalysis.Common.Monitoring.HealthCheck
{
    public static class HealthCheckExtension
    {
        public static IServiceCollection AddHealthChecks(this IServiceCollection services)
        {
            var healthCheckBuilder = services.AddHealthChecks();

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var connexionString = configuration.GetConnectionString("SubstrateDb");

                healthCheckBuilder.AddNpgsql<SubstrateDbContext>(connexionString);
                
            }

            //healthCheckBuilder.AddCheck<SubstrateHealthCheck>("BlockchainHealthCheck");
            return services;
        }
    }
}
