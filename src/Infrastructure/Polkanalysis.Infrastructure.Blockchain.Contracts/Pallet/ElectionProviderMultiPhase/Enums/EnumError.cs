﻿using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionProviderMultiPhase.Enums
{
    [DomainMapping("pallet_election_provider_multi_phase/pallet")]
    public enum Error
    {

        PreDispatchEarlySubmission = 0,

        PreDispatchWrongWinnerCount = 1,

        PreDispatchWeakSubmission = 2,

        SignedQueueFull = 3,

        SignedCannotPayDeposit = 4,

        SignedInvalidWitness = 5,

        SignedTooMuchWeight = 6,

        OcwCallWrongEra = 7,

        MissingSnapshotMetadata = 8,

        InvalidSubmissionIndex = 9,

        CallNotAllowed = 10,

        FallbackFailed = 11,

        BoundNotMet = 12,

        TooManyWinners = 13,
    }

    /// <summary>
    /// >> 611 - Variant[pallet_election_provider_multi_phase.pallet.Error]
    /// Error of the pallet that can be returned in response to dispatches.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
