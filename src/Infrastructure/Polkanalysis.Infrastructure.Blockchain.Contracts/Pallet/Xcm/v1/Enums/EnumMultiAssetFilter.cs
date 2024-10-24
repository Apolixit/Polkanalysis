using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1;
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
    public enum MultiAssetFilter
    {

        Definite = 0,

        Wild = 1,
    }

    /// <summary>
    /// >> 145 - Variant[xcm.v1.multiasset.MultiAssetFilter]
    /// </summary>
    public sealed class EnumMultiAssetFilter : BaseEnumExt<MultiAssetFilter, MultiAssets, EnumWildMultiAsset>
    {
    }
}
