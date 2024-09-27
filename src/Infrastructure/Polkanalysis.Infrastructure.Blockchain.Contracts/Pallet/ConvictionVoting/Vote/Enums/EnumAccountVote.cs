using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ConvictionVoting.Vote.Enums
{
    [DomainMapping("pallet_conviction_voting/vote")]
    public enum AccountVote
    {
        Standard = 0,
        Split = 1,
        SplitAbstain = 2
    }

    /// <summary>
    /// >> 14047 - Variant[pallet_conviction_voting.vote.AccountVote]
    /// </summary>
    public sealed class EnumAccountVote : BaseEnumExt<AccountVote, 
        BaseTuple<Democracy.Enums.Vote, U128>, BaseTuple<U128, U128>, BaseTuple<U128, U128, U128>>
    {
    }
}
