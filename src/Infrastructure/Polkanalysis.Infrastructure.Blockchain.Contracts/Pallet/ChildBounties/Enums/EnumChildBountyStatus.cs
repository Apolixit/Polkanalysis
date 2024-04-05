using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ChildBounties.Enums
{
    [DomainMapping("pallet_child_bounties")]
    public enum ChildBountyStatus
    {

        Added = 0,

        CuratorProposed = 1,

        Active = 2,

        PendingPayout = 3,
    }

    /// <summary>
    /// >> 596 - Variant[pallet_child_bounties.ChildBountyStatus]
    /// </summary>
    public sealed class EnumChildBountyStatus : BaseEnumExt<ChildBountyStatus, BaseVoid, SubstrateAccount, SubstrateAccount, BaseTuple<SubstrateAccount, SubstrateAccount, U32>>
    {
    }
}
