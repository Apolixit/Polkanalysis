using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Bounties.Enums
{
    public enum Event
    {

        BountyProposed = 0,

        BountyRejected = 1,

        BountyBecameActive = 2,

        BountyAwarded = 3,

        BountyClaimed = 4,

        BountyCanceled = 5,

        BountyExtended = 6,
    }

    /// <summary>
    /// >> 83 - Variant[pallet_bounties.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, U32, BaseTuple<U32, U128>, U32, BaseTuple<U32, SubstrateAccount>, BaseTuple<U32, U128, SubstrateAccount>, U32, U32>
    {
    }
}
