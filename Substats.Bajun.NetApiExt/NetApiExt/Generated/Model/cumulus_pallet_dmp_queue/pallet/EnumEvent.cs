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


namespace Substats.Bajun.NetApiExt.Generated.Model.cumulus_pallet_dmp_queue.pallet
{
    
    
    public enum Event
    {
        
        InvalidFormat = 0,
        
        UnsupportedVersion = 1,
        
        ExecutedDownward = 2,
        
        WeightExhausted = 3,
        
        OverweightEnqueued = 4,
        
        OverweightServiced = 5,
    }
    
    /// <summary>
    /// >> 95 - Variant[cumulus_pallet_dmp_queue.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Substats.Bajun.NetApiExt.Generated.Types.Base.Arr32U8, Substats.Bajun.NetApiExt.Generated.Types.Base.Arr32U8, BaseTuple<Substats.Bajun.NetApiExt.Generated.Types.Base.Arr32U8, Substats.Bajun.NetApiExt.Generated.Model.xcm.v2.traits.EnumOutcome>, BaseTuple<Substats.Bajun.NetApiExt.Generated.Types.Base.Arr32U8, Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.U64>, BaseTuple<Substats.Bajun.NetApiExt.Generated.Types.Base.Arr32U8, Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.U64>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.U64>>
    {
    }
}
