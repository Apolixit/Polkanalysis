using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums
{
    [DomainMapping("xcm")]
    public enum VersionedMultiAssets
    {

        V0 = 0,

        V1 = 1,

        V2 = 2,

        V3 = 3
    }

    /// <summary>
    /// >> 150 - Variant[xcm.VersionedMultiAssets]
    /// </summary>
    public sealed class EnumVersionedMultiAssets : BaseEnumExt<VersionedMultiAssets, 
        BaseVec<v0.Enums.EnumMultiAsset>,
        v1.MultiAssets,
        v2.MultiAssets,
        v3.MultiAssets>
    {
    }
}
