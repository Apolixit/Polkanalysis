//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.pallet
{
    public enum Call
    {
        join = 0,
        bond_extra = 1,
        claim_payout = 2,
        unbond = 3,
        pool_withdraw_unbonded = 4,
        withdraw_unbonded = 5,
        create = 6,
        create_with_pool_id = 7,
        nominate = 8,
        set_state = 9,
        set_metadata = 10,
        set_configs = 11,
        update_roles = 12,
        chill = 13,
        bond_extra_other = 14,
        set_claim_permission = 15,
        claim_payout_other = 16,
        set_commission = 17,
        set_commission_max = 18,
        set_commission_change_rate = 19,
        claim_commission = 20
    }

    /// <summary>
    /// >> 306 - Variant[pallet_nomination_pools.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.EnumBondExtra, BaseVoid, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32>>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.EnumPoolState>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.EnumConfigOp, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.EnumConfigOp, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.EnumConfigOp, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.EnumConfigOp, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.EnumConfigOp, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.EnumConfigOp>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.EnumConfigOp, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.EnumConfigOp, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.EnumConfigOp>, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.multiaddress.EnumMultiAddress, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.EnumBondExtra>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.EnumClaimPermission, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_arithmetic.per_things.Perbill, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32>>>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_arithmetic.per_things.Perbill>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.CommissionChangeRate>, Substrate.NetApi.Model.Types.Primitive.U32>
    {
    }
}