using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Runtime.Module;

namespace Polkanalysis.Infrastructure.Blockchain.Runtime
{
    public static class SubstrateNodeBuilderExtensions
    {
        public static IServiceCollection AddSubstrateNodeBuilder(this IServiceCollection services)
        {
            services.AddTransient<ISubstrateDecoding, SubstrateDecoding>();
            services.AddTransient<IPalletBuilder, PalletBuilder>();
            services.AddTransient<INodeMapping, EventNodeMapping>();

            return services;
        }
    }
}
