using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums
{
    [DomainMapping("pallet_democracy/pallet")]
    public enum Event
    {

        Proposed = 0,

        Tabled = 1,

        ExternalTabled = 2,

        Started = 3,

        Passed = 4,

        NotPassed = 5,

        Cancelled = 6,

        Delegated = 7,

        Undelegated = 8,

        Vetoed = 9,

        Blacklisted = 10,

        Voted = 11,

        Seconded = 12,

        ProposalCanceled = 13,
    }

    /// <summary>
    /// >> 61 - Variant[pallet_democracy.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event,
        BaseTuple<U32, U128>,
        BaseTuple<U32, U128>,
        BaseVoid,
        BaseTuple<U32, EnumVoteThreshold>,
        U32,
        U32,
        U32,
        BaseTuple<SubstrateAccount, SubstrateAccount>,
        SubstrateAccount,
        BaseTuple<SubstrateAccount, Hash, U32>,
        Hash,
        BaseTuple<SubstrateAccount, U32, EnumAccountVote>,
        BaseTuple<SubstrateAccount, U32>, U32>
    {
    }
}
