//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums
{
    [DomainMapping("xcm/v2/multiasset")]
    public enum AssetInstance
    {
        Undefined = 0,
        Index = 1,
        Array4 = 2,
        Array8 = 3,
        Array16 = 4,
        Array32 = 5,
        Blob = 6
    }

    /// <summary>
    /// >> 15949 - Variant[xcm.v2.multiasset.AssetInstance]
    /// </summary>
    public sealed class EnumAssetInstance : BaseEnumExt<AssetInstance, BaseVoid, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, NameableSize4, NameableSize8, NameableSize16, NameableSize32, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>
    {
    }
}