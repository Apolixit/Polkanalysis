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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_election_provider_multi_phase.pallet
{
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
        CallNotAllowed = 10
    }

    /// <summary>
    /// >> 1094 - Variant[pallet_election_provider_multi_phase.pallet.Error]
    /// Error of the pallet that can be returned in response to dispatches.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}