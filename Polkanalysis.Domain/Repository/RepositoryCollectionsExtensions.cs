using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Domain.Adapter.Block;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Repository
{
    public static class RepositoryCollectionsExtensions
    {
        public static IServiceCollection AddSubstrateRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<IExplorerRepository, ExplorerRepository>();
            services.AddSingleton<IParachainRepository, ParachainRepository>();
            services.AddSingleton<IStakingRepository, StakingRepository>();

            services.AddSingleton<BlockParameterLike>();

            return services;
        }
    }
}
