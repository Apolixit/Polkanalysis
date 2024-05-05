using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events
{
    public class EventElementFactory
    {
        public EventElementFactory(IDatabaseInsert databaseInsert, RuntimeEvent runtimeEvent, string eventValue)
        {
            DatabaseInsert = databaseInsert;
            RuntimeEvent = runtimeEvent;
            EventValue = eventValue;
        }

        public IDatabaseInsert DatabaseInsert { get; set; }
        public RuntimeEvent RuntimeEvent { get; set; }
        public string EventValue { get; set; }
    }
}
