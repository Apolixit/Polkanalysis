using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Democracy.Enums
{
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
