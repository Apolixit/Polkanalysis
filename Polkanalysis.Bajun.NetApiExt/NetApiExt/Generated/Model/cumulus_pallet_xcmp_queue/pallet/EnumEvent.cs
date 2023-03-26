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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.pallet
{
    
    
    public enum Event
    {
        
        Success = 0,
        
        Fail = 1,
        
        BadVersion = 2,
        
        BadFormat = 3,
        
        UpwardMessageSent = 4,
        
        XcmpMessageSent = 5,
        
        OverweightEnqueued = 6,
        
        OverweightServiced = 7,
    }
    
    /// <summary>
    /// >> 51 - Variant[cumulus_pallet_xcmp_queue.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256>, Ajuna.NetApi.Model.Types.Primitive.U64>, BaseTuple<Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256>, Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v2.traits.EnumError, Ajuna.NetApi.Model.Types.Primitive.U64>, Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256>, Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256>, Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256>, Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256>, BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.U64>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.U64>>
    {
    }
}
