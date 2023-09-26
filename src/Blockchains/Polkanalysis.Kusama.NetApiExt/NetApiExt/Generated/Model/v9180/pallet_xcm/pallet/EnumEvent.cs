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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.pallet_xcm.pallet
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
        NotifyTargetMigrationFail = 15
    }

    /// <summary>
    /// >> 14714 - Variant[pallet_xcm.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/v3/runtime/events-and-errors) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v2.traits.EnumOutcome, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v1.multilocation.MultiLocation, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v2.EnumInstruction>>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v2.EnumResponse>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U64>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v1.multilocation.MultiLocation>>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64>, Substrate.NetApi.Model.Types.Primitive.U64, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.primitive_types.H256, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v1.multilocation.MultiLocation, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.EnumVersionedMultiAssets>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.v2.traits.EnumError>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.EnumVersionedMultiLocation, Substrate.NetApi.Model.Types.Primitive.U64>>
    {
    }
}