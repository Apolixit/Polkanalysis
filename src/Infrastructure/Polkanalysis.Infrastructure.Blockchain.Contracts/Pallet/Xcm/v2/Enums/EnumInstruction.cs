﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums
{
    [DomainMapping("xcm/v2")]
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
    public sealed class EnumInstruction : BaseEnumExt<Instruction, MultiAssets, MultiAssets, MultiAssets, BaseTuple<BaseCom<U64>, 
        EnumResponse, BaseCom<U64>>, 
        BaseTuple<MultiAssets, v1.MultiLocation>, BaseTuple<MultiAssets, v1.MultiLocation, Xcm>, 
        BaseTuple<EnumOriginKind, BaseCom<U64>, DoubleEncoded>, 
        BaseTuple<BaseCom<U32>, BaseCom<U32>, BaseCom<U32>>, BaseCom<U32>, 
        BaseTuple<BaseCom<U32>, BaseCom<U32>, BaseCom<U32>>, BaseVoid, EnumJunctions, 
        BaseTuple<BaseCom<U64>, v1.MultiLocation, BaseCom<U64>>, 
        BaseTuple<EnumMultiAssetFilter, BaseCom<U32>, v1.MultiLocation>, 
        BaseTuple<EnumMultiAssetFilter, BaseCom<U32>, v1.MultiLocation, Xcm>, 
        BaseTuple<EnumMultiAssetFilter, MultiAssets>, BaseTuple<EnumMultiAssetFilter, v1.MultiLocation, Xcm>, 
        BaseTuple<EnumMultiAssetFilter, v1.MultiLocation, Xcm>, 
        BaseTuple<BaseCom<U64>, v1.MultiLocation, EnumMultiAssetFilter, BaseCom<U64>>, 
        BaseTuple<v1.MultiAsset, EnumWeightLimit>, BaseVoid, Xcm, Xcm, BaseVoid, 
        BaseTuple<MultiAssets, v1.MultiLocation>, BaseCom<U64>, 
        BaseTuple<BaseCom<U64>, BaseCom<U64>>, BaseVoid>
    {
    }
}
