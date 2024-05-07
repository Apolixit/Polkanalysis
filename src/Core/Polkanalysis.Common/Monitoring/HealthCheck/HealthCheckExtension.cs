using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Infrastructure.Database;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Common.Monitoring.HealthCheck
{
    public static class HealthCheckExtension
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddPolkanalysisHealthChecks(this IServiceCollection services)
        {
            var healthCheckBuilder = services.AddHealthChecks();

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var connexionString = configuration.GetConnectionString("SubstrateDb");

                if (string.IsNullOrEmpty(connexionString))
                    throw new ConfigurationErrorsException("SubstrateDb connection string is missing");

                healthCheckBuilder.AddNpgSql(connexionString!);
                
            }
            return services;
        }
    }
}
