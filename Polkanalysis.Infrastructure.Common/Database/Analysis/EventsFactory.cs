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

        public EventsFactory(IServiceProvider serviceProvider) {
            Mapped = new List<EventElementFactory>() {
                new EventElementFactory(
                    (IDatabaseInsert)serviceProvider.GetService(typeof(BalancesTransferRepository)),
                    Domain.Contracts.Secondary.Pallet.PolkadotRuntime.RuntimeEvent.Balances,
                    Domain.Contracts.Secondary.Pallet.Balances.Enums.Event.Transfer)
            };
        }

        //public void ExecuteInsert(int eventValue, Type eventType, IType details)
        public async Task ExecuteInsertAsync(Domain.Contracts.Secondary.Pallet.PolkadotRuntime.RuntimeEvent runtimeEvent, Enum eventValue, EventsDatabaseModel eventModel, IType details, CancellationToken token)
        {
            var databaseLinked = Mapped.FirstOrDefault(x => x.RuntimeEvent.Equals(runtimeEvent) && x.EventValue.Equals(eventValue));

            if(databaseLinked == null) { return; }

            await databaseLinked.DatabaseInsert.InsertAsync(eventModel, details, token);
        }
    }
}
