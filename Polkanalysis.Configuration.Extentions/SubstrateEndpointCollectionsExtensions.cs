using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Configuration.Contracts.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Extentions
{
    public static class SubstrateEndpointCollectionsExtensions
    {
        public static IServiceCollection AddEndpoint(this IServiceCollection services)
        {
            services.TryAddSingleton<ISubstrateEndpoint, SubstrateEndpoint>();
            services.TryAddSingleton<IApiEndpoint, ApiEndpoint>();
            services.TryAddSingleton<IMonitoringEndpoint, MonitoringEndpoint>();
            services.TryAddSingleton<IBlockchainInformations, BlockchainInformations>();

            return services;
        }
    }
}
