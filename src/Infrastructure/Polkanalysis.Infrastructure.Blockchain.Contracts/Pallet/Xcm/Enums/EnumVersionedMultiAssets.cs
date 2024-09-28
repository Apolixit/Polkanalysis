using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums
{
    [DomainMapping("xcm")]
    public enum VersionedMultiAssets
    {

        V0 = 0,

        V1 = 1,
    }

    /// <summary>
    /// >> 150 - Variant[xcm.VersionedMultiAssets]
    /// </summary>
    public sealed class EnumVersionedMultiAssets : BaseEnumExt<VersionedMultiAssets, BaseVec<EnumMultiAsset>, MultiAssets>
    {
    }
}
