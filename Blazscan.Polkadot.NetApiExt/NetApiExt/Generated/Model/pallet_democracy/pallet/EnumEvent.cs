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


namespace Blazscan.Polkadot.NetApiExt.Generated.Model.pallet_democracy.pallet
{
    
    
    public enum Event
    {
        
        Proposed = 0,
        
        Tabled = 1,
        
        ExternalTabled = 2,
        
        Started = 3,
        
        Passed = 4,
        
        NotPassed = 5,
        
        Cancelled = 6,
        
        Executed = 7,
        
        Delegated = 8,
        
        Undelegated = 9,
        
        Vetoed = 10,
        
        PreimageNoted = 11,
        
        PreimageUsed = 12,
        
        PreimageInvalid = 13,
        
        PreimageMissing = 14,
        
        PreimageReaped = 15,
        
        Blacklisted = 16,
        
        Voted = 17,
        
        Seconded = 18,
        
        ProposalCanceled = 19,
    }
    
    /// <summary>
    /// >> 61 - Variant[pallet_democracy.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>>, BaseVoid, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Blazscan.Polkadot.NetApiExt.Generated.Model.pallet_democracy.vote_threshold.EnumVoteThreshold>, Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Blazscan.Polkadot.NetApiExt.Generated.Types.Base.EnumResult>, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>, Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Blazscan.Polkadot.NetApiExt.Generated.Model.primitive_types.H256, Ajuna.NetApi.Model.Types.Primitive.U32>, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.primitive_types.H256, Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.primitive_types.H256, Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.primitive_types.H256, Ajuna.NetApi.Model.Types.Primitive.U32>, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.primitive_types.H256, Ajuna.NetApi.Model.Types.Primitive.U32>, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.primitive_types.H256, Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128, Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>, Blazscan.Polkadot.NetApiExt.Generated.Model.primitive_types.H256, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U32, Blazscan.Polkadot.NetApiExt.Generated.Model.pallet_democracy.vote.EnumAccountVote>, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U32>, Ajuna.NetApi.Model.Types.Primitive.U32>
    {
    }
}
