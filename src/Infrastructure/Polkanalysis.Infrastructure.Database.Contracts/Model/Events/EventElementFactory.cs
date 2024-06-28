using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events
{
    public class EventElementFactory
    {
        public EventElementFactory(object repository,
                                    IDatabaseInsert databaseInsert,
                                   RuntimeEvent runtimeEvent,
                                   string eventValue,
                                   string eventName,
                                   Type searchCriteriaType,
                                   Type searchEvent,
                                   Type eventModelType)
        {
            Repository = repository;
            DatabaseInsert = databaseInsert;
            RuntimeEvent = runtimeEvent;
            EventValue = eventValue;
            EventName = eventName;
            SearchCriteriaType = searchCriteriaType;
            SearchEventType = searchEvent;
            EventModelType = eventModelType;
        }

        public object Repository { get; set; }
        public IDatabaseInsert DatabaseInsert { get; set; }
        public RuntimeEvent RuntimeEvent { get; set; }
        public string EventValue { get; set; }
        public string EventName { get; set; }
        public Type SearchCriteriaType { get; set; }
        public Type SearchEventType { get; set; }
        public Type EventModelType { get; set; }

        public (string moduleName, string moduleEvent) GetModule()
        {
            var splitted = EventName.Split('.');
            return (splitted[0], splitted[1]);
        }
    }
}
