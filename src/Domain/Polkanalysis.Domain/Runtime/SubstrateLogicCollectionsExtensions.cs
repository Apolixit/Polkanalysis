using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Runtime.Module;
using Substrate.NET.Metadata.Service;
using Polkanalysis.Domain.Contracts.Service;
using System.Diagnostics.CodeAnalysis;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;

namespace Polkanalysis.Domain.Runtime
{
    [ExcludeFromCodeCoverage]
    public static class SubstrateLogicCollectionsExtensions
    {
        public static IServiceCollection AddSubstrateLogic(this IServiceCollection services)
        {
            services.AddTransient<IMetadataService, MetadataService>();
            services.AddTransient<IModuleInformationService, ModuleInformation>();

            return services;
        }
    }
}
