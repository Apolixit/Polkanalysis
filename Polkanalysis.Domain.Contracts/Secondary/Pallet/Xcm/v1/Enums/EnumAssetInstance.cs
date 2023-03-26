using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Xcm.v1.Enums
{
    public enum AssetInstance
    {

        Undefined = 0,

        Index = 1,

        Array4 = 2,

        Array8 = 3,

        Array16 = 4,

        Array32 = 5,

        Blob = 6,
    }

    /// <summary>
    /// >> 138 - Variant[xcm.v1.multiasset.AssetInstance]
    /// </summary>
    public sealed class EnumAssetInstance : BaseEnumExt<AssetInstance, BaseVoid, BaseCom<U128>, Nameable, Nameable, Nameable, Nameable, BaseVec<U8>>
    {
    }
}
