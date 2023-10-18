using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums
{
    public enum Event
    {

        AuctionStarted = 0,

        AuctionClosed = 1,

        Reserved = 2,

        Unreserved = 3,

        ReserveConfiscated = 4,

        BidAccepted = 5,

        WinningOffset = 6,
    }

    /// <summary>
    /// >> 119 - Variant[polkadot_runtime_common.auctions.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<U32, U32, U32>, U32, BaseTuple<SubstrateAccount, U128, U128>, BaseTuple<SubstrateAccount, U128>, BaseTuple<Id, SubstrateAccount, U128>, BaseTuple<SubstrateAccount, Id, U128, U32, U32>, BaseTuple<U32, U32>>
    {
    }
}
