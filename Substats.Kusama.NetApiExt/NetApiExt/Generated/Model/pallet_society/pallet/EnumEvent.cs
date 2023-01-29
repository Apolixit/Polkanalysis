//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Substats.Kusama.NetApiExt.Generated.Model.pallet_society.pallet
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
    }
    
    /// <summary>
    /// >> 451 - Variant[pallet_society.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>>, BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.Bool>, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.Bool>, BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.Bool>, Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>
    {
    }
}