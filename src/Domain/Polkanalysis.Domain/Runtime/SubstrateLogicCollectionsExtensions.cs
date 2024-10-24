using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Domain.Contracts.Service;
using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Domain.Runtime
{
    [ExcludeFromCodeCoverage]
    public static class SubstrateLogicCollectionsExtensions
    {
        public static IServiceCollection AddSubstrateLogic(this IServiceCollection services)
        {
            services.AddTransient<IMetadataService, MetadataService>();
            //services.AddTransient<IModuleInformationService, ModuleInformation>();

            return services;
        }
    }
}
