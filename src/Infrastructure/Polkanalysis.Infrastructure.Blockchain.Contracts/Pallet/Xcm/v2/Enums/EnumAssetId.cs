//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums
{
    [DomainMapping("xcm/v2/multiasset")]
    public enum AssetId
    {
        Concrete = 0,
        Abstract = 1
    }

    /// <summary>
    /// >> 15947 - Variant[xcm.v2.multiasset.AssetId]
    /// </summary>
    public sealed class EnumAssetId : BaseEnumExt<AssetId, MultiLocation, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>
    {
    }
}