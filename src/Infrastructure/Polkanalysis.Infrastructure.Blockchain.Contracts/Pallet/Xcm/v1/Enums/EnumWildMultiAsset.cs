using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums
{
    [DomainMapping("xcm/v1/multiasset")]
    public enum WildMultiAsset
    {

        All = 0,

        AllOf = 1,
    }

    /// <summary>
    /// >> 146 - Variant[xcm.v1.multiasset.WildMultiAsset]
    /// </summary>
    public sealed class EnumWildMultiAsset : BaseEnumExt<WildMultiAsset, BaseVoid, BaseTuple<EnumAssetId, EnumWildFungibility>>
    {
    }
}
