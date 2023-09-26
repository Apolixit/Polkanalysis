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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_staking.pallet.pallet
{
    public enum Call
    {
        bond = 0,
        bond_extra = 1,
        unbond = 2,
        withdraw_unbonded = 3,
        validate = 4,
        nominate = 5,
        chill = 6,
        set_payee = 7,
        set_controller = 8,
        set_validator_count = 9,
        increase_validator_count = 10,
        scale_validator_count = 11,
        force_no_eras = 12,
        force_new_era = 13,
        set_invulnerables = 14,
        force_unstake = 15,
        force_new_era_always = 16,
        cancel_deferred_slash = 17,
        payout_stakers = 18,
        rebond = 19,
        reap_stash = 20,
        kick = 21,
        set_staking_configs = 22,
        chill_other = 23,
        force_apply_min_commission = 24
    }

    /// <summary>
    /// >> 12619 - Variant[pallet_staking.pallet.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_staking.EnumRewardDestination>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_staking.ValidatorPrefs, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_runtime.multiaddress.EnumMultiAddress>, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_staking.EnumRewardDestination, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_arithmetic.per_things.Percent, BaseVoid, BaseVoid, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>, BaseVoid, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_runtime.multiaddress.EnumMultiAddress>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_staking.pallet.pallet.EnumConfigOp, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_staking.pallet.pallet.EnumConfigOp, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_staking.pallet.pallet.EnumConfigOp, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_staking.pallet.pallet.EnumConfigOp, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_staking.pallet.pallet.EnumConfigOp, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_staking.pallet.pallet.EnumConfigOp>, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32>
    {
    }
}