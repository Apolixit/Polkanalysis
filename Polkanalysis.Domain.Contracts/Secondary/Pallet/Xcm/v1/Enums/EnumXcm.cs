using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v1.Enums
{
    public enum Xcm
    {

        WithdrawAsset = 0,

        ReserveAssetDeposited = 1,

        ReceiveTeleportedAsset = 2,

        QueryResponse = 3,

        TransferAsset = 4,

        TransferReserveAsset = 5,

        Transact = 6,

        HrmpNewChannelOpenRequest = 7,

        HrmpChannelAccepted = 8,

        HrmpChannelClosing = 9,

        RelayedFrom = 10,

        SubscribeVersion = 11,

        UnsubscribeVersion = 12,
    }

    /// <summary>
    /// >> 441 - Variant[xcm.v1.Xcm]
    /// </summary>
    public sealed class EnumXcm : BaseEnumExt<Xcm, BaseTuple<MultiAssets, BaseVec<EnumOrder>>, BaseTuple<MultiAssets, BaseVec<EnumOrder>>, BaseTuple<MultiAssets, BaseVec<EnumOrder>>, BaseTuple<BaseCom<U64>, EnumResponse>, BaseTuple<MultiAssets, MultiLocation>, BaseTuple<MultiAssets, MultiLocation, BaseVec<EnumOrder>>, BaseTuple<v0.Enums.EnumOriginKind, U64, BaseVec<U8>>, BaseTuple<BaseCom<U32>, BaseCom<U32>, BaseCom<U32>>, BaseCom<U32>, BaseTuple<BaseCom<U32>, BaseCom<U32>, BaseCom<U32>>, BaseTuple<EnumJunctions, EnumXcm>, BaseTuple<BaseCom<U64>, BaseCom<U64>>, BaseVoid>
    {
    }
}
