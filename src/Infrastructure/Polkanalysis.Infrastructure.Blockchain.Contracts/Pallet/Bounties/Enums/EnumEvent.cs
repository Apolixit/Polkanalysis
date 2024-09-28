using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Bounties.Enums
{
    [DomainMapping("pallet_bounties/pallet")]
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
