using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts
{
    public interface IEvents
    {
        public Task SubscribeEventsAsync(Action<BaseVec<EventRecord>> callback, CancellationToken token);
        //public Task SubscribeEventsAsync(Func<BaseVec<EventRecord>, Task> callback, CancellationToken token);
    }
}
