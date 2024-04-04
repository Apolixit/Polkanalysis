using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v3.Enums;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums
{
    [DomainMapping("xcm")]
    public enum VersionedAssetId
    {
        V3 = 3
    }

    /// <summary>
    /// >> 17157 - Variant[xcm.VersionedAssetId]
    /// </summary>
    public sealed class EnumVersionedAssetId : BaseEnumExt<VersionedAssetId, BaseVoid, BaseVoid, BaseVoid, EnumAssetId>
    {
    }
}
