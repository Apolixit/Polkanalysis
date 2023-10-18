using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums
{
    public enum VersionedMultiLocation
    {

        V0 = 0,

        V1 = 1,
    }

    /// <summary>
    /// >> 155 - Variant[xcm.VersionedMultiLocation]
    /// </summary>
    public sealed class EnumVersionedMultiLocation : BaseEnumExt<VersionedMultiLocation,
        EnumMultiLocation,
        v1.MultiLocation>
    {
    }
}
