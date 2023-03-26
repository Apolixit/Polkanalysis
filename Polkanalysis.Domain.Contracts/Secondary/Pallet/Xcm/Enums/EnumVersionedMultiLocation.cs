using Ajuna.NetApi.Model.Types.Base;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.Enums
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
        v0.Enums.EnumMultiLocation,
        v1.MultiLocation>
    {
    }
}
