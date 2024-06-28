using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events
{
    public interface IEventsFactory
    {
        public IEnumerable<EventElementFactory> Mapped { get; }
        public Task ExecuteInsertAsync(RuntimeEvent runtimeEvent, Enum eventValue, EventModel eventModel, IType details, CancellationToken token);
        public IEnumerable<(string name, string filter)> GetSearchCriteriasParameters(Type searchCriteria);
        public bool Has(RuntimeEvent runtimeEvent, Enum eventValue);
        public Task<IEnumerable<EventModel>> InvokeSearchAsync(EventElementFactory eventElementFactory, SearchCriteria criteria, CancellationToken token);
        public EventElementFactory? TryFind(RuntimeEvent runtimeEvent, Enum eventValue);
    }
}
