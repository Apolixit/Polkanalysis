using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums
{
    [DomainMapping("xcm/v0/multi_asset")]
    public enum MultiAsset
    {

        None = 0,

        All = 1,

        AllFungible = 2,

        AllNonFungible = 3,

        AllAbstractFungible = 4,

        AllAbstractNonFungible = 5,

        AllConcreteFungible = 6,

        AllConcreteNonFungible = 7,

        AbstractFungible = 8,

        AbstractNonFungible = 9,

        ConcreteFungible = 10,

        ConcreteNonFungible = 11,
    }

    /// <summary>
    /// >> 152 - Variant[xcm.v0.multi_asset.MultiAsset]
    /// </summary>
    public sealed class EnumMultiAsset : BaseEnumExt<MultiAsset, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVec<U8>, BaseVec<U8>, EnumMultiLocation, EnumMultiLocation, BaseTuple<BaseVec<U8>, BaseCom<U128>>, BaseTuple<BaseVec<U8>, EnumAssetInstance>, BaseTuple<EnumMultiLocation, BaseCom<U128>>, BaseTuple<EnumMultiLocation, EnumAssetInstance>>
    {
    }
}
