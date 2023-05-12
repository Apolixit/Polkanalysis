using Polkanalysis.Infrastructure.Common.Database;

namespace Polkanalysis.Web.Services
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDatabaseEvents();

            return services;
        }
    }
}
