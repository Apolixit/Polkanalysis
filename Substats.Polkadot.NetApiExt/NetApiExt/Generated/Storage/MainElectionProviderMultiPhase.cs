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


namespace Substats.Polkadot.NetApiExt.Generated.Storage
{
    
    
    public sealed class ElectionProviderMultiPhaseStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public ElectionProviderMultiPhaseStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "Round"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "CurrentPhase"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumPhase)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "QueuedSolution"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.ReadySolution)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "Snapshot"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.RoundSnapshot)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "DesiredTargets"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "SnapshotMetadata"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.SolutionOrSnapshotSize)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "SignedSubmissionNextIndex"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "SignedSubmissionIndices"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT27)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "SignedSubmissionsMap"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Ajuna.NetApi.Model.Types.Primitive.U32), typeof(Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.signed.SignedSubmission)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ElectionProviderMultiPhase", "MinimumUntrustedScore"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore)));
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
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> Round(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.RoundParams();
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
            return result;
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
        public async Task<Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumPhase> CurrentPhase(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.CurrentPhaseParams();
            var result = await _client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumPhase>(parameters, token);
            return result;
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
        public async Task<Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.ReadySolution> QueuedSolution(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.QueuedSolutionParams();
            var result = await _client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.ReadySolution>(parameters, token);
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
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "Snapshot", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.RoundSnapshot> Snapshot(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.SnapshotParams();
            var result = await _client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.RoundSnapshot>(parameters, token);
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
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "DesiredTargets", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> DesiredTargets(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.DesiredTargetsParams();
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
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
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "SnapshotMetadata", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.SolutionOrSnapshotSize> SnapshotMetadata(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.SnapshotMetadataParams();
            var result = await _client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.SolutionOrSnapshotSize>(parameters, token);
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
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "SignedSubmissionNextIndex", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> SignedSubmissionNextIndex(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.SignedSubmissionNextIndexParams();
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
            return result;
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
        /// >> SignedSubmissionIndicesDefault
        /// Default value as hex string
        /// </summary>
        public static string SignedSubmissionIndicesDefault()
        {
            return "0x00";
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
        public async Task<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT27> SignedSubmissionIndices(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.SignedSubmissionIndicesParams();
            var result = await _client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT27>(parameters, token);
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
        public static string SignedSubmissionsMapParams(Ajuna.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "SignedSubmissionsMap", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> SignedSubmissionsMapDefault
        /// Default value as hex string
        /// </summary>
        public static string SignedSubmissionsMapDefault()
        {
            return "0x00";
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
        public async Task<Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.signed.SignedSubmission> SignedSubmissionsMap(Ajuna.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.SignedSubmissionsMapParams(key);
            var result = await _client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.signed.SignedSubmission>(parameters, token);
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
            return RequestGenerator.GetStorage("ElectionProviderMultiPhase", "MinimumUntrustedScore", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Substats.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore> MinimumUntrustedScore(CancellationToken token)
        {
            string parameters = ElectionProviderMultiPhaseStorage.MinimumUntrustedScoreParams();
            var result = await _client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore>(parameters, token);
            return result;
        }
    }
    
    public sealed class ElectionProviderMultiPhaseCalls
    {
        
        /// <summary>
        /// >> submit_unsigned
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SubmitUnsigned(Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.RawSolution raw_solution, Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.SolutionOrSnapshotSize witness)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(raw_solution.Encode());
            byteArray.AddRange(witness.Encode());
            return new Method(36, "ElectionProviderMultiPhase", 0, "submit_unsigned", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_minimum_untrusted_score
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetMinimumUntrustedScore(Ajuna.NetApi.Model.Types.Base.BaseOpt<Substats.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore> maybe_next_score)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(maybe_next_score.Encode());
            return new Method(36, "ElectionProviderMultiPhase", 1, "set_minimum_untrusted_score", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_emergency_election_result
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetEmergencyElectionResult(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.Support>> supports)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(supports.Encode());
            return new Method(36, "ElectionProviderMultiPhase", 2, "set_emergency_election_result", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> submit
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Submit(Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.RawSolution raw_solution)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(raw_solution.Encode());
            return new Method(36, "ElectionProviderMultiPhase", 3, "submit", byteArray.ToArray());
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
            return new Method(36, "ElectionProviderMultiPhase", 4, "governance_fallback", byteArray.ToArray());
        }
    }
    
    public sealed class ElectionProviderMultiPhaseConstants
    {
        
        /// <summary>
        /// >> UnsignedPhase
        ///  Duration of the unsigned phase.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 UnsignedPhase()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0x58020000");
            return result;
        }
        
        /// <summary>
        /// >> SignedPhase
        ///  Duration of the signed phase.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 SignedPhase()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0x58020000");
            return result;
        }
        
        /// <summary>
        /// >> BetterSignedThreshold
        ///  The minimum amount of improvement to the solution score that defines a solution as
        ///  "better" in the Signed phase.
        /// </summary>
        public Substats.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill BetterSignedThreshold()
        {
            var result = new Substats.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill();
            result.Create("0x00000000");
            return result;
        }
        
        /// <summary>
        /// >> BetterUnsignedThreshold
        ///  The minimum amount of improvement to the solution score that defines a solution as
        ///  "better" in the Unsigned phase.
        /// </summary>
        public Substats.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill BetterUnsignedThreshold()
        {
            var result = new Substats.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill();
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
        public Ajuna.NetApi.Model.Types.Primitive.U32 OffchainRepeat()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0x12000000");
            return result;
        }
        
        /// <summary>
        /// >> MinerTxPriority
        ///  The priority of the unsigned transaction submitted in the unsigned-phase
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U64 MinerTxPriority()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U64();
            result.Create("0x65666666666666E6");
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
        public Ajuna.NetApi.Model.Types.Primitive.U32 SignedMaxSubmissions()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0x10000000");
            return result;
        }
        
        /// <summary>
        /// >> SignedMaxWeight
        ///  Maximum weight of a signed solution.
        /// 
        ///  If [`Config::MinerConfig`] is being implemented to submit signed solutions (outside of
        ///  this pallet), then [`MinerConfig::solution_weight`] is used to compare against
        ///  this value.
        /// </summary>
        public Substats.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight SignedMaxWeight()
        {
            var result = new Substats.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            result.Create("0x0BC05B07B7560113A3703D0AD7A370BD");
            return result;
        }
        
        /// <summary>
        /// >> SignedMaxRefunds
        ///  The maximum amount of unchecked solutions to refund the call fee for.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 SignedMaxRefunds()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0x04000000");
            return result;
        }
        
        /// <summary>
        /// >> SignedRewardBase
        ///  Base reward for a signed solution
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 SignedRewardBase()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00E40B54020000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> SignedDepositBase
        ///  Base deposit for a signed solution.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 SignedDepositBase()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00A0DB215D0000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> SignedDepositByte
        ///  Per-byte deposit for a signed solution.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 SignedDepositByte()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U128();
            result.Create("0x787D0100000000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> SignedDepositWeight
        ///  Per-weight deposit for a signed solution.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 SignedDepositWeight()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00000000000000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxElectingVoters
        ///  The maximum number of electing voters to put in the snapshot. At the moment, snapshots
        ///  are only over a single block, but once multi-block elections are introduced they will
        ///  take place over multiple blocks.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaxElectingVoters()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0xE4570000");
            return result;
        }
        
        /// <summary>
        /// >> MaxElectableTargets
        ///  The maximum number of electable targets to put in the snapshot.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U16 MaxElectableTargets()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U16();
            result.Create("0xFFFF");
            return result;
        }
        
        /// <summary>
        /// >> MaxWinners
        ///  The maximum number of winners that can be elected by this `ElectionProvider`
        ///  implementation.
        /// 
        ///  Note: This must always be greater or equal to `T::DataProvider::desired_targets()`.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaxWinners()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0xB0040000");
            return result;
        }
        
        /// <summary>
        /// >> MinerMaxLength
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 MinerMaxLength()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00003600");
            return result;
        }
        
        /// <summary>
        /// >> MinerMaxWeight
        /// </summary>
        public Substats.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight MinerMaxWeight()
        {
            var result = new Substats.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            result.Create("0x0BC05B07B7560113A3703D0AD7A370BD");
            return result;
        }
        
        /// <summary>
        /// >> MinerMaxVotesPerVoter
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 MinerMaxVotesPerVoter()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0x10000000");
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
