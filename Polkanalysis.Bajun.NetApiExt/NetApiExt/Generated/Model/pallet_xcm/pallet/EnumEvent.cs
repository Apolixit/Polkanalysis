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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_xcm.pallet
{
    
    
    public enum Event
    {
        
        Attempted = 0,
        
        Sent = 1,
        
        UnexpectedResponse = 2,
        
        ResponseReady = 3,
        
        Notified = 4,
        
        NotifyOverweight = 5,
        
        NotifyDispatchError = 6,
        
        NotifyDecodeFailed = 7,
        
        InvalidResponder = 8,
        
        InvalidResponderVersion = 9,
        
        ResponseTaken = 10,
        
        AssetsTrapped = 11,
        
        VersionChangeNotified = 12,
        
        SupportedVersionChanged = 13,
        
        NotifyTargetSendFail = 14,
        
        NotifyTargetMigrationFail = 15,
    }
    
    /// <summary>
    /// >> 55 - Variant[pallet_xcm.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v2.traits.EnumOutcome, BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation, Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation, Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v2.XcmT1>, BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v2.EnumResponse>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U64>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation>>, BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64>, Substrate.NetApi.Model.Types.Primitive.U64, BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256, Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation, Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.EnumVersionedMultiAssets>, BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64, Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.v2.traits.EnumError>, BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation, Substrate.NetApi.Model.Types.Primitive.U64>>
    {
    }
}
