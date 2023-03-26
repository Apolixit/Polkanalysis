using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.NominationPools.Enums
{
    public enum Event
    {

        Created = 0,

        Bonded = 1,

        PaidOut = 2,

        Unbonded = 3,

        Withdrawn = 4,

        Destroyed = 5,

        StateChanged = 6,

        MemberRemoved = 7,

        RolesUpdated = 8,

        PoolSlashed = 9,

        UnbondingPoolSlashed = 10,
    }

    /// <summary>
    /// >> 90 - Variant[pallet_nomination_pools.pallet.Event]
    /// Events of this pallet.
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, 
        BaseTuple<SubstrateAccount, U32>, 
        BaseTuple<SubstrateAccount, U32, U128, Bool>, 
        BaseTuple<SubstrateAccount, U32, U128>, 
        BaseTuple<SubstrateAccount, U32, U128, U128, U32>, 
        BaseTuple<SubstrateAccount, U32, U128, U128>, 
        U32, 
        BaseTuple<U32, EnumPoolState>, 
        BaseTuple<U32, SubstrateAccount>, 
        BaseTuple<BaseOpt<SubstrateAccount>, BaseOpt<SubstrateAccount>, BaseOpt<SubstrateAccount>>,
        BaseTuple<U32, U128>, 
        BaseTuple<U32, U32, U128>>
    {
    }
}
