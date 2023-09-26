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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_xcm.pallet
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
        InvalidQuerierVersion = 16,
        InvalidQuerier = 17,
        VersionNotifyStarted = 18,
        VersionNotifyRequested = 19,
        VersionNotifyUnrequested = 20,
        FeesPaid = 21,
        AssetsClaimed = 22
    }

    /// <summary>
    /// >> 14367 - Variant[pallet_xcm.pallet.Event]
    /// 
    /// 			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    /// 			by this pallet.
    /// 			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.traits.EnumOutcome, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.EnumInstruction>>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.EnumResponse>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_weights.weight_v2.Weight, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_weights.weight_v2.Weight>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation>>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64>, Substrate.NetApi.Model.Types.Primitive.U64, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.primitive_types.H256, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.EnumVersionedMultiAssets>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multiasset.MultiAssets>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.traits.EnumError>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.EnumVersionedMultiLocation, Substrate.NetApi.Model.Types.Primitive.U64>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U64, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation>>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multiasset.MultiAssets>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multiasset.MultiAssets>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multiasset.MultiAssets>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multiasset.MultiAssets>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.primitive_types.H256, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.v3.multilocation.MultiLocation, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.xcm.EnumVersionedMultiAssets>>
    {
    }
}