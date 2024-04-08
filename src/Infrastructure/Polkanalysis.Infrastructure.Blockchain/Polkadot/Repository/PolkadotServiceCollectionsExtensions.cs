using Microsoft.Extensions.DependencyInjection;
using Ardalis.GuardClauses;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository
{
    public static class PolkadotServiceCollectionsExtensions
    {
        public static IServiceCollection AddPolkadotBlockchain(
            this IServiceCollection services,
            string blockchainName,
            bool registerAsSingleton = false)
        {
            Guard.Against.NullOrEmpty(blockchainName, nameof(blockchainName), message: "Blockchain has not be defined when starting application.");

            _ = blockchainName.ToLower() switch
            {
                "polkadot" => RegisterSubstrateService(services, typeof(ISubstrateService), typeof(PolkadotService), registerAsSingleton),
                _ => throw new NotSupportedException($"{blockchainName} is not supported by the application")
            };

            services.AddTransient<IBlockchainMapping, PolkadotMapping>();

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
