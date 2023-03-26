using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Democracy.Enums
{
    public enum AccountVote
    {

        Standard = 0,

        Split = 1,
    }

    /// <summary>
    /// >> 63 - Variant[pallet_democracy.vote.AccountVote]
    /// </summary>
    public sealed class EnumAccountVote : BaseEnumExt<AccountVote, 
        BaseTuple<Vote, U128>, 
        BaseTuple<U128, U128>>
    {
    }
}
