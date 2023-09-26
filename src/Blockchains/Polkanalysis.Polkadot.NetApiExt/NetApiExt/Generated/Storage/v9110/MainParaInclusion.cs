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
using System.Threading.Tasks;
using Substrate.NetApi.Model.Meta;
using System.Threading;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Extrinsics;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9110
{
    public sealed class ParaInclusionStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> AvailabilityBitfieldsParams
        ///  The latest bitfield for each validator, referred to by their index in the validator set.
        /// </summary>
        public static string AvailabilityBitfieldsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_primitives.v0.ValidatorIndex key)
        {
            return RequestGenerator.GetStorage("ParaInclusion", "AvailabilityBitfields", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> AvailabilityBitfieldsDefault
        /// Default value as hex string
        /// </summary>
        public static string AvailabilityBitfieldsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> AvailabilityBitfields
        ///  The latest bitfield for each validator, referred to by their index in the validator set.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_runtime_parachains.inclusion.AvailabilityBitfieldRecord> AvailabilityBitfields(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_primitives.v0.ValidatorIndex key, CancellationToken token)
        {
            string parameters = AvailabilityBitfieldsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_runtime_parachains.inclusion.AvailabilityBitfieldRecord>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PendingAvailabilityParams
        ///  Candidates pending availability by `ParaId`.
        /// </summary>
        public static string PendingAvailabilityParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("ParaInclusion", "PendingAvailability", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> PendingAvailabilityDefault
        /// Default value as hex string
        /// </summary>
        public static string PendingAvailabilityDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> PendingAvailability
        ///  Candidates pending availability by `ParaId`.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_runtime_parachains.inclusion.CandidatePendingAvailability> PendingAvailability(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = PendingAvailabilityParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_runtime_parachains.inclusion.CandidatePendingAvailability>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PendingAvailabilityCommitmentsParams
        ///  The commitments of candidates pending availability, by `ParaId`.
        /// </summary>
        public static string PendingAvailabilityCommitmentsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("ParaInclusion", "PendingAvailabilityCommitments", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> PendingAvailabilityCommitmentsDefault
        /// Default value as hex string
        /// </summary>
        public static string PendingAvailabilityCommitmentsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> PendingAvailabilityCommitments
        ///  The commitments of candidates pending availability, by `ParaId`.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_primitives.v1.CandidateCommitments> PendingAvailabilityCommitments(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = PendingAvailabilityCommitmentsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_primitives.v1.CandidateCommitments>(parameters, blockHash, token);
            return result;
        }

        public ParaInclusionStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class ParaInclusionConstants
    {
    }

    public enum ParaInclusionErrors
    {
        /// <summary>
        /// >> WrongBitfieldSize
        /// Availability bitfield has unexpected size.
        /// </summary>
        WrongBitfieldSize,
        /// <summary>
        /// >> BitfieldDuplicateOrUnordered
        /// Multiple bitfields submitted by same validator or validators out of order by index.
        /// </summary>
        BitfieldDuplicateOrUnordered,
        /// <summary>
        /// >> ValidatorIndexOutOfBounds
        /// Validator index out of bounds.
        /// </summary>
        ValidatorIndexOutOfBounds,
        /// <summary>
        /// >> InvalidBitfieldSignature
        /// Invalid signature
        /// </summary>
        InvalidBitfieldSignature,
        /// <summary>
        /// >> UnscheduledCandidate
        /// Candidate submitted but para not scheduled.
        /// </summary>
        UnscheduledCandidate,
        /// <summary>
        /// >> CandidateScheduledBeforeParaFree
        /// Candidate scheduled despite pending candidate already existing for the para.
        /// </summary>
        CandidateScheduledBeforeParaFree,
        /// <summary>
        /// >> WrongCollator
        /// Candidate included with the wrong collator.
        /// </summary>
        WrongCollator,
        /// <summary>
        /// >> ScheduledOutOfOrder
        /// Scheduled cores out of order.
        /// </summary>
        ScheduledOutOfOrder,
        /// <summary>
        /// >> HeadDataTooLarge
        /// Head data exceeds the configured maximum.
        /// </summary>
        HeadDataTooLarge,
        /// <summary>
        /// >> PrematureCodeUpgrade
        /// Code upgrade prematurely.
        /// </summary>
        PrematureCodeUpgrade,
        /// <summary>
        /// >> NewCodeTooLarge
        /// Output code is too large
        /// </summary>
        NewCodeTooLarge,
        /// <summary>
        /// >> CandidateNotInParentContext
        /// Candidate not in parent context.
        /// </summary>
        CandidateNotInParentContext,
        /// <summary>
        /// >> UnoccupiedBitInBitfield
        /// The bitfield contains a bit relating to an unassigned availability core.
        /// </summary>
        UnoccupiedBitInBitfield,
        /// <summary>
        /// >> InvalidGroupIndex
        /// Invalid group index in core assignment.
        /// </summary>
        InvalidGroupIndex,
        /// <summary>
        /// >> InsufficientBacking
        /// Insufficient (non-majority) backing.
        /// </summary>
        InsufficientBacking,
        /// <summary>
        /// >> InvalidBacking
        /// Invalid (bad signature, unknown validator, etc.) backing.
        /// </summary>
        InvalidBacking,
        /// <summary>
        /// >> NotCollatorSigned
        /// Collator did not sign PoV.
        /// </summary>
        NotCollatorSigned,
        /// <summary>
        /// >> ValidationDataHashMismatch
        /// The validation data hash does not match expected.
        /// </summary>
        ValidationDataHashMismatch,
        /// <summary>
        /// >> InternalError
        /// Internal error only returned when compiled with debug assertions.
        /// </summary>
        InternalError,
        /// <summary>
        /// >> IncorrectDownwardMessageHandling
        /// The downward message queue is not processed correctly.
        /// </summary>
        IncorrectDownwardMessageHandling,
        /// <summary>
        /// >> InvalidUpwardMessages
        /// At least one upward message sent does not pass the acceptance criteria.
        /// </summary>
        InvalidUpwardMessages,
        /// <summary>
        /// >> HrmpWatermarkMishandling
        /// The candidate didn't follow the rules of HRMP watermark advancement.
        /// </summary>
        HrmpWatermarkMishandling,
        /// <summary>
        /// >> InvalidOutboundHrmp
        /// The HRMP messages sent by the candidate is not valid.
        /// </summary>
        InvalidOutboundHrmp,
        /// <summary>
        /// >> InvalidValidationCodeHash
        /// The validation code hash of the candidate is not valid.
        /// </summary>
        InvalidValidationCodeHash,
        /// <summary>
        /// >> ParaHeadMismatch
        /// The `para_head` hash in the candidate descriptor doesn't match the hash of the actual para head in the
        /// commitments.
        /// </summary>
        ParaHeadMismatch
    }
}