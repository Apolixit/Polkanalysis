using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Runtime.Mapping;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Runtime.Module;
using Substrate.NET.Metadata.Service;
using Polkanalysis.Domain.Contracts.Service;
using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Domain.Runtime
{
    [ExcludeFromCodeCoverage]
    public static class SubstrateLogicCollectionsExtensions
    {
        public static IServiceCollection AddSubstrateLogic(this IServiceCollection services)
        {
            services.AddTransient<ISubstrateDecoding, SubstrateDecoding>();
            services.AddTransient<IPalletBuilder, PalletBuilder>();
            services.AddTransient<INodeMapping, EventNodeMapping>();
            services.AddTransient<Contracts.Service.IMetadataService, MetadataService>();
            services.AddTransient<IModuleInformationService, ModuleInformation>();

            return services;
        }
    }
}
