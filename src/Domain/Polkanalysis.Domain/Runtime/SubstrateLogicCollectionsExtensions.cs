using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Runtime.Mapping;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Runtime.Module;
using Substrate.NET.Metadata.Service;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.Runtime
{
    public static class SubstrateLogicCollectionsExtensions
    {
        public static IServiceCollection AddSubstrateLogic(this IServiceCollection services)
        {
            services.AddScoped<IModelBuilder, ModelBuilder>();
            services.AddScoped<ISubstrateDecoding, SubstrateDecoding>();
            services.AddScoped<IPalletBuilder, PalletBuilder>();
            services.AddScoped<INodeMapping, EventNodeMapping>();
            services.AddScoped<ICurrentMetaData, CurrentMetaData>();
            services.AddScoped<IModuleInformationService, ModuleInformation>();
            services.AddScoped<IMetadataService, MetadataService>();

            return services;
        }
    }
}
