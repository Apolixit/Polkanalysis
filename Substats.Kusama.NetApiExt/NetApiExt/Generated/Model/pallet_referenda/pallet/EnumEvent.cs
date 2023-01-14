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


namespace Substats.Kusama.NetApiExt.Generated.Model.pallet_referenda.pallet
{
    
    
    public enum Event
    {
        
        Submitted = 0,
        
        DecisionDepositPlaced = 1,
        
        DecisionDepositRefunded = 2,
        
        DepositSlashed = 3,
        
        DecisionStarted = 4,
        
        ConfirmStarted = 5,
        
        ConfirmAborted = 6,
        
        Confirmed = 7,
        
        Approved = 8,
        
        Rejected = 9,
        
        TimedOut = 10,
        
        Cancelled = 11,
        
        Killed = 12,
        
        SubmissionDepositRefunded = 13,
    }
    
    /// <summary>
    /// >> 442 - Variant[pallet_referenda.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U16, Substats.Kusama.NetApiExt.Generated.Model.frame_support.traits.preimages.EnumBounded>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U16, Substats.Kusama.NetApiExt.Generated.Model.frame_support.traits.preimages.EnumBounded, Substats.Kusama.NetApiExt.Generated.Model.pallet_ranked_collective.Tally>, Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Kusama.NetApiExt.Generated.Model.pallet_ranked_collective.Tally>, Ajuna.NetApi.Model.Types.Primitive.U32, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Kusama.NetApiExt.Generated.Model.pallet_ranked_collective.Tally>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Kusama.NetApiExt.Generated.Model.pallet_ranked_collective.Tally>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Kusama.NetApiExt.Generated.Model.pallet_ranked_collective.Tally>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Kusama.NetApiExt.Generated.Model.pallet_ranked_collective.Tally>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>>
    {
    }
}
