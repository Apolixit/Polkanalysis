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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_staking.pallet.pallet
{
    public enum Event
    {
        EraPaid = 0,
        Rewarded = 1,
        Slashed = 2,
        SlashReported = 3,
        OldSlashingReportDiscarded = 4,
        StakersElected = 5,
        Bonded = 6,
        Unbonded = 7,
        Withdrawn = 8,
        Kicked = 9,
        StakingElectionFailed = 10,
        Chilled = 11,
        PayoutStarted = 12,
        ValidatorPrefsSet = 13,
        ForceEra = 14
    }

    /// <summary>
    /// >> 903 - Variant[pallet_staking.pallet.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_arithmetic.per_things.Perbill, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Primitive.U32, BaseVoid, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32>, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_staking.ValidatorPrefs>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_staking.EnumForcing>
    {
    }
}