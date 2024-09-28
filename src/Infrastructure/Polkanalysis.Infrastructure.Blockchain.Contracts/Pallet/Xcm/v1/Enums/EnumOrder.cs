using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums
{
    [DomainMapping("xcm/v1/order")]
    public enum Order
    {

        Noop = 0,

        DepositAsset = 1,

        DepositReserveAsset = 2,

        ExchangeAsset = 3,

        InitiateReserveWithdraw = 4,

        InitiateTeleport = 5,

        QueryHolding = 6,

        BuyExecution = 7,
    }

    /// <summary>
    /// >> 443 - Variant[xcm.v1.order.Order]
    /// </summary>
    public sealed class EnumOrder : BaseEnumExt<Order, BaseVoid, BaseTuple<EnumMultiAssetFilter, U32, MultiLocation>, BaseTuple<EnumMultiAssetFilter, U32, MultiLocation, BaseVec<EnumOrder>>, BaseTuple<EnumMultiAssetFilter, MultiAssets>, BaseTuple<EnumMultiAssetFilter, MultiLocation, BaseVec<EnumOrder>>, BaseTuple<EnumMultiAssetFilter, MultiLocation, BaseVec<EnumOrder>>, BaseTuple<BaseCom<U64>, MultiLocation, EnumMultiAssetFilter>, BaseTuple<MultiAsset, U64, U64, Bool, BaseVec<EnumXcm>>>
    {
    }
}
