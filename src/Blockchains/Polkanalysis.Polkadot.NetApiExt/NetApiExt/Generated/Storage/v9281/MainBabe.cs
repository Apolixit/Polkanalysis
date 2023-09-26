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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9281
{
    public sealed class BabeStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> EpochIndexParams
        ///  Current epoch index.
        /// </summary>
        public static string EpochIndexParams()
        {
            return RequestGenerator.GetStorage("Babe", "EpochIndex", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> EpochIndexDefault
        /// Default value as hex string
        /// </summary>
        public static string EpochIndexDefault()
        {
            return "0x0000000000000000";
        }

        /// <summary>
        /// >> EpochIndex
        ///  Current epoch index.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U64> EpochIndex(CancellationToken token)
        {
            string parameters = EpochIndexParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U64>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> AuthoritiesParams
        ///  Current epoch authorities.
        /// </summary>
        public static string AuthoritiesParams()
        {
            return RequestGenerator.GetStorage("Babe", "Authorities", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> AuthoritiesDefault
        /// Default value as hex string
        /// </summary>
        public static string AuthoritiesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Authorities
        ///  Current epoch authorities.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_babe.app.Public, Substrate.NetApi.Model.Types.Primitive.U64>>> Authorities(CancellationToken token)
        {
            string parameters = AuthoritiesParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_babe.app.Public, Substrate.NetApi.Model.Types.Primitive.U64>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> GenesisSlotParams
        ///  The slot at which the first epoch actually started. This is 0
        ///  until the first block of the chain.
        /// </summary>
        public static string GenesisSlotParams()
        {
            return RequestGenerator.GetStorage("Babe", "GenesisSlot", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> GenesisSlotDefault
        /// Default value as hex string
        /// </summary>
        public static string GenesisSlotDefault()
        {
            return "0x0000000000000000";
        }

        /// <summary>
        /// >> GenesisSlot
        ///  The slot at which the first epoch actually started. This is 0
        ///  until the first block of the chain.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_slots.Slot> GenesisSlot(CancellationToken token)
        {
            string parameters = GenesisSlotParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_slots.Slot>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CurrentSlotParams
        ///  Current slot number.
        /// </summary>
        public static string CurrentSlotParams()
        {
            return RequestGenerator.GetStorage("Babe", "CurrentSlot", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CurrentSlotDefault
        /// Default value as hex string
        /// </summary>
        public static string CurrentSlotDefault()
        {
            return "0x0000000000000000";
        }

        /// <summary>
        /// >> CurrentSlot
        ///  Current slot number.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_slots.Slot> CurrentSlot(CancellationToken token)
        {
            string parameters = CurrentSlotParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_slots.Slot>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> RandomnessParams
        ///  The epoch randomness for the *current* epoch.
        /// 
        ///  # Security
        /// 
        ///  This MUST NOT be used for gambling, as it can be influenced by a
        ///  malicious validator in the short term. It MAY be used in many
        ///  cryptographic protocols, however, so long as one remembers that this
        ///  (like everything else on-chain) it is public. For example, it can be
        ///  used where a number is needed that cannot have been chosen by an
        ///  adversary, for purposes such as public-coin zero-knowledge proofs.
        /// </summary>
        public static string RandomnessParams()
        {
            return RequestGenerator.GetStorage("Babe", "Randomness", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> RandomnessDefault
        /// Default value as hex string
        /// </summary>
        public static string RandomnessDefault()
        {
            return "0x0000000000000000000000000000000000000000000000000000000000000000";
        }

        /// <summary>
        /// >> Randomness
        ///  The epoch randomness for the *current* epoch.
        /// 
        ///  # Security
        /// 
        ///  This MUST NOT be used for gambling, as it can be influenced by a
        ///  malicious validator in the short term. It MAY be used in many
        ///  cryptographic protocols, however, so long as one remembers that this
        ///  (like everything else on-chain) it is public. For example, it can be
        ///  used where a number is needed that cannot have been chosen by an
        ///  adversary, for purposes such as public-coin zero-knowledge proofs.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8> Randomness(CancellationToken token)
        {
            string parameters = RandomnessParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PendingEpochConfigChangeParams
        ///  Pending epoch configuration change that will be applied when the next epoch is enacted.
        /// </summary>
        public static string PendingEpochConfigChangeParams()
        {
            return RequestGenerator.GetStorage("Babe", "PendingEpochConfigChange", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> PendingEpochConfigChangeDefault
        /// Default value as hex string
        /// </summary>
        public static string PendingEpochConfigChangeDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> PendingEpochConfigChange
        ///  Pending epoch configuration change that will be applied when the next epoch is enacted.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_babe.digests.EnumNextConfigDescriptor> PendingEpochConfigChange(CancellationToken token)
        {
            string parameters = PendingEpochConfigChangeParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_babe.digests.EnumNextConfigDescriptor>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> NextRandomnessParams
        ///  Next epoch randomness.
        /// </summary>
        public static string NextRandomnessParams()
        {
            return RequestGenerator.GetStorage("Babe", "NextRandomness", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> NextRandomnessDefault
        /// Default value as hex string
        /// </summary>
        public static string NextRandomnessDefault()
        {
            return "0x0000000000000000000000000000000000000000000000000000000000000000";
        }

        /// <summary>
        /// >> NextRandomness
        ///  Next epoch randomness.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8> NextRandomness(CancellationToken token)
        {
            string parameters = NextRandomnessParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> NextAuthoritiesParams
        ///  Next epoch authorities.
        /// </summary>
        public static string NextAuthoritiesParams()
        {
            return RequestGenerator.GetStorage("Babe", "NextAuthorities", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> NextAuthoritiesDefault
        /// Default value as hex string
        /// </summary>
        public static string NextAuthoritiesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> NextAuthorities
        ///  Next epoch authorities.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_babe.app.Public, Substrate.NetApi.Model.Types.Primitive.U64>>> NextAuthorities(CancellationToken token)
        {
            string parameters = NextAuthoritiesParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_babe.app.Public, Substrate.NetApi.Model.Types.Primitive.U64>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SegmentIndexParams
        ///  Randomness under construction.
        /// 
        ///  We make a trade-off between storage accesses and list length.
        ///  We store the under-construction randomness in segments of up to
        ///  `UNDER_CONSTRUCTION_SEGMENT_LENGTH`.
        /// 
        ///  Once a segment reaches this length, we begin the next one.
        ///  We reset all segments and return to `0` at the beginning of every
        ///  epoch.
        /// </summary>
        public static string SegmentIndexParams()
        {
            return RequestGenerator.GetStorage("Babe", "SegmentIndex", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> SegmentIndexDefault
        /// Default value as hex string
        /// </summary>
        public static string SegmentIndexDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> SegmentIndex
        ///  Randomness under construction.
        /// 
        ///  We make a trade-off between storage accesses and list length.
        ///  We store the under-construction randomness in segments of up to
        ///  `UNDER_CONSTRUCTION_SEGMENT_LENGTH`.
        /// 
        ///  Once a segment reaches this length, we begin the next one.
        ///  We reset all segments and return to `0` at the beginning of every
        ///  epoch.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> SegmentIndex(CancellationToken token)
        {
            string parameters = SegmentIndexParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> UnderConstructionParams
        ///  TWOX-NOTE: `SegmentIndex` is an increasing integer, so this is okay.
        /// </summary>
        public static string UnderConstructionParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Babe", "UnderConstruction", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> UnderConstructionDefault
        /// Default value as hex string
        /// </summary>
        public static string UnderConstructionDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> UnderConstruction
        ///  TWOX-NOTE: `SegmentIndex` is an increasing integer, so this is okay.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8>> UnderConstruction(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = UnderConstructionParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> InitializedParams
        ///  Temporary value (cleared at block finalization) which is `Some`
        ///  if per-block initialization has already been called for current block.
        /// </summary>
        public static string InitializedParams()
        {
            return RequestGenerator.GetStorage("Babe", "Initialized", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> InitializedDefault
        /// Default value as hex string
        /// </summary>
        public static string InitializedDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Initialized
        ///  Temporary value (cleared at block finalization) which is `Some`
        ///  if per-block initialization has already been called for current block.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_babe.digests.EnumPreDigest>> Initialized(CancellationToken token)
        {
            string parameters = InitializedParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_babe.digests.EnumPreDigest>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> AuthorVrfRandomnessParams
        ///  This field should always be populated during block processing unless
        ///  secondary plain slots are enabled (which don't contain a VRF output).
        /// 
        ///  It is set in `on_finalize`, before it will contain the value from the last block.
        /// </summary>
        public static string AuthorVrfRandomnessParams()
        {
            return RequestGenerator.GetStorage("Babe", "AuthorVrfRandomness", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> AuthorVrfRandomnessDefault
        /// Default value as hex string
        /// </summary>
        public static string AuthorVrfRandomnessDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> AuthorVrfRandomness
        ///  This field should always be populated during block processing unless
        ///  secondary plain slots are enabled (which don't contain a VRF output).
        /// 
        ///  It is set in `on_finalize`, before it will contain the value from the last block.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8>> AuthorVrfRandomness(CancellationToken token)
        {
            string parameters = AuthorVrfRandomnessParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> EpochStartParams
        ///  The block numbers when the last and current epoch have started, respectively `N-1` and
        ///  `N`.
        ///  NOTE: We track this is in order to annotate the block number when a given pool of
        ///  entropy was fixed (i.e. it was known to chain observers). Since epochs are defined in
        ///  slots, which may be skipped, the block numbers may not line up with the slot numbers.
        /// </summary>
        public static string EpochStartParams()
        {
            return RequestGenerator.GetStorage("Babe", "EpochStart", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> EpochStartDefault
        /// Default value as hex string
        /// </summary>
        public static string EpochStartDefault()
        {
            return "0x0000000000000000";
        }

        /// <summary>
        /// >> EpochStart
        ///  The block numbers when the last and current epoch have started, respectively `N-1` and
        ///  `N`.
        ///  NOTE: We track this is in order to annotate the block number when a given pool of
        ///  entropy was fixed (i.e. it was known to chain observers). Since epochs are defined in
        ///  slots, which may be skipped, the block numbers may not line up with the slot numbers.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> EpochStart(CancellationToken token)
        {
            string parameters = EpochStartParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> LatenessParams
        ///  How late the current block is compared to its parent.
        /// 
        ///  This entry is populated as part of block execution and is cleaned up
        ///  on block finalization. Querying this storage entry outside of block
        ///  execution context should always yield zero.
        /// </summary>
        public static string LatenessParams()
        {
            return RequestGenerator.GetStorage("Babe", "Lateness", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> LatenessDefault
        /// Default value as hex string
        /// </summary>
        public static string LatenessDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> Lateness
        ///  How late the current block is compared to its parent.
        /// 
        ///  This entry is populated as part of block execution and is cleaned up
        ///  on block finalization. Querying this storage entry outside of block
        ///  execution context should always yield zero.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> Lateness(CancellationToken token)
        {
            string parameters = LatenessParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> EpochConfigParams
        ///  The configuration for the current epoch. Should never be `None` as it is initialized in
        ///  genesis.
        /// </summary>
        public static string EpochConfigParams()
        {
            return RequestGenerator.GetStorage("Babe", "EpochConfig", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> EpochConfigDefault
        /// Default value as hex string
        /// </summary>
        public static string EpochConfigDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> EpochConfig
        ///  The configuration for the current epoch. Should never be `None` as it is initialized in
        ///  genesis.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_babe.BabeEpochConfiguration> EpochConfig(CancellationToken token)
        {
            string parameters = EpochConfigParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_babe.BabeEpochConfiguration>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> NextEpochConfigParams
        ///  The configuration for the next epoch, `None` if the config will not change
        ///  (you can fallback to `EpochConfig` instead in that case).
        /// </summary>
        public static string NextEpochConfigParams()
        {
            return RequestGenerator.GetStorage("Babe", "NextEpochConfig", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> NextEpochConfigDefault
        /// Default value as hex string
        /// </summary>
        public static string NextEpochConfigDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> NextEpochConfig
        ///  The configuration for the next epoch, `None` if the config will not change
        ///  (you can fallback to `EpochConfig` instead in that case).
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_babe.BabeEpochConfiguration> NextEpochConfig(CancellationToken token)
        {
            string parameters = NextEpochConfigParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_babe.BabeEpochConfiguration>(parameters, blockHash, token);
            return result;
        }

        public BabeStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class BabeConstants
    {
        /// <summary>
        /// >> EpochDuration
        ///  The amount of time, in slots, that each epoch should last.
        ///  NOTE: Currently it is not possible to change the epoch duration after
        ///  the chain has started. Attempting to do so will brick block production.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 EpochDuration()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0x6009000000000000");
            return result;
        }

        /// <summary>
        /// >> ExpectedBlockTime
        ///  The expected average block time at which BABE should be creating
        ///  blocks. Since BABE is probabilistic it is not trivial to figure out
        ///  what the expected average block time should be based on the slot
        ///  duration and the security parameter `c` (where `1 - c` represents
        ///  the probability of a slot being empty).
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 ExpectedBlockTime()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0x7017000000000000");
            return result;
        }

        /// <summary>
        /// >> MaxAuthorities
        ///  Max number of authorities allowed
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxAuthorities()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xA0860100");
            return result;
        }
    }

    public enum BabeErrors
    {
        /// <summary>
        /// >> InvalidEquivocationProof
        /// An equivocation proof provided as part of an equivocation report is invalid.
        /// </summary>
        InvalidEquivocationProof,
        /// <summary>
        /// >> InvalidKeyOwnershipProof
        /// A key ownership proof provided as part of an equivocation report is invalid.
        /// </summary>
        InvalidKeyOwnershipProof,
        /// <summary>
        /// >> DuplicateOffenceReport
        /// A given equivocation report is valid but already previously reported.
        /// </summary>
        DuplicateOffenceReport,
        /// <summary>
        /// >> InvalidConfiguration
        /// Submitted configuration is invalid.
        /// </summary>
        InvalidConfiguration
    }
}