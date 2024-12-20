﻿using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionsPhragmen.Enums
{
    [DomainMapping("pallet_elections_phragmen/pallet")]
    public enum Error
    {

        UnableToVote = 0,

        NoVotes = 1,

        TooManyVotes = 2,

        MaximumVotesExceeded = 3,

        LowBalance = 4,

        UnableToPayBond = 5,

        MustBeVoter = 6,

        DuplicatedCandidate = 7,

        TooManyCandidates = 8,

        MemberSubmit = 9,

        RunnerUpSubmit = 10,

        InsufficientCandidateFunds = 11,

        NotMember = 12,

        InvalidWitnessData = 13,

        InvalidVoteCount = 14,

        InvalidRenouncing = 15,

        InvalidReplacement = 16,
    }

    /// <summary>
    /// >> 552 - Variant[pallet_elections_phragmen.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
