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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.pallet_staking.pallet.pallet
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
    /// >> 11716 - Variant[pallet_staking.pallet.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Primitive.U32, BaseVoid, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32>, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.pallet_staking.ValidatorPrefs>>
    {
    }
}