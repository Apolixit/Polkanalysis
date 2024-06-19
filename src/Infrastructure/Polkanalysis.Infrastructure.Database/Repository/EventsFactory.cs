using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Versionning;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Repository.Events;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan;
using Polkanalysis.Infrastructure.Database.Repository.Events.Identity;
using Polkanalysis.Infrastructure.Database.Repository.Events.System;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Reflection;

namespace Polkanalysis.Infrastructure.Database.Repository
{
    public class EventsFactory : IEventsFactory
    {
        public IEnumerable<EventElementFactory> Mapped { get; private set; }
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<IEventsFactory> _logger;

        public EventsFactory(IServiceProvider serviceProvider, ILogger<IEventsFactory> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;

            Mapped = ScanBindsEventAttribute();

            _logger.LogDebug("[{className}] instanciated. {eventMappedCount} events link to database found", nameof(EventsFactory), Mapped.Count());
        }

        private string BindingRepositoriesAssembly { get; set; } = "Polkanalysis.Infrastructure.Database";
        private string BlockchainInfrastructureAssembly { get; set; } = "Polkanalysis.Infrastructure.Blockchain.Contracts";

        /// <summary>
        /// Scan Polkanalysis.Infrastructure.Database.Contracts to get events repositories bind on runtime events
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private List<EventElementFactory> ScanBindsEventAttribute()
        {
            _logger.LogInformation("Start scanning assembly {assemblyName}", BindingRepositoriesAssembly);
            var versionned = new List<EventElementFactory>();

            // Get all type from given assembly
            var compatibleType = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName!.Contains(BindingRepositoriesAssembly))
                .SelectMany(x => x.GetTypes())
                .Where(t => typeof(IDatabaseInsert).IsAssignableFrom(t) && !t.IsInterface)
                ;

            // Now we are sure type won't fail on CreateInstance, let's check if it BindEvents is defined and if it implements IType
            foreach (var databaseInsertType in compatibleType)
            {
                var bindEventsAttribute = databaseInsertType.GetCustomAttributes<BindEventsAttribute>();
                if (bindEventsAttribute is not null && bindEventsAttribute.Any())
                {
                    foreach (var bindEvent in bindEventsAttribute)
                    {

                        var optionalRepo = _serviceProvider.GetService(databaseInsertType);

                        if(optionalRepo is null)
                        {
                            _logger.LogWarning(
                                "[{className}] The repository {repositoryName} is bind with {bindEventAttribute} but not register into service collection (please check {registerCollectionName})",
                                nameof(EventsFactory),
                                databaseInsertType,
                                nameof(BindEventsAttribute),
                                nameof(DatabaseServiceCollectionsExtensions));
                            continue;
                        }

                        var repoService = (IDatabaseInsert)optionalRepo!;
                        var eventName = (INameableEvent)optionalRepo!;
                        versionned.Add(new EventElementFactory(repoService, bindEvent.RuntimeEvent, bindEvent.EventValue, eventName.SearchName));
                    }
                }
            }

            _logger.LogDebug("End scanning assembly {assemblyName} give {nb} results", BindingRepositoriesAssembly, versionned.Count);

            if (versionned.Count == 0)
                throw new InvalidOperationException($"No class in {BindingRepositoriesAssembly} implement {nameof(BindEventsAttribute)} !?");

            return versionned;
        }

        public async Task ExecuteInsertAsync(RuntimeEvent runtimeEvent, Enum eventValue, EventModel eventModel, IType details, CancellationToken token)
        {
            var databaseLinked = TryFind(runtimeEvent, eventValue);

            if (databaseLinked == null) { return; }

            await databaseLinked.DatabaseInsert.InsertAsync(eventModel, details, token);
        }

        public EventElementFactory? TryFind(RuntimeEvent runtimeEvent, Enum eventValue)
        {
            return Mapped.FirstOrDefault(x =>
            x.RuntimeEvent.Equals(runtimeEvent) &&
            x.EventValue.ToString().Equals(eventValue.ToString()));
        }
        public bool Has(RuntimeEvent runtimeEvent, Enum eventValue)
        {
            return TryFind(runtimeEvent, eventValue) != null;
        }
    }
}
