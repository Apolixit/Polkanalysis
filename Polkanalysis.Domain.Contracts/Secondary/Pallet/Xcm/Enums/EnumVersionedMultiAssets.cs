using Ajuna.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v0.Enums;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.Enums
{
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
