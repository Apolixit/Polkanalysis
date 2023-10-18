using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PreImage.Enums
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
