using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Democracy.Enums
{
    public enum Error
    {

        ValueLow = 0,

        ProposalMissing = 1,

        AlreadyCanceled = 2,

        DuplicateProposal = 3,

        ProposalBlacklisted = 4,

        NotSimpleMajority = 5,

        InvalidHash = 6,

        NoProposal = 7,

        AlreadyVetoed = 8,

        ReferendumInvalid = 9,

        NoneWaiting = 10,

        NotVoter = 11,

        NoPermission = 12,

        AlreadyDelegating = 13,

        InsufficientFunds = 14,

        NotDelegating = 15,

        VotesExist = 16,

        InstantNotAllowed = 17,

        Nonsense = 18,

        WrongUpperBound = 19,

        MaxVotesReached = 20,

        TooMany = 21,

        VotingPeriodLow = 22,
    }

    /// <summary>
    /// >> 543 - Variant[pallet_democracy.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
