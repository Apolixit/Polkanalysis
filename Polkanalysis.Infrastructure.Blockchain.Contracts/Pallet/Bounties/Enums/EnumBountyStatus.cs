using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Bounties.Enums
{
    public enum BountyStatus
    {

        Proposed = 0,

        Approved = 1,

        Funded = 2,

        CuratorProposed = 3,

        Active = 4,

        PendingPayout = 5,
    }

    /// <summary>
    /// >> 592 - Variant[pallet_bounties.BountyStatus]
    /// </summary>
    public sealed class EnumBountyStatus : BaseEnumExt<BountyStatus, BaseVoid, BaseVoid, BaseVoid, SubstrateAccount, BaseTuple<SubstrateAccount, U32>, BaseTuple<SubstrateAccount, SubstrateAccount, U32>>
    {
    }
}
