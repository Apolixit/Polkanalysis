using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Xcm.v1.Enums
{
    public enum AssetId
    {

        Concrete = 0,

        Abstract = 1,
    }

    /// <summary>
    /// >> 136 - Variant[xcm.v1.multiasset.AssetId]
    /// </summary>
    public sealed class EnumAssetId : BaseEnumExt<AssetId, MultiLocation, BaseVec<U8>>
    {
    }
}
