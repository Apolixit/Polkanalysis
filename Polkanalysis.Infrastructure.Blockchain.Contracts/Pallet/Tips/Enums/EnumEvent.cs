using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Tips.Enums
{
    [DomainMapping("pallet_tips/pallet")]
    public enum Event
    {

        NewTip = 0,

        TipClosing = 1,

        TipClosed = 2,

        TipRetracted = 3,

        TipSlashed = 4,
    }

    /// <summary>
    /// >> 85 - Variant[pallet_tips.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Hash, Hash, BaseTuple<Hash, SubstrateAccount, U128>, Hash, BaseTuple<Hash, SubstrateAccount, U128>>
    {
    }
}
