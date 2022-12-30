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


namespace Blazscan.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.pallet
{
    
    
    public enum Event
    {
        
        Rebagged = 0,
        
        ScoreUpdated = 1,
    }
    
    /// <summary>
    /// >> 90 - Variant[pallet_bags_list.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.U64>, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U64>>
    {
    }
}