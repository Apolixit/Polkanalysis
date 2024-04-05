using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ChildBounties.Enums
{
    [DomainMapping("pallet_child_bounties/pallet")]
    public enum Event
    {

        Added = 0,

        Awarded = 1,

        Claimed = 2,

        Canceled = 3,
    }

    /// <summary>
    /// >> 84 - Variant[pallet_child_bounties.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<U32, U32>, BaseTuple<U32, U32, SubstrateAccount>, BaseTuple<U32, U32, U128, SubstrateAccount>, BaseTuple<U32, U32>>
    {
    }
}
