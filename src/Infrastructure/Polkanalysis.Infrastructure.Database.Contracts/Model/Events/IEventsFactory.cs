using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events
{
    public interface IEventsFactory
    {
        IEnumerable<EventElementFactory> Mapped { get; }
        public Task ExecuteInsertAsync(RuntimeEvent runtimeEvent, Enum eventValue, EventModel eventModel, IType details, CancellationToken token);
        public bool Has(RuntimeEvent runtimeEvent, Enum eventValue);
        public EventElementFactory? TryFind(RuntimeEvent runtimeEvent, Enum eventValue);
    }
}
