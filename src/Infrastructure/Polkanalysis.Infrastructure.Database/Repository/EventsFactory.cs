using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Database.Repository.Events.Identity;
using Polkanalysis.Infrastructure.Database.Repository.Events.System;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Infrastructure.Database.Repository
{
    public class EventsFactory : IEventsFactory
    {
        public IEnumerable<EventElementFactory> Mapped { get; set; } = Enumerable.Empty<EventElementFactory>();
        private readonly ILogger<IEventsFactory> _logger;

        public EventsFactory(IServiceProvider serviceProvider, ILogger<IEventsFactory> logger)
        {
            _logger = logger;

            // TODO : This mapper has to be done dynamically with attribute on Model
            Mapped = new List<EventElementFactory>() {
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetRequiredService(typeof(BalancesDustLostRepository)),
                    RuntimeEvent.Balances,
                    Blockchain.Contracts.Pallet.Balances.Enums.Event.DustLost),
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetRequiredService(typeof(BalancesEndowedRepository)),
                    RuntimeEvent.Balances,
                    Blockchain.Contracts.Pallet.Balances.Enums.Event.Endowed),
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetRequiredService(typeof(BalancesReservedRepository)),
                    RuntimeEvent.Balances,
                    Blockchain.Contracts.Pallet.Balances.Enums.Event.Reserved),
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetRequiredService(typeof(BalancesSetRepository)),
                    RuntimeEvent.Balances,
                    Blockchain.Contracts.Pallet.Balances.Enums.Event.BalanceSet),
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetRequiredService(typeof(BalancesSlashedRepository)),
                    RuntimeEvent.Balances,
                    Blockchain.Contracts.Pallet.Balances.Enums.Event.Slashed),
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetRequiredService(typeof(BalancesTransferRepository)),
                    RuntimeEvent.Balances,
                    Blockchain.Contracts.Pallet.Balances.Enums.Event.Transfer),
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetRequiredService(typeof(BalancesUnreservedRepository)),
                    RuntimeEvent.Balances,
                    Blockchain.Contracts.Pallet.Balances.Enums.Event.Unreserved),
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetRequiredService(typeof(IdentityIdentityClearedRepository)),
                    RuntimeEvent.Identity,
                    Blockchain.Contracts.Pallet.Identity.Enums.Event.IdentityCleared),
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetRequiredService(typeof(IdentityIdentityKilledRepository)),
                    RuntimeEvent.Identity,
                    Blockchain.Contracts.Pallet.Identity.Enums.Event.IdentityKilled),
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetRequiredService(typeof(IdentityIdentitySetRepository)),
                    RuntimeEvent.Identity,
                    Blockchain.Contracts.Pallet.Identity.Enums.Event.IdentitySet),
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetRequiredService(typeof(SystemKilledAccountRepository)),
                    RuntimeEvent.System,
                    Blockchain.Contracts.Pallet.System.Enums.Event.KilledAccount),
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetRequiredService(typeof(SystemNewAccountRepository)),
                    RuntimeEvent.System,
                    Blockchain.Contracts.Pallet.System.Enums.Event.NewAccount),
            };

            _logger.LogInformation($"{nameof(EventsFactory)} instanciated. {Mapped.Count()} events link to database found");
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
