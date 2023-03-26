using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v0.Enums
{
    public enum Xcm
    {

        WithdrawAsset = 0,

        ReserveAssetDeposit = 1,

        TeleportAsset = 2,

        QueryResponse = 3,

        TransferAsset = 4,

        TransferReserveAsset = 5,

        Transact = 6,

        HrmpNewChannelOpenRequest = 7,

        HrmpChannelAccepted = 8,

        HrmpChannelClosing = 9,

        RelayedFrom = 10,
    }

    /// <summary>
    /// >> 436 - Variant[xcm.v0.Xcm]
    /// </summary>
    public sealed class EnumXcm : BaseEnumExt<Xcm, BaseTuple<BaseVec<EnumMultiAsset>, BaseVec<EnumOrder>>, BaseTuple<BaseVec<EnumMultiAsset>, BaseVec<EnumOrder>>, BaseTuple<BaseVec<EnumMultiAsset>, BaseVec<EnumOrder>>, BaseTuple<BaseCom<U64>, EnumResponse>, BaseTuple<BaseVec<EnumMultiAsset>, EnumMultiLocation>, BaseTuple<BaseVec<EnumMultiAsset>, EnumMultiLocation, BaseVec<EnumOrder>>, BaseTuple<EnumOriginKind, U64, BaseVec<U8>>, BaseTuple<BaseCom<U32>, BaseCom<U32>, BaseCom<U32>>, BaseCom<U32>, BaseTuple<BaseCom<U32>, BaseCom<U32>, BaseCom<U32>>, BaseTuple<EnumMultiLocation, EnumXcm>>
    {
    }
}
