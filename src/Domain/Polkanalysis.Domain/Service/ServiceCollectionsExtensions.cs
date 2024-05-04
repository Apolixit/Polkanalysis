using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Domain.Adapter.Block;
using Polkanalysis.Domain.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Service
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddSubstrateService(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IExplorerService, ExplorerService>();
            services.AddTransient<IParachainService, ParachainService>();
            services.AddTransient<IStakingService, StakingService>();
            services.AddTransient<IFinancialService, FinancialService>();

            return services;
        }
    }
}
