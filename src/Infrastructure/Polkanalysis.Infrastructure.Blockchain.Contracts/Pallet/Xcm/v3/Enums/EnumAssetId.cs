//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v3.Enums
{
    [DomainMapping("xcm/v3/multiasset")]
    public enum AssetId
    {
        Concrete = 0,
        Abstract = 1
    }

    /// <summary>
    /// >> 16783 - Variant[xcm.v3.multiasset.AssetId]
    /// </summary>
    public sealed class EnumAssetId : BaseEnumExt<AssetId, MultiLocation, NameableSize32>
    {
    }
}