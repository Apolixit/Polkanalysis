using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Collective.Enums
{
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
