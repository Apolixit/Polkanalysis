//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage
{
    
    
    public sealed class ElectionProviderMultiPhaseStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public ElectionProviderMultiPhaseStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "Round"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "CurrentPhase"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumPhase)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "QueuedSolution"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.ReadySolution)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "Snapshot"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.RoundSnapshot)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "DesiredTargets"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "SnapshotMetadata"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.SolutionOrSnapshotSize)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "SignedSubmissionNextIndex"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "SignedSubmissionIndices"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT33)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "SignedSubmissionsMap"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Ajuna.NetApi.Model.Types.Primitive.U32), typeof(Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.signed.SignedSubmission)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "MinimumUntrustedScore"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore)));
        }
        
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
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "Round", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> Round(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.RoundParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
        }
        
        /// <summary>
        /// >> CurrentPhaseParams
        ///  Current phase.
        /// </summary>
        public static string CurrentPhaseParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "CurrentPhase", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> CurrentPhase
        ///  Current phase.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumPhase> CurrentPhase(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.CurrentPhaseParams();
            return await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumPhase>(parameters, token);
        }
        
        /// <summary>
        /// >> QueuedSolutionParams
        ///  Current best solution, signed or unsigned, queued to be returned upon `elect`.
        /// </summary>
        public static string QueuedSolutionParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "QueuedSolution", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> QueuedSolution
        ///  Current best solution, signed or unsigned, queued to be returned upon `elect`.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.ReadySolution> QueuedSolution(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.QueuedSolutionParams();
            return await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.ReadySolution>(parameters, token);
        }
        
        /// <summary>
        /// >> SnapshotParams
        ///  Snapshot data of the round.
        /// 
        ///  This is created at the beginning of the signed phase and cleared upon calling `elect`.
        /// </summary>
        public static string SnapshotParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "Snapshot", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> Snapshot
        ///  Snapshot data of the round.
        /// 
        ///  This is created at the beginning of the signed phase and cleared upon calling `elect`.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.RoundSnapshot> Snapshot(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.SnapshotParams();
            return await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.RoundSnapshot>(parameters, token);
        }
        
        /// <summary>
        /// >> DesiredTargetsParams
        ///  Desired number of targets to elect for this round.
        /// 
        ///  Only exists when [`Snapshot`] is present.
        /// </summary>
        public static string DesiredTargetsParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "DesiredTargets", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> DesiredTargets
        ///  Desired number of targets to elect for this round.
        /// 
        ///  Only exists when [`Snapshot`] is present.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> DesiredTargets(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.DesiredTargetsParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
        }
        
        /// <summary>
        /// >> SnapshotMetadataParams
        ///  The metadata of the [`RoundSnapshot`]
        /// 
        ///  Only exists when [`Snapshot`] is present.
        /// </summary>
        public static string SnapshotMetadataParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "SnapshotMetadata", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> SnapshotMetadata
        ///  The metadata of the [`RoundSnapshot`]
        /// 
        ///  Only exists when [`Snapshot`] is present.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.SolutionOrSnapshotSize> SnapshotMetadata(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.SnapshotMetadataParams();
            return await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.SolutionOrSnapshotSize>(parameters, token);
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
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "SignedSubmissionNextIndex", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> SignedSubmissionNextIndex(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.SignedSubmissionNextIndexParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
        }
        
        /// <summary>
        /// >> SignedSubmissionIndicesParams
        ///  A sorted, bounded vector of `(score, block_number, index)`, where each `index` points to a
        ///  value in `SignedSubmissions`.
        /// 
        ///  We never need to process more than a single signed submission at a time. Signed submissions
        ///  can be quite large, so we're willing to pay the cost of multiple database accesses to access
        ///  them one at a time instead of reading and decoding all of them at once.
        /// </summary>
        public static string SignedSubmissionIndicesParams()
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "SignedSubmissionIndices", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> SignedSubmissionIndices
        ///  A sorted, bounded vector of `(score, block_number, index)`, where each `index` points to a
        ///  value in `SignedSubmissions`.
        /// 
        ///  We never need to process more than a single signed submission at a time. Signed submissions
        ///  can be quite large, so we're willing to pay the cost of multiple database accesses to access
        ///  them one at a time instead of reading and decoding all of them at once.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT33> SignedSubmissionIndices(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.SignedSubmissionIndicesParams();
            return await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT33>(parameters, token);
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
        public static string SignedSubmissionsMapParams(Ajuna.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "SignedSubmissionsMap", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
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
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.signed.SignedSubmission> SignedSubmissionsMap(Ajuna.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.SignedSubmissionsMapParams(key);
            return await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.signed.SignedSubmission>(parameters, token);
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
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "MinimumUntrustedScore", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> MinimumUntrustedScore
        ///  The minimum score that each 'untrusted' solution must attain in order to be considered
        ///  feasible.
        /// 
        ///  Can be set via `set_minimum_untrusted_score`.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore> MinimumUntrustedScore(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.MinimumUntrustedScoreParams();
            return await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore>(parameters, token);
        }
    }
    
    public sealed class ElectionProviderMultiPhaseCalls
    {
        
        /// <summary>
        /// >> submit_unsigned
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SubmitUnsigned(Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.RawSolution raw_solution, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.SolutionOrSnapshotSize witness)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(raw_solution.Encode());
            byteArray.AddRange(witness.Encode());
            return new Method(37, "ElectionProviderMultiPhase", 0, "submit_unsigned", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_minimum_untrusted_score
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetMinimumUntrustedScore(Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore> maybe_next_score)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(maybe_next_score.Encode());
            return new Method(37, "ElectionProviderMultiPhase", 1, "set_minimum_untrusted_score", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_emergency_election_result
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetEmergencyElectionResult(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_npos_elections.Support>> supports)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(supports.Encode());
            return new Method(37, "ElectionProviderMultiPhase", 2, "set_emergency_election_result", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> submit
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Submit(Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.RawSolution raw_solution)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(raw_solution.Encode());
            return new Method(37, "ElectionProviderMultiPhase", 3, "submit", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> governance_fallback
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method GovernanceFallback(Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U32> maybe_max_voters, Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U32> maybe_max_targets)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(maybe_max_voters.Encode());
            byteArray.AddRange(maybe_max_targets.Encode());
            return new Method(37, "ElectionProviderMultiPhase", 4, "governance_fallback", byteArray.ToArray());
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
        CallNotAllowed,
        
        /// <summary>
        /// >> FallbackFailed
        /// The fallback failed
        /// </summary>
        FallbackFailed,
        
        /// <summary>
        /// >> BoundNotMet
        /// Some bound not met
        /// </summary>
        BoundNotMet,
        
        /// <summary>
        /// >> TooManyWinners
        /// Submitted solution has too many winners
        /// </summary>
        TooManyWinners,
    }
}