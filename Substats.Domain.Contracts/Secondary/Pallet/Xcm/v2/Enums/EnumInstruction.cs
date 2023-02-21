using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Secondary.Pallet.Xcm.v0.Enums;
using Substats.Domain.Contracts.Secondary.Pallet.Xcm.v1;
using Substats.Domain.Contracts.Secondary.Pallet.Xcm.v1.Enums;
using Substats.Polkadot.NetApiExt.Generated.Model.xcm.double_encoded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Xcm.v2.Enums
{
    public enum Instruction
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

        ClearOrigin = 10,

        DescendOrigin = 11,

        ReportError = 12,

        DepositAsset = 13,

        DepositReserveAsset = 14,

        ExchangeAsset = 15,

        InitiateReserveWithdraw = 16,

        InitiateTeleport = 17,

        QueryHolding = 18,

        BuyExecution = 19,

        RefundSurplus = 20,

        SetErrorHandler = 21,

        SetAppendix = 22,

        ClearError = 23,

        ClaimAsset = 24,

        Trap = 25,

        SubscribeVersion = 26,

        UnsubscribeVersion = 27,
    }

    /// <summary>
    /// >> 447 - Variant[xcm.v2.Instruction]
    /// </summary>
    public sealed class EnumInstruction : BaseEnumExt<Instruction, MultiAssets, MultiAssets, MultiAssets, BaseTuple<BaseCom<U64>, EnumResponse, BaseCom<U64>>, BaseTuple<MultiAssets, MultiLocation>, BaseTuple<MultiAssets, MultiLocation, XcmT1>, BaseTuple<EnumOriginKind, BaseCom<U64>, DoubleEncodedT2>, BaseTuple<BaseCom<U32>, BaseCom<U32>, BaseCom<U32>>, BaseCom<U32>, BaseTuple<BaseCom<U32>, BaseCom<U32>, BaseCom<U32>>, BaseVoid, EnumJunctions, BaseTuple<BaseCom<U64>, MultiLocation, BaseCom<U64>>, BaseTuple<EnumMultiAssetFilter, BaseCom<U32>, MultiLocation>, BaseTuple<EnumMultiAssetFilter, BaseCom<U32>, MultiLocation, XcmT1>, BaseTuple<EnumMultiAssetFilter, MultiAssets>, BaseTuple<EnumMultiAssetFilter, MultiLocation, XcmT1>, BaseTuple<EnumMultiAssetFilter, MultiLocation, XcmT1>, BaseTuple<BaseCom<U64>, MultiLocation, EnumMultiAssetFilter, BaseCom<U64>>, BaseTuple<MultiAsset, EnumWeightLimit>, BaseVoid, XcmT2, XcmT2, BaseVoid, BaseTuple<MultiAssets, MultiLocation>, BaseCom<U64>, BaseTuple<BaseCom<U64>, BaseCom<U64>>, BaseVoid>
    {
    }
}
