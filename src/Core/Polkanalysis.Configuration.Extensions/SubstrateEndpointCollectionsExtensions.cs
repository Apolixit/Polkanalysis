using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Configuration.Contracts.Api;
using Polkanalysis.Configuration.Contracts.Endpoints;
using Polkanalysis.Configuration.Contracts.Information;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class SubstrateEndpointCollectionsExtensions
    {
        public static IServiceCollection AddEndpoint(
            this IServiceCollection services, 
            IConfiguration configuration,
            bool registerAsSingleton = false)
        {
            if(registerAsSingleton)
            {
                services.AddSingleton<ISubstrateEndpoint, SubstrateEndpoint>();
            } else
            {
                services.AddScoped<ISubstrateEndpoint, SubstrateEndpoint>();
            }

#pragma warning disable EXTEXP0018
            services.AddHybridCache(o =>
            {
                o.ReportTagMetrics = true;
                o.DefaultEntryOptions = new Microsoft.Extensions.Caching.Hybrid.HybridCacheEntryOptions
                {
                    Expiration = TimeSpan.FromDays(1),
                    LocalCacheExpiration = TimeSpan.FromDays(1),
                };
            });
#pragma warning restore EXTEXP0018

            //AddRedisDistributedCache
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "Polkanalysis";
            });

            services.AddTransient<IApiEndpoint, ApiEndpoint>();
            services.AddTransient<IMonitoringEndpoint, MonitoringEndpoint>();
            services.AddTransient<IBlockchainInformations, BlockchainInformations>();
            services.AddTransient<IWebsiteConfiguration, WebsiteConfiguration>();

            return services;
        }
    }
}
