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


namespace Substats.Polkadot.NetApiExt.Generated.Model.pallet_grandpa.pallet
{
    
    
    public enum Event
    {
        
        NewAuthorities = 0,
        
        Paused = 1,
        
        Resumed = 2,
    }
    
    /// <summary>
    /// >> 48 - Variant[pallet_grandpa.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_finality_grandpa.app.Public, Ajuna.NetApi.Model.Types.Primitive.U64>>, BaseVoid, BaseVoid>
    {
    }
}
