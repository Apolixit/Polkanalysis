using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums
{
    [DomainMapping("pallet_democracy/vote")]
    public enum AccountVote
    {

        Standard = 0,

        Split = 1,

        SplitAbstain = 2
    }

    /// <summary>
    /// >> 63 - Variant[pallet_democracy.vote.AccountVote]
    /// </summary>
    public sealed class EnumAccountVote : BaseEnumExt<AccountVote,
        BaseTuple<Vote, U128>,
        BaseTuple<U128, U128>,
        BaseTuple<U128, U128, U128>>
    {
    }
}
