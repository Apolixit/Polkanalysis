using Microsoft.Extensions.DependencyInjection.Extensions;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Configuration.Extentions;

namespace Polkanalysis.Web.Services
{
    public static class EndpointService
    {
        public static IServiceCollection AddEndpoint(this IServiceCollection services)
        {
            services.TryAddSingleton<ISubstrateEndpoint, SubstrateEndpoint>();

            return services;
        }
    }
}
