using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Extensions;
using Polkanalysis.Infrastructure.Database.Repository;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan;
using Polkanalysis.Infrastructure.Database.Repository.Events.Identity;
using Polkanalysis.Infrastructure.Database.Repository.Events.System;
using Polkanalysis.Infrastructure.Database.Repository.Staking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database
{
    public static class DatabaseServiceCollectionsExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddTransient<IEventsFactory, EventsFactory>();

            services.AddTransient<BalancesDustLostRepository>();
            services.AddTransient<BalancesEndowedRepository>();
            services.AddTransient<BalancesReservedRepository>();
            services.AddTransient<BalancesSetRepository>();
            services.AddTransient<BalancesSlashedRepository>();
            services.AddTransient<BalancesTransferRepository>();
            services.AddTransient<BalancesUnreservedRepository>();

            services.AddTransient<IdentityIdentityClearedRepository>();
            services.AddTransient<IdentityIdentityKilledRepository>();
            services.AddTransient<IdentityIdentitySetRepository>();

            services.AddTransient<SystemKilledAccountRepository>();
            services.AddTransient<SystemNewAccountRepository>();

            services.AddTransient<CrowloanContributedRepository>();

            services.AddTransient<IStakingDatabaseRepository, StakingDatabaseRepository>();

            return services;
        }
    }
}
