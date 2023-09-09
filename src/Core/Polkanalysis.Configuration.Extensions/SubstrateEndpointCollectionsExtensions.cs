using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Polkanalysis.Components.Configuration;
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
        public static IServiceCollection AddEndpoint(this IServiceCollection services, bool registerAsSingleton = false)
        {
            if(registerAsSingleton)
            {
                services.AddSingleton<ISubstrateEndpoint, SubstrateEndpoint>();
            } else
            {
                services.AddScoped<ISubstrateEndpoint, SubstrateEndpoint>();
            }
            
            services.AddScoped<IApiEndpoint, ApiEndpoint>();
            services.AddScoped<IMonitoringEndpoint, MonitoringEndpoint>();
            services.AddScoped<IBlockchainInformations, BlockchainInformations>();
            services.AddScoped<IWebsiteConfiguration, WebsiteConfiguration>();

            return services;
        }
    }
}
