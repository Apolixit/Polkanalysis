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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_runtime_parachains.ump.pallet
{
    public enum Event
    {
        InvalidFormat = 0,
        UnsupportedVersion = 1,
        ExecutedUpward = 2,
        WeightExhausted = 3,
        UpwardMessagesReceived = 4,
        OverweightEnqueued = 5,
        OverweightServiced = 6
    }

    /// <summary>
    /// >> 12435 - Variant[polkadot_runtime_parachains.ump.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.xcm.v2.traits.EnumOutcome>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U64>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U64>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U64>>
    {
    }
}