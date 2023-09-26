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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_society.pallet
{
    public enum Event
    {
        Founded = 0,
        Bid = 1,
        Vouch = 2,
        AutoUnbid = 3,
        Unbid = 4,
        Unvouch = 5,
        Inducted = 6,
        SuspendedMemberJudgement = 7,
        CandidateSuspended = 8,
        MemberSuspended = 9,
        Challenged = 10,
        Vote = 11,
        DefenderVote = 12,
        NewMaxMembers = 13,
        Unfounded = 14,
        Deposit = 15,
        SkepticsChosen = 16
    }

    /// <summary>
    /// >> 1331 - Variant[pallet_society.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32>>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.Bool>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.Bool>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.Bool>, Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32>>
    {
    }
}