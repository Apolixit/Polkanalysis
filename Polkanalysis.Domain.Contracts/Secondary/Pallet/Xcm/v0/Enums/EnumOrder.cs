using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v0.Enums
{
    public enum Order
    {

        Null = 0,

        DepositAsset = 1,

        DepositReserveAsset = 2,

        ExchangeAsset = 3,

        InitiateReserveWithdraw = 4,

        InitiateTeleport = 5,

        QueryHolding = 6,

        BuyExecution = 7,
    }

    /// <summary>
    /// >> 438 - Variant[xcm.v0.order.Order]
    /// </summary>
    public sealed class EnumOrder : BaseEnumExt<Order, BaseVoid, BaseTuple<BaseVec<EnumMultiAsset>, EnumMultiLocation>, BaseTuple<BaseVec<EnumMultiAsset>, EnumMultiLocation, BaseVec<EnumOrder>>, BaseTuple<BaseVec<EnumMultiAsset>, BaseVec<EnumMultiAsset>>, BaseTuple<BaseVec<EnumMultiAsset>, EnumMultiLocation, BaseVec<EnumOrder>>, BaseTuple<BaseVec<EnumMultiAsset>, EnumMultiLocation, BaseVec<EnumOrder>>, BaseTuple<BaseCom<U64>, EnumMultiLocation, BaseVec<EnumMultiAsset>>, BaseTuple<EnumMultiAsset, U64, U64, Bool, BaseVec<EnumXcm>>>
    {
    }
}
