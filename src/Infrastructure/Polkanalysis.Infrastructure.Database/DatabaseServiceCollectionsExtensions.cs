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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database
{
    [ExcludeFromCodeCoverage]
    public static class DatabaseServiceCollectionsExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddTransient<IEventsFactory, EventsFactory>();

            AddEventDatabaseRepositories(services, typeof(DatabaseServiceCollectionsExtensions).Assembly);

            services.AddTransient<IStakingDatabaseRepository, StakingDatabaseRepository>();

            return services;
        }

        public static void AddEventDatabaseRepositories(this IServiceCollection services, Assembly assemblyToScan)
        {
            var types = assemblyToScan.GetTypes();

            foreach (var type in types)
            {
                var baseType = type.BaseType;

                if (baseType == null || !baseType.IsGenericType)
                    continue;

                var genericTypeDefinition = baseType.GetGenericTypeDefinition();

                if (genericTypeDefinition == typeof(EventDatabaseRepository<,>))
                {
                    services.AddTransient(type);
                }
            }
        }
    }
}
