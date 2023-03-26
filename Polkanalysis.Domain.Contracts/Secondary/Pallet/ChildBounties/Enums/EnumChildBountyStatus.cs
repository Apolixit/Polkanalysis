using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.ChildBounties.Enums
{
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
