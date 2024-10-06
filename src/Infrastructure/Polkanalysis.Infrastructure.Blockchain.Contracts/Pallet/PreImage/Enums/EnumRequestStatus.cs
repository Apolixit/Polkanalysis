using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PreImage.Enums
{
    [DomainMapping("pallet_preimage")]
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
