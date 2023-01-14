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


namespace Substats.Kusama.NetApiExt.Generated.Model.pallet_nis.pallet
{
    
    
    public enum Event
    {
        
        BidPlaced = 0,
        
        BidRetracted = 1,
        
        BidDropped = 2,
        
        Issued = 3,
        
        Thawed = 4,
        
        Funded = 5,
        
        Transferred = 6,
    }
    
    /// <summary>
    /// >> 464 - Variant[pallet_nis.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U32>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Kusama.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perquintill, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Kusama.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perquintill, Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.Bool>, Ajuna.NetApi.Model.Types.Primitive.U128, BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U32>>
    {
    }
}
