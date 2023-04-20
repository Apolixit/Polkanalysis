using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Common.Database.Analysis.Events.Balances;
using Polkanalysis.Infrastructure.Contracts.Database.Analysis;
using Polkanalysis.Infrastructure.Contracts.Database.Analysis.Events;
using Polkanalysis.Infrastructure.Contracts.Model;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Common.Database.Analysis
{
    public class EventsFactory : IEventsFactory
    {
        public IEnumerable<EventElementFactory> Mapped { get; set; } = Enumerable.Empty<EventElementFactory>();
        private readonly ILogger<IEventsFactory> _logger;

        public EventsFactory(IServiceProvider serviceProvider, ILogger<IEventsFactory> logger) {
            _logger = logger;

            Mapped = new List<EventElementFactory>() {
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetService(typeof(BalancesTransferRepository)),
                    RuntimeEvent.Balances,
                    Domain.Contracts.Secondary.Pallet.Balances.Enums.Event.Transfer)
            };
        }

        public async Task ExecuteInsertAsync(RuntimeEvent runtimeEvent, Enum eventValue, EventsDatabaseModel eventModel, IType details, CancellationToken token)
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
