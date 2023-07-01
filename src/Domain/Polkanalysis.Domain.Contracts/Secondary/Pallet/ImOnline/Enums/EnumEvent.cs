using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Public;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.ImOnline.Enums
{
    public enum Event
    {

        HeartbeatReceived = 0,

        AllGood = 1,

        SomeOffline = 2,
    }

    /// <summary>
    /// >> 52 - Variant[pallet_im_online.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, 
        PublicSr25519, 
        BaseVoid, 
        BaseVec<BaseTuple<SubstrateAccount, Exposure>>>
    {
    }
}
