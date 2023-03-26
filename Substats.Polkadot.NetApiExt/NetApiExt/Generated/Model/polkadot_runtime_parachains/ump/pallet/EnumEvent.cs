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


namespace Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.ump.pallet
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
    public sealed class EnumEvent : BaseEnumExt<Event, Substats.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8, Substats.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8, Substats.Polkadot.NetApiExt.Generated.Model.xcm.v2.traits.EnumOutcome>, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8, Substats.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight, Substats.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight>, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Substats.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8, Ajuna.NetApi.Model.Types.Primitive.U64, Substats.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U64, Substats.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight>>
    {
    }
}
