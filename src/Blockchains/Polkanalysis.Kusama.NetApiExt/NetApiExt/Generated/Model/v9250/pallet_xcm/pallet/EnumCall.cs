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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.pallet_xcm.pallet
{
    public enum Call
    {
        send = 0,
        teleport_assets = 1,
        reserve_transfer_assets = 2,
        execute = 3,
        force_xcm_version = 4,
        force_default_xcm_version = 5,
        force_subscribe_version_notify = 6,
        force_unsubscribe_version_notify = 7,
        limited_reserve_transfer_assets = 8,
        limited_teleport_assets = 9
    }

    /// <summary>
    /// >> 11312 - Variant[pallet_xcm.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiLocation, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedXcm>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiLocation, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiLocation, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiAssets, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiLocation, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiLocation, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiAssets, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedXcm, Substrate.NetApi.Model.Types.Primitive.U64>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiLocation, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiLocation, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiLocation, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiLocation, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiAssets, Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.v2.EnumWeightLimit>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiLocation, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiLocation, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.EnumVersionedMultiAssets, Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.v2.EnumWeightLimit>>
    {
    }
}