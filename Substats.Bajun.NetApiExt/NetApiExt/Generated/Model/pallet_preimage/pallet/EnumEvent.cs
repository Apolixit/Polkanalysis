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


namespace Substats.Bajun.NetApiExt.Generated.Model.pallet_preimage.pallet
{
    
    
    public enum Event
    {
        
        Noted = 0,
        
        Requested = 1,
        
        Cleared = 2,
    }
    
    /// <summary>
    /// >> 41 - Variant[pallet_preimage.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Substats.Bajun.NetApiExt.Generated.Model.primitive_types.H256, Substats.Bajun.NetApiExt.Generated.Model.primitive_types.H256, Substats.Bajun.NetApiExt.Generated.Model.primitive_types.H256>
    {
    }
}
