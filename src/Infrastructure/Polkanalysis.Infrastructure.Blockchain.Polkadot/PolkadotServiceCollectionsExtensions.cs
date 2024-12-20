﻿using Microsoft.Extensions.DependencyInjection;
using Ardalis.GuardClauses;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using System.Diagnostics.CodeAnalysis;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Common;
using Polkanalysis.Infrastructure.Blockchain.Mythos;
using Polkanalysis.Infrastructure.Blockchain.Mythos.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot
{
    [ExcludeFromCodeCoverage]
    public static class PolkadotServiceCollectionsExtensions
    {
        public static IServiceCollection AddSubstrateBlockchain(
            this IServiceCollection services,
            string blockchainName,
            bool registerAsSingleton = false)
        {
            Guard.Against.NullOrEmpty(blockchainName, message: "Blockchain has not be defined when starting application.");

            switch(blockchainName.ToLower())
            {
                // If Polkadot is the blockchain, register the PolkadotService and PeopleChainService as dependencies
                case "polkadot":
                    RegisterSubstrateService(services, typeof(ISubstrateService), typeof(PolkadotService), registerAsSingleton);
                    RegisterSubstrateService(services, null, typeof(PeopleChainService), registerAsSingleton);
                    services.AddTransient<PolkadotMapping>();
                    services.AddTransient<PeopleChainMapping>();
                    break;
                case "peoplechain":
                    RegisterSubstrateService(services, typeof(ISubstrateService), typeof(PeopleChainService), registerAsSingleton);
                    services.AddTransient<PeopleChainMapping>();
                    break;
                case "mythos":
                    RegisterSubstrateService(services, typeof(ISubstrateService), typeof(MythosService), registerAsSingleton);
                    services.AddTransient<MythosMapping>();
                    break;
                default:
                    throw new NotSupportedException($"{blockchainName} is not supported by the application");
            }

            services.AddTransient<IDelegateSystemChain, DelegateSystemChain>();

            return services;
        }

        private static bool RegisterSubstrateService(IServiceCollection services, Type? serviceType, Type implementationType, bool registerAsSingleton)
        {
            if (registerAsSingleton)
                if(serviceType == null)
                    services.AddSingleton(implementationType);
                else
                    services.AddSingleton(serviceType, implementationType);
            else
                if(serviceType == null)
                    services.AddTransient(implementationType);
                else
                    services.AddScoped(serviceType, implementationType);

            return true;
        }
    }
}
