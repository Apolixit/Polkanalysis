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
using Ardalis.GuardClauses;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository
{
    public static class PolkadotServiceCollectionsExtensions
    {
        public static IServiceCollection AddPolkadotBlockchain(
            this IServiceCollection services,
            string blockchainName,
            bool registerAsSingleton = false)
        {
            Guard.Against.NullOrEmpty(blockchainName, message: "Blockchain has not be defined when starting application.");

            _ = blockchainName.ToLower() switch
            {
                "polkadot" => RegisterSubstrateService(services, typeof(ISubstrateService), typeof(PolkadotService), registerAsSingleton),
                _ => throw new NotSupportedException($"{blockchainName} is not supported by the application")
            };

            services.AddScoped<IBlockchainMapping, PolkadotMapping>();

            return services;
        }

        private static bool RegisterSubstrateService(IServiceCollection services, Type serviceType, Type implementationType, bool registerAsSingleton)
        {
            if(registerAsSingleton)
                services.AddSingleton(serviceType, implementationType);
            else
                services.AddScoped(serviceType, implementationType);

            return true;
        }
    }
}
