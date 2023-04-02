using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Contracts
{
    public interface IEvents
    {
        public Task SubscribeEventsAsync(Action<BaseVec<EventRecord>> callback, CancellationToken token);
    }
}
