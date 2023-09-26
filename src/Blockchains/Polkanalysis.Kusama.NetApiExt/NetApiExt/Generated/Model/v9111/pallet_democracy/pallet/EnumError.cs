//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.pallet_democracy.pallet
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
        DuplicatePreimage = 9,
        NotImminent = 10,
        TooEarly = 11,
        Imminent = 12,
        PreimageMissing = 13,
        ReferendumInvalid = 14,
        PreimageInvalid = 15,
        NoneWaiting = 16,
        NotVoter = 17,
        NoPermission = 18,
        AlreadyDelegating = 19,
        InsufficientFunds = 20,
        NotDelegating = 21,
        VotesExist = 22,
        InstantNotAllowed = 23,
        Nonsense = 24,
        WrongUpperBound = 25,
        MaxVotesReached = 26,
        TooManyProposals = 27
    }

    /// <summary>
    /// >> 19971 - Variant[pallet_democracy.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://substrate.dev/docs/en/knowledgebase/runtime/errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}