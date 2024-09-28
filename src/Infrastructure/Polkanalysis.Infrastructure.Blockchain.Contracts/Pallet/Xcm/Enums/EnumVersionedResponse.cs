using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums
{
    [DomainMapping("xcm")]
    public enum VersionedResponse
    {

        V0 = 0,

        V1 = 1,

        V2 = 2,
    }

    /// <summary>
    /// >> 718 - Variant[xcm.VersionedResponse]
    /// </summary>
    public sealed class EnumVersionedResponse : BaseEnumExt<VersionedResponse,
        v0.Enums.EnumResponse,
        EnumResponse,
        v2.Enums.EnumResponse>
    {
    }
}
