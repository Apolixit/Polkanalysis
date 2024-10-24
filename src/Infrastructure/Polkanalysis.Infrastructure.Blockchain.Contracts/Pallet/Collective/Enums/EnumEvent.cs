using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Enum;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Collective.Enums
{
    [DomainMapping("pallet_collective/pallet")]
    public enum Event
    {

        Proposed = 0,

        Voted = 1,

        Approved = 2,

        Disapproved = 3,

        Executed = 4,

        MemberExecuted = 5,

        Closed = 6,
    }

    /// <summary>
    /// >> 66 - Variant[pallet_collective.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event,
        BaseTuple<SubstrateAccount, U32, Hash, U32>,
        BaseTuple<SubstrateAccount, Hash, Bool, U32, U32>,
        Hash,
        Hash,
        BaseTuple<Hash, EnumResult>,
        BaseTuple<Hash, EnumResult>,
        BaseTuple<Hash, U32, U32>>
    {
    }
}
