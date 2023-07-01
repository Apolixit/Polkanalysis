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
            services.AddScoped<IModelBuilder, ModelBuilder>();
            services.AddScoped<ISubstrateDecoding, SubstrateDecoding>();
            services.AddScoped<IPalletBuilder, PalletBuilder>();
            services.AddScoped<INodeMapping, EventNodeMapping>();
            services.AddScoped<ICurrentMetaData, CurrentMetaData>();
            services.AddScoped<IModuleInformation, ModuleInformation>();

            return services;
        }
    }
}
