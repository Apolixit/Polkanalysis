using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Runtime.Mapping;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Dto;
using Polkanalysis.Domain.Repository;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Infrastructure.DirectAccess.Repository;
using Polkanalysis.Infrastructure.Polkadot.Mapper;

namespace Polkanalysis.Web.Services
{
    public static class SubstrateServices
    {
        public static IServiceCollection AddSubstrate(this IServiceCollection services)
        {
            services.AddSingleton<ISubstrateRepository, PolkadotRepository>();
            services.AddSingleton<IExplorerRepository, PolkadotExplorerRepository>();
            services.AddSingleton<IModelBuilder, ModelBuilder>();
            services.AddSingleton<ISubstrateDecoding, SubstrateDecoding>();
            services.AddSingleton<IPalletBuilder, PalletBuilder>();
            services.AddSingleton<INodeMapping, EventNodeMapping>();
            services.AddSingleton<IBlockchainMapping, PolkadotMapping>();
            services.AddSingleton<ICurrentMetaData, CurrentMetaData>();
            services.AddSingleton<IModuleInformation, ModuleInformation>();

            return services;
        }
    }
}
