using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Runtime.Mapping;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Mapper;
using Polkanalysis.Configuration.Contracts;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository
{
    public static class PolkadotServiceCollectionsExtensions
    {
        public static IServiceCollection AddPolkadotBlockchain(this IServiceCollection services, bool registerAsSingleton = false)
        {
            if (registerAsSingleton)
            {
                services.AddSingleton<ISubstrateService, PolkadotService>();
            }
            else
            {
                services.AddScoped<ISubstrateService, PolkadotService>();
            }
            services.AddScoped<IBlockchainMapping, PolkadotMapping>();

            return services;
        }
    }
}
