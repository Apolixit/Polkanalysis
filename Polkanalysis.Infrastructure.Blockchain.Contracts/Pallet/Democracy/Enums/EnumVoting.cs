using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums
{
    [DomainMapping("pallet_democracy/vote")]
    public enum Voting
    {

        Direct = 0,

        Delegating = 1,
    }

    /// <summary>
    /// >> 535 - Variant[pallet_democracy.vote.Voting]
    /// </summary>
    public sealed class EnumVoting : BaseEnumExt<Voting, BaseTuple<BaseVec<BaseTuple<U32, EnumAccountVote>>, Delegations, PriorLock>, BaseTuple<U128, SubstrateAccount, EnumConviction, Delegations, PriorLock>>
    {
    }
}
