using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums
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
    public sealed class EnumAssetInstance : BaseEnumExt<AssetInstance, BaseVoid, BaseCom<U128>, NameableSize4, NameableSize8, NameableSize16, NameableSize32, BaseVec<U8>>
    {
    }
}
