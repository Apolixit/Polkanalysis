﻿using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Infrastructure.Common.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Common.Database.Repository.Events.Identity;
using Polkanalysis.Infrastructure.Common.Database.Repository.Events.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Common.Database
{
    public static class DatabaseServiceCollectionsExtensions
    {
        public static IServiceCollection AddDatabaseEvents(this IServiceCollection services)
        {
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

            return services;
        }
    }
}