using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.PreImage.Enums
{
    public enum RequestStatus
    {

        Unrequested = 0,

        Requested = 1,
    }

    /// <summary>
    /// >> 451 - Variant[pallet_preimage.RequestStatus]
    /// </summary>
    public sealed class EnumRequestStatus : BaseEnumExt<RequestStatus, BaseTuple<BaseTuple<SubstrateAccount, U128>, U32>, BaseTuple<BaseOpt<BaseTuple<SubstrateAccount, U128>>, U32, BaseOpt<U32>>>
    {
    }
}
