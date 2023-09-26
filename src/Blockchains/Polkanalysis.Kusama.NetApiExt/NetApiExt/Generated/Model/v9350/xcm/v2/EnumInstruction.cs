//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v2
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
        UnsubscribeVersion = 27
    }

    /// <summary>
    /// >> 4745 - Variant[xcm.v2.Instruction]
    /// </summary>
    public sealed class EnumInstruction : BaseEnumExt<Instruction, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.MultiAssets, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.MultiAssets, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.MultiAssets, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v2.EnumResponse, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.MultiAssets, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multilocation.MultiLocation>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.MultiAssets, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v2.EnumInstruction>>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v0.EnumOriginKind, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multilocation.EnumJunctions, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.EnumMultiAssetFilter, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multilocation.MultiLocation>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.EnumMultiAssetFilter, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v2.EnumInstruction>>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.EnumMultiAssetFilter, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.MultiAssets>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.EnumMultiAssetFilter, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v2.EnumInstruction>>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.EnumMultiAssetFilter, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v2.EnumInstruction>>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multilocation.MultiLocation, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.EnumMultiAssetFilter, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>>, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.MultiAsset, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v2.EnumWeightLimit>, BaseVoid, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v2.EnumInstruction>, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v2.EnumInstruction>, BaseVoid, BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multiasset.MultiAssets, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.v1.multilocation.MultiLocation>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>>, BaseVoid>
    {
    }
}