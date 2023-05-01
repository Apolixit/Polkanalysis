using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Contracts.Model;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Database.Model.Events
{
    public interface IEventsFactory
    {
        public Task ExecuteInsertAsync(RuntimeEvent runtimeEvent, Enum eventValue, EventModel eventModel, IType details, CancellationToken token);
        public bool Has(RuntimeEvent runtimeEvent, Enum eventValue);
        public EventElementFactory? TryFind(RuntimeEvent runtimeEvent, Enum eventValue);
    }
}
