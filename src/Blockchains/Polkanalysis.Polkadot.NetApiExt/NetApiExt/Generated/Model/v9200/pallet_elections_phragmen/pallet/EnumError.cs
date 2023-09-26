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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_elections_phragmen.pallet
{
    public enum Error
    {
        UnableToVote = 0,
        NoVotes = 1,
        TooManyVotes = 2,
        MaximumVotesExceeded = 3,
        LowBalance = 4,
        UnableToPayBond = 5,
        MustBeVoter = 6,
        ReportSelf = 7,
        DuplicatedCandidate = 8,
        MemberSubmit = 9,
        RunnerUpSubmit = 10,
        InsufficientCandidateFunds = 11,
        NotMember = 12,
        InvalidWitnessData = 13,
        InvalidVoteCount = 14,
        InvalidRenouncing = 15,
        InvalidReplacement = 16
    }

    /// <summary>
    /// >> 5090 - Variant[pallet_elections_phragmen.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}