using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Runtime.Mapping;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Runtime.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Runtime
{
    public static class SubstrateLogicCollectionsExtensions
    {
        public static IServiceCollection AddSubstrateLogic(this IServiceCollection services)
        {
            services.AddSingleton<IModelBuilder, ModelBuilder>();
            services.AddSingleton<ISubstrateDecoding, SubstrateDecoding>();
            services.AddSingleton<IPalletBuilder, PalletBuilder>();
            services.AddSingleton<INodeMapping, EventNodeMapping>();
            services.AddSingleton<ICurrentMetaData, CurrentMetaData>();
            services.AddSingleton<IModuleInformation, ModuleInformation>();

            return services;
        }
    }
}
