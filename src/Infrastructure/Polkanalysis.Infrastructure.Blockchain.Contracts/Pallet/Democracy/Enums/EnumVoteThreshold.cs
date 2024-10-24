using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums
{
    [DomainMapping("pallet_democracy/vote_threshold")]
    public enum VoteThreshold
    {

        SuperMajorityApprove = 0,

        SuperMajorityAgainst = 1,

        SimpleMajority = 2,
    }

    /// <summary>
    /// >> 62 - Variant[pallet_democracy.vote_threshold.VoteThreshold]
    /// </summary>
    public sealed class EnumVoteThreshold : BaseEnum<VoteThreshold>
    {
    }
}
