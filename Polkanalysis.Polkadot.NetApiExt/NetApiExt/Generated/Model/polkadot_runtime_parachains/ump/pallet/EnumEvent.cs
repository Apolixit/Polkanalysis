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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.ump.pallet
{
    
    
    public enum Event
    {
        
        InvalidFormat = 0,
        
        UnsupportedVersion = 1,
        
        ExecutedUpward = 2,
        
        WeightExhausted = 3,
        
        UpwardMessagesReceived = 4,
        
        OverweightEnqueued = 5,
        
        OverweightServiced = 6,
    }
    
    /// <summary>
    /// >> 111 - Variant[polkadot_runtime_parachains.ump.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.xcm.v2.traits.EnumOutcome>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8, Substrate.NetApi.Model.Types.Primitive.U64, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight>>
    {
    }
}
