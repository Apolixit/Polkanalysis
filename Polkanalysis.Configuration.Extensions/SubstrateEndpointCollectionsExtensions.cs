using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Configuration.Contracts.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Extensions
{
    public static class SubstrateEndpointCollectionsExtensions
    {
        public static IServiceCollection AddEndpoint(this IServiceCollection services)
        {
            services.TryAddScoped<ISubstrateEndpoint, SubstrateEndpoint>();
            services.TryAddScoped<IApiEndpoint, ApiEndpoint>();
            services.TryAddScoped<IMonitoringEndpoint, MonitoringEndpoint>();
            services.TryAddScoped<IBlockchainInformations, BlockchainInformations>();

            return services;
        }
    }
}
