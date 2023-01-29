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


namespace Substats.Kusama.NetApiExt.Generated.Model.pallet_preimage.pallet
{
    
    
    public enum Event
    {
        
        Noted = 0,
        
        Requested = 1,
        
        Cleared = 2,
    }
    
    /// <summary>
    /// >> 458 - Variant[pallet_preimage.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Substats.Kusama.NetApiExt.Generated.Model.primitive_types.H256, Substats.Kusama.NetApiExt.Generated.Model.primitive_types.H256, Substats.Kusama.NetApiExt.Generated.Model.primitive_types.H256>
    {
    }
}