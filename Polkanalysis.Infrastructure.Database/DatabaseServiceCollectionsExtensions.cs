using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Repository;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
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
        public static IServiceCollection AddDatabaseEvents(this IServiceCollection services)
        {
            services.AddScoped<IEventsFactory, EventsFactory>();

            services.AddScoped<BalancesDustLostRepository>();
            services.AddScoped<BalancesEndowedRepository>();
            services.AddScoped<BalancesReservedRepository>();
            services.AddScoped<BalancesSetRepository>();
            services.AddScoped<BalancesSlashedRepository>();
            services.AddScoped<BalancesTransferRepository>();
            services.AddScoped<BalancesUnreservedRepository>();

            services.AddScoped<IdentityIdentityClearedRepository>();
            services.AddScoped<IdentityIdentityKilledRepository>();
            services.AddScoped<IdentityIdentitySetRepository>();

            services.AddScoped<SystemKilledAccountRepository>();
            services.AddScoped<SystemNewAccountRepository>();
            
            services.AddScoped<IStakingDatabaseRepository, StakingDatabaseRepository>();

            return services;
        }
    }
}
