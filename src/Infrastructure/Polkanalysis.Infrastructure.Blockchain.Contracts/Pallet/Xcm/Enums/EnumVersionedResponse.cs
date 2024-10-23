using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums
{
    [DomainMapping("xcm")]
    public enum VersionedResponse
    {

        V0 = 0,

        V1 = 1,

        V2 = 2,

        V3 = 3,

        V4 = 4
    }

    /// <summary>
    /// >> 718 - Variant[xcm.VersionedResponse]
    /// </summary>
    public sealed class EnumVersionedResponse : BaseEnumExt<VersionedResponse,
        v0.Enums.EnumResponse,
        v1.Enums.EnumResponse,
        v2.Enums.EnumResponse,
        v3.EnumResponse>
    {
    }
}
