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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_staking.pallet.pallet
{
    public enum Event
    {
        EraPaid = 0,
        Rewarded = 1,
        Slashed = 2,
        OldSlashingReportDiscarded = 3,
        StakersElected = 4,
        Bonded = 5,
        Unbonded = 6,
        Withdrawn = 7,
        Kicked = 8,
        StakingElectionFailed = 9,
        Chilled = 10,
        PayoutStarted = 11,
        ValidatorPrefsSet = 12
    }

    /// <summary>
    /// >> 12358 - Variant[pallet_staking.pallet.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Primitive.U32, BaseVoid, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32>, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_staking.ValidatorPrefs>>
    {
    }
}