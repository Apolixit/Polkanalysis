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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.pallet_xcm.pallet
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
    /// >> 11063 - Variant[pallet_xcm.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v2.traits.EnumOutcome, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v1.multilocation.MultiLocation, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v2.EnumInstruction>>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v2.EnumResponse>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.sp_weights.weight_v2.Weight, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.sp_weights.weight_v2.Weight>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v1.multilocation.MultiLocation>>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64>, Substrate.NetApi.Model.Types.Primitive.U64, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.primitive_types.H256, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v1.multilocation.MultiLocation, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.EnumVersionedMultiAssets>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.v2.traits.EnumError>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.xcm.EnumVersionedMultiLocation, Substrate.NetApi.Model.Types.Primitive.U64>>
    {
    }
}