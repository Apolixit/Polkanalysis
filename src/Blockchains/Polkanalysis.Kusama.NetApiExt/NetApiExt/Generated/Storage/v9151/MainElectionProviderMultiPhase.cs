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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9151
{
    public sealed class ElectionProviderMultiPhaseStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> RoundParams
        ///  Internal counter for the number of rounds.
        /// 
        ///  This is useful for de-duplication of transactions submitted to the pool, and general
        ///  diagnostics of the pallet.
        /// 
        ///  This is merely incremented once per every time that an upstream `elect` is called.
        /// </summary>
        public static string RoundParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "Round", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> RoundDefault
        /// Default value as hex string
        /// </summary>
        public static string RoundDefault()
        {
            return "0x01000000";
        }

        /// <summary>
        /// >> Round
        ///  Internal counter for the number of rounds.
        /// 
        ///  This is useful for de-duplication of transactions submitted to the pool, and general
        ///  diagnostics of the pallet.
        /// 
        ///  This is merely incremented once per every time that an upstream `elect` is called.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> Round(CancellationToken token)
        {
            string parameters = RoundParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CurrentPhaseParams
        ///  Current phase.
        /// </summary>
        public static string CurrentPhaseParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "CurrentPhase", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CurrentPhaseDefault
        /// Default value as hex string
        /// </summary>
        public static string CurrentPhaseDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> CurrentPhase
        ///  Current phase.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.pallet_election_provider_multi_phase.EnumPhase> CurrentPhase(CancellationToken token)
        {
            string parameters = CurrentPhaseParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.pallet_election_provider_multi_phase.EnumPhase>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> QueuedSolutionParams
        ///  Current best solution, signed or unsigned, queued to be returned upon `elect`.
        /// </summary>
        public static string QueuedSolutionParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "QueuedSolution", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> QueuedSolutionDefault
        /// Default value as hex string
        /// </summary>
        public static string QueuedSolutionDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> QueuedSolution
        ///  Current best solution, signed or unsigned, queued to be returned upon `elect`.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.pallet_election_provider_multi_phase.ReadySolution> QueuedSolution(CancellationToken token)
        {
            string parameters = QueuedSolutionParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.pallet_election_provider_multi_phase.ReadySolution>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SnapshotParams
        ///  Snapshot data of the round.
        /// 
        ///  This is created at the beginning of the signed phase and cleared upon calling `elect`.
        /// </summary>
        public static string SnapshotParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "Snapshot", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> SnapshotDefault
        /// Default value as hex string
        /// </summary>
        public static string SnapshotDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Snapshot
        ///  Snapshot data of the round.
        /// 
        ///  This is created at the beginning of the signed phase and cleared upon calling `elect`.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.pallet_election_provider_multi_phase.RoundSnapshot> Snapshot(CancellationToken token)
        {
            string parameters = SnapshotParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.pallet_election_provider_multi_phase.RoundSnapshot>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> DesiredTargetsParams
        ///  Desired number of targets to elect for this round.
        /// 
        ///  Only exists when [`Snapshot`] is present.
        /// </summary>
        public static string DesiredTargetsParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "DesiredTargets", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> DesiredTargetsDefault
        /// Default value as hex string
        /// </summary>
        public static string DesiredTargetsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> DesiredTargets
        ///  Desired number of targets to elect for this round.
        /// 
        ///  Only exists when [`Snapshot`] is present.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> DesiredTargets(CancellationToken token)
        {
            string parameters = DesiredTargetsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SnapshotMetadataParams
        ///  The metadata of the [`RoundSnapshot`]
        /// 
        ///  Only exists when [`Snapshot`] is present.
        /// </summary>
        public static string SnapshotMetadataParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "SnapshotMetadata", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> SnapshotMetadataDefault
        /// Default value as hex string
        /// </summary>
        public static string SnapshotMetadataDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> SnapshotMetadata
        ///  The metadata of the [`RoundSnapshot`]
        /// 
        ///  Only exists when [`Snapshot`] is present.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.pallet_election_provider_multi_phase.SolutionOrSnapshotSize> SnapshotMetadata(CancellationToken token)
        {
            string parameters = SnapshotMetadataParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.pallet_election_provider_multi_phase.SolutionOrSnapshotSize>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SignedSubmissionNextIndexParams
        ///  The next index to be assigned to an incoming signed submission.
        /// 
        ///  Every accepted submission is assigned a unique index; that index is bound to that particular
        ///  submission for the duration of the election. On election finalization, the next index is
        ///  reset to 0.
        /// 
        ///  We can't just use `SignedSubmissionIndices.len()`, because that's a bounded set; past its
        ///  capacity, it will simply saturate. We can't just iterate over `SignedSubmissionsMap`,
        ///  because iteration is slow. Instead, we store the value here.
        /// </summary>
        public static string SignedSubmissionNextIndexParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "SignedSubmissionNextIndex", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> SignedSubmissionNextIndexDefault
        /// Default value as hex string
        /// </summary>
        public static string SignedSubmissionNextIndexDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> SignedSubmissionNextIndex
        ///  The next index to be assigned to an incoming signed submission.
        /// 
        ///  Every accepted submission is assigned a unique index; that index is bound to that particular
        ///  submission for the duration of the election. On election finalization, the next index is
        ///  reset to 0.
        /// 
        ///  We can't just use `SignedSubmissionIndices.len()`, because that's a bounded set; past its
        ///  capacity, it will simply saturate. We can't just iterate over `SignedSubmissionsMap`,
        ///  because iteration is slow. Instead, we store the value here.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> SignedSubmissionNextIndex(CancellationToken token)
        {
            string parameters = SignedSubmissionNextIndexParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SignedSubmissionIndicesParams
        ///  A sorted, bounded set of `(score, index)`, where each `index` points to a value in
        ///  `SignedSubmissions`.
        /// 
        ///  We never need to process more than a single signed submission at a time. Signed submissions
        ///  can be quite large, so we're willing to pay the cost of multiple database accesses to access
        ///  them one at a time instead of reading and decoding all of them at once.
        /// </summary>
        public static string SignedSubmissionIndicesParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "SignedSubmissionIndices", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> SignedSubmissionIndicesDefault
        /// Default value as hex string
        /// </summary>
        public static string SignedSubmissionIndicesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> SignedSubmissionIndices
        ///  A sorted, bounded set of `(score, index)`, where each `index` points to a value in
        ///  `SignedSubmissions`.
        /// 
        ///  We never need to process more than a single signed submission at a time. Signed submissions
        ///  can be quite large, so we're willing to pay the cost of multiple database accesses to access
        ///  them one at a time instead of reading and decoding all of them at once.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.frame_support.storage.bounded_btree_map.BoundedBTreeMap> SignedSubmissionIndices(CancellationToken token)
        {
            string parameters = SignedSubmissionIndicesParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.frame_support.storage.bounded_btree_map.BoundedBTreeMap>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SignedSubmissionsMapParams
        ///  Unchecked, signed solutions.
        /// 
        ///  Together with `SubmissionIndices`, this stores a bounded set of `SignedSubmissions` while
        ///  allowing us to keep only a single one in memory at a time.
        /// 
        ///  Twox note: the key of the map is an auto-incrementing index which users cannot inspect or
        ///  affect; we shouldn't need a cryptographically secure hasher.
        /// </summary>
        public static string SignedSubmissionsMapParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "SignedSubmissionsMap", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> SignedSubmissionsMapDefault
        /// Default value as hex string
        /// </summary>
        public static string SignedSubmissionsMapDefault()
        {
            return "0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000000000000000000000000000000000000";
        }

        /// <summary>
        /// >> SignedSubmissionsMap
        ///  Unchecked, signed solutions.
        /// 
        ///  Together with `SubmissionIndices`, this stores a bounded set of `SignedSubmissions` while
        ///  allowing us to keep only a single one in memory at a time.
        /// 
        ///  Twox note: the key of the map is an auto-incrementing index which users cannot inspect or
        ///  affect; we shouldn't need a cryptographically secure hasher.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.pallet_election_provider_multi_phase.signed.SignedSubmission> SignedSubmissionsMap(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = SignedSubmissionsMapParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.pallet_election_provider_multi_phase.signed.SignedSubmission>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> MinimumUntrustedScoreParams
        ///  The minimum score that each 'untrusted' solution must attain in order to be considered
        ///  feasible.
        /// 
        ///  Can be set via `set_minimum_untrusted_score`.
        /// </summary>
        public static string MinimumUntrustedScoreParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "MinimumUntrustedScore", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> MinimumUntrustedScoreDefault
        /// Default value as hex string
        /// </summary>
        public static string MinimumUntrustedScoreDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> MinimumUntrustedScore
        ///  The minimum score that each 'untrusted' solution must attain in order to be considered
        ///  feasible.
        /// 
        ///  Can be set via `set_minimum_untrusted_score`.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr3U128> MinimumUntrustedScore(CancellationToken token)
        {
            string parameters = MinimumUntrustedScoreParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr3U128>(parameters, blockHash, token);
            return result;
        }

        public ElectionProviderMultiPhaseStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class ElectionProviderMultiPhaseConstants
    {
        /// <summary>
        /// >> UnsignedPhase
        ///  Duration of the unsigned phase.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 UnsignedPhase()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x96000000");
            return result;
        }

        /// <summary>
        /// >> SignedPhase
        ///  Duration of the signed phase.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 SignedPhase()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x96000000");
            return result;
        }

        /// <summary>
        /// >> SolutionImprovementThreshold
        ///  The minimum amount of improvement to the solution score that defines a solution as
        ///  "better" (in any phase).
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.sp_arithmetic.per_things.Perbill SolutionImprovementThreshold()
        {
            var result = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.sp_arithmetic.per_things.Perbill();
            result.Create("0x20A10700");
            return result;
        }

        /// <summary>
        /// >> OffchainRepeat
        ///  The repeat threshold of the offchain worker.
        /// 
        ///  For example, if it is 5, that means that at least 5 blocks will elapse between attempts
        ///  to submit the worker's solution.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 OffchainRepeat()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x12000000");
            return result;
        }

        /// <summary>
        /// >> MinerTxPriority
        ///  The priority of the unsigned transaction submitted in the unsigned-phase
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 MinerTxPriority()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0x65666666666666E6");
            return result;
        }

        /// <summary>
        /// >> MinerMaxWeight
        ///  Maximum weight that the miner should consume.
        /// 
        ///  The miner will ensure that the total weight of the unsigned solution will not exceed
        ///  this value, based on [`WeightInfo::submit_unsigned`].
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 MinerMaxWeight()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0xC084666557010000");
            return result;
        }

        /// <summary>
        /// >> SignedMaxSubmissions
        ///  Maximum number of signed submissions that can be queued.
        /// 
        ///  It is best to avoid adjusting this during an election, as it impacts downstream data
        ///  structures. In particular, `SignedSubmissionIndices<T>` is bounded on this value. If you
        ///  update this value during an election, you _must_ ensure that
        ///  `SignedSubmissionIndices.len()` is less than or equal to the new value. Otherwise,
        ///  attempts to submit new solutions may cause a runtime panic.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 SignedMaxSubmissions()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x10000000");
            return result;
        }

        /// <summary>
        /// >> SignedMaxWeight
        ///  Maximum weight of a signed solution.
        /// 
        ///  This should probably be similar to [`Config::MinerMaxWeight`].
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 SignedMaxWeight()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0xC084666557010000");
            return result;
        }

        /// <summary>
        /// >> SignedRewardBase
        ///  Base reward for a signed solution
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 SignedRewardBase()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00E87648170000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> SignedDepositBase
        ///  Base deposit for a signed solution.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 SignedDepositBase()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x2030490B1F0000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> SignedDepositByte
        ///  Per-byte deposit for a signed solution.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 SignedDepositByte()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x277F0000000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> SignedDepositWeight
        ///  Per-weight deposit for a signed solution.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 SignedDepositWeight()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00000000000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> VoterSnapshotPerBlock
        ///  The maximum number of voters to put in the snapshot. At the moment, snapshots are only
        ///  over a single block, but once multi-block elections are introduced they will take place
        ///  over multiple blocks.
        /// 
        ///  Also, note the data type: If the voters are represented by a `u32` in `type
        ///  CompactSolution`, the same `u32` is used here to ensure bounds are respected.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 VoterSnapshotPerBlock()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xE4570000");
            return result;
        }

        /// <summary>
        /// >> MinerMaxLength
        ///  Maximum length (bytes) that the mined solution should consume.
        /// 
        ///  The miner will ensure that the total length of the unsigned solution will not exceed
        ///  this value.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MinerMaxLength()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00003600");
            return result;
        }
    }

    public enum ElectionProviderMultiPhaseErrors
    {
        /// <summary>
        /// >> PreDispatchEarlySubmission
        /// Submission was too early.
        /// </summary>
        PreDispatchEarlySubmission,
        /// <summary>
        /// >> PreDispatchWrongWinnerCount
        /// Wrong number of winners presented.
        /// </summary>
        PreDispatchWrongWinnerCount,
        /// <summary>
        /// >> PreDispatchWeakSubmission
        /// Submission was too weak, score-wise.
        /// </summary>
        PreDispatchWeakSubmission,
        /// <summary>
        /// >> SignedQueueFull
        /// The queue was full, and the solution was not better than any of the existing ones.
        /// </summary>
        SignedQueueFull,
        /// <summary>
        /// >> SignedCannotPayDeposit
        /// The origin failed to pay the deposit.
        /// </summary>
        SignedCannotPayDeposit,
        /// <summary>
        /// >> SignedInvalidWitness
        /// Witness data to dispatchable is invalid.
        /// </summary>
        SignedInvalidWitness,
        /// <summary>
        /// >> SignedTooMuchWeight
        /// The signed submission consumes too much weight
        /// </summary>
        SignedTooMuchWeight,
        /// <summary>
        /// >> OcwCallWrongEra
        /// OCW submitted solution for wrong round
        /// </summary>
        OcwCallWrongEra,
        /// <summary>
        /// >> MissingSnapshotMetadata
        /// Snapshot metadata should exist but didn't.
        /// </summary>
        MissingSnapshotMetadata,
        /// <summary>
        /// >> InvalidSubmissionIndex
        /// `Self::insert_submission` returned an invalid index.
        /// </summary>
        InvalidSubmissionIndex,
        /// <summary>
        /// >> CallNotAllowed
        /// The call is not allowed at this point.
        /// </summary>
        CallNotAllowed
    }
}