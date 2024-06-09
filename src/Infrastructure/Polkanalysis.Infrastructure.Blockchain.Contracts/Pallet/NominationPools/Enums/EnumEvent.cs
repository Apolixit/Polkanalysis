using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums
{
    [DomainMapping("pallet_nomination_pools/pallet")]
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

        PoolCommissionUpdated = 11,
        PoolMaxCommissionUpdated = 12,
        PoolCommissionChangeRateUpdated = 13,
        PoolCommissionClaimPermissionUpdated = 14,
        PoolCommissionClaimed = 15,
        MinBalanceDeficitAdjusted = 16,
        MinBalanceExcessAdjusted = 17
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
        BaseTuple<U32, U32, U128>,
        BaseTuple<U32, BaseOpt<BaseTuple<Perbill, SubstrateAccount>>>, 
        BaseTuple<U32, Perbill>, 
        BaseTuple<U32, CommissionChangeRate>, 
        BaseTuple<U32, BaseOpt<EnumCommissionClaimPermission>>, 
        BaseTuple<U32, U128>, 
        BaseTuple<U32, U128>, 
        BaseTuple<U32, U128>>
    {
    }
}
