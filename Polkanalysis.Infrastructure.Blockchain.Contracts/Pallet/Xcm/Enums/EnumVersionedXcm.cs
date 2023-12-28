using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2;
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
    public enum VersionedXcm
    {

        V0 = 0,

        V1 = 1,

        V2 = 2,
    }

    /// <summary>
    /// >> 435 - Variant[xcm.VersionedXcm]
    /// </summary>
    public sealed class EnumVersionedXcm : BaseEnumExt<VersionedXcm, v0.Enums.EnumXcm, EnumXcm, XcmT2>
    {
    }
}
