using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events
{
    public class EventElementFactory
    {
        public EventElementFactory(IDatabaseInsert databaseInsert, RuntimeEvent runtimeEvent, string eventValue, string eventName)
        {
            DatabaseInsert = databaseInsert;
            RuntimeEvent = runtimeEvent;
            EventValue = eventValue;
            EventName = eventName;
        }

        public IDatabaseInsert DatabaseInsert { get; set; }
        public RuntimeEvent RuntimeEvent { get; set; }
        public string EventValue { get; set; }
        public string EventName { get; set; }

        public (string moduleName, string moduleEvent) GetModule()
        {
            var splitted = EventName.Split('.');
            return (splitted[0], splitted[1]);
        }
    }
}
