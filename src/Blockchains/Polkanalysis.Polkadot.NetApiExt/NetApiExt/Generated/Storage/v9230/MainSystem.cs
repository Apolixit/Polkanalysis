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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9230
{
    public sealed class SystemStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> AccountParams
        ///  The full account information for a particular account ID.
        /// </summary>
        public static string AccountParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("System", "Account", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> AccountDefault
        /// Default value as hex string
        /// </summary>
        public static string AccountDefault()
        {
            return "0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        }

        /// <summary>
        /// >> Account
        ///  The full account information for a particular account ID.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.AccountInfo> Account(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = AccountParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.AccountInfo>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ExtrinsicCountParams
        ///  Total extrinsics count for the current block.
        /// </summary>
        public static string ExtrinsicCountParams()
        {
            return RequestGenerator.GetStorage("System", "ExtrinsicCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ExtrinsicCountDefault
        /// Default value as hex string
        /// </summary>
        public static string ExtrinsicCountDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ExtrinsicCount
        ///  Total extrinsics count for the current block.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> ExtrinsicCount(CancellationToken token)
        {
            string parameters = ExtrinsicCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> BlockWeightParams
        ///  The current weight for the block.
        /// </summary>
        public static string BlockWeightParams()
        {
            return RequestGenerator.GetStorage("System", "BlockWeight", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> BlockWeightDefault
        /// Default value as hex string
        /// </summary>
        public static string BlockWeightDefault()
        {
            return "0x000000000000000000000000000000000000000000000000";
        }

        /// <summary>
        /// >> BlockWeight
        ///  The current weight for the block.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_support.weights.PerDispatchClassT1> BlockWeight(CancellationToken token)
        {
            string parameters = BlockWeightParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_support.weights.PerDispatchClassT1>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> AllExtrinsicsLenParams
        ///  Total length (in bytes) for all extrinsics put together, for the current block.
        /// </summary>
        public static string AllExtrinsicsLenParams()
        {
            return RequestGenerator.GetStorage("System", "AllExtrinsicsLen", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> AllExtrinsicsLenDefault
        /// Default value as hex string
        /// </summary>
        public static string AllExtrinsicsLenDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> AllExtrinsicsLen
        ///  Total length (in bytes) for all extrinsics put together, for the current block.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> AllExtrinsicsLen(CancellationToken token)
        {
            string parameters = AllExtrinsicsLenParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> BlockHashParams
        ///  Map of block numbers to block hashes.
        /// </summary>
        public static string BlockHashParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("System", "BlockHash", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> BlockHashDefault
        /// Default value as hex string
        /// </summary>
        public static string BlockHashDefault()
        {
            return "0x0000000000000000000000000000000000000000000000000000000000000000";
        }

        /// <summary>
        /// >> BlockHash
        ///  Map of block numbers to block hashes.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.primitive_types.H256> BlockHash(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = BlockHashParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.primitive_types.H256>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ExtrinsicDataParams
        ///  Extrinsics data for the current block (maps an extrinsic's index to its data).
        /// </summary>
        public static string ExtrinsicDataParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("System", "ExtrinsicData", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ExtrinsicDataDefault
        /// Default value as hex string
        /// </summary>
        public static string ExtrinsicDataDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ExtrinsicData
        ///  Extrinsics data for the current block (maps an extrinsic's index to its data).
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> ExtrinsicData(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ExtrinsicDataParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> NumberParams
        ///  The current block number being processed. Set by `execute_block`.
        /// </summary>
        public static string NumberParams()
        {
            return RequestGenerator.GetStorage("System", "Number", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> NumberDefault
        /// Default value as hex string
        /// </summary>
        public static string NumberDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> Number
        ///  The current block number being processed. Set by `execute_block`.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> Number(CancellationToken token)
        {
            string parameters = NumberParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ParentHashParams
        ///  Hash of the previous block.
        /// </summary>
        public static string ParentHashParams()
        {
            return RequestGenerator.GetStorage("System", "ParentHash", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ParentHashDefault
        /// Default value as hex string
        /// </summary>
        public static string ParentHashDefault()
        {
            return "0x0000000000000000000000000000000000000000000000000000000000000000";
        }

        /// <summary>
        /// >> ParentHash
        ///  Hash of the previous block.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.primitive_types.H256> ParentHash(CancellationToken token)
        {
            string parameters = ParentHashParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.primitive_types.H256>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> DigestParams
        ///  Digest of the current block, also part of the block header.
        /// </summary>
        public static string DigestParams()
        {
            return RequestGenerator.GetStorage("System", "Digest", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> DigestDefault
        /// Default value as hex string
        /// </summary>
        public static string DigestDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Digest
        ///  Digest of the current block, also part of the block header.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_runtime.generic.digest.Digest> Digest(CancellationToken token)
        {
            string parameters = DigestParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_runtime.generic.digest.Digest>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> EventsParams
        ///  Events deposited for the current block.
        /// 
        ///  NOTE: The item is unbound and should therefore never be read on chain.
        ///  It could otherwise inflate the PoV size of a block.
        /// 
        ///  Events have a large in-memory size. Box the events to not go out-of-memory
        ///  just in case someone still reads them from within the runtime.
        /// </summary>
        public static string EventsParams()
        {
            return RequestGenerator.GetStorage("System", "Events", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> EventsDefault
        /// Default value as hex string
        /// </summary>
        public static string EventsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Events
        ///  Events deposited for the current block.
        /// 
        ///  NOTE: The item is unbound and should therefore never be read on chain.
        ///  It could otherwise inflate the PoV size of a block.
        /// 
        ///  Events have a large in-memory size. Box the events to not go out-of-memory
        ///  just in case someone still reads them from within the runtime.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.EventRecord>> Events(CancellationToken token)
        {
            string parameters = EventsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.EventRecord>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> EventCountParams
        ///  The number of events in the `Events<T>` list.
        /// </summary>
        public static string EventCountParams()
        {
            return RequestGenerator.GetStorage("System", "EventCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> EventCountDefault
        /// Default value as hex string
        /// </summary>
        public static string EventCountDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> EventCount
        ///  The number of events in the `Events<T>` list.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> EventCount(CancellationToken token)
        {
            string parameters = EventCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> EventTopicsParams
        ///  Mapping between a topic (represented by T::Hash) and a vector of indexes
        ///  of events in the `<Events<T>>` list.
        /// 
        ///  All topic vectors have deterministic storage locations depending on the topic. This
        ///  allows light-clients to leverage the changes trie storage tracking mechanism and
        ///  in case of changes fetch the list of events of interest.
        /// 
        ///  The value has the type `(T::BlockNumber, EventIndex)` because if we used only just
        ///  the `EventIndex` then in case if the topic has the same contents on the next block
        ///  no notification will be triggered thus the event might be lost.
        /// </summary>
        public static string EventTopicsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("System", "EventTopics", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> EventTopicsDefault
        /// Default value as hex string
        /// </summary>
        public static string EventTopicsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> EventTopics
        ///  Mapping between a topic (represented by T::Hash) and a vector of indexes
        ///  of events in the `<Events<T>>` list.
        /// 
        ///  All topic vectors have deterministic storage locations depending on the topic. This
        ///  allows light-clients to leverage the changes trie storage tracking mechanism and
        ///  in case of changes fetch the list of events of interest.
        /// 
        ///  The value has the type `(T::BlockNumber, EventIndex)` because if we used only just
        ///  the `EventIndex` then in case if the topic has the same contents on the next block
        ///  no notification will be triggered thus the event might be lost.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>> EventTopics(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = EventTopicsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> LastRuntimeUpgradeParams
        ///  Stores the `spec_version` and `spec_name` of when the last runtime upgrade happened.
        /// </summary>
        public static string LastRuntimeUpgradeParams()
        {
            return RequestGenerator.GetStorage("System", "LastRuntimeUpgrade", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> LastRuntimeUpgradeDefault
        /// Default value as hex string
        /// </summary>
        public static string LastRuntimeUpgradeDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> LastRuntimeUpgrade
        ///  Stores the `spec_version` and `spec_name` of when the last runtime upgrade happened.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.LastRuntimeUpgradeInfo> LastRuntimeUpgrade(CancellationToken token)
        {
            string parameters = LastRuntimeUpgradeParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.LastRuntimeUpgradeInfo>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> UpgradedToU32RefCountParams
        ///  True if we have upgraded so that `type RefCount` is `u32`. False (default) if not.
        /// </summary>
        public static string UpgradedToU32RefCountParams()
        {
            return RequestGenerator.GetStorage("System", "UpgradedToU32RefCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> UpgradedToU32RefCountDefault
        /// Default value as hex string
        /// </summary>
        public static string UpgradedToU32RefCountDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> UpgradedToU32RefCount
        ///  True if we have upgraded so that `type RefCount` is `u32`. False (default) if not.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> UpgradedToU32RefCount(CancellationToken token)
        {
            string parameters = UpgradedToU32RefCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> UpgradedToTripleRefCountParams
        ///  True if we have upgraded so that AccountInfo contains three types of `RefCount`. False
        ///  (default) if not.
        /// </summary>
        public static string UpgradedToTripleRefCountParams()
        {
            return RequestGenerator.GetStorage("System", "UpgradedToTripleRefCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> UpgradedToTripleRefCountDefault
        /// Default value as hex string
        /// </summary>
        public static string UpgradedToTripleRefCountDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> UpgradedToTripleRefCount
        ///  True if we have upgraded so that AccountInfo contains three types of `RefCount`. False
        ///  (default) if not.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> UpgradedToTripleRefCount(CancellationToken token)
        {
            string parameters = UpgradedToTripleRefCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ExecutionPhaseParams
        ///  The execution phase of the block.
        /// </summary>
        public static string ExecutionPhaseParams()
        {
            return RequestGenerator.GetStorage("System", "ExecutionPhase", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ExecutionPhaseDefault
        /// Default value as hex string
        /// </summary>
        public static string ExecutionPhaseDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ExecutionPhase
        ///  The execution phase of the block.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.EnumPhase> ExecutionPhase(CancellationToken token)
        {
            string parameters = ExecutionPhaseParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.EnumPhase>(parameters, blockHash, token);
            return result;
        }

        public SystemStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class SystemConstants
    {
        /// <summary>
        /// >> BlockWeights
        ///  Block & extrinsics weights: base values and limits.
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.limits.BlockWeights BlockWeights()
        {
            var result = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.limits.BlockWeights();
            result.Create("0x40E3D0410100000000204AA9D1010000603B14050000000001A094CB9158010000010098F73E5D010000010000000000000000603B14050000000001A01C1EFCCC0100000100204AA9D1010000010088526A74000000603B140500000000000000");
            return result;
        }

        /// <summary>
        /// >> BlockLength
        ///  The maximum length of a block (in bytes).
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.limits.BlockLength BlockLength()
        {
            var result = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.limits.BlockLength();
            result.Create("0x00003C000000500000005000");
            return result;
        }

        /// <summary>
        /// >> BlockHashCount
        ///  Maximum number of block number to block hash mappings to keep (oldest pruned first).
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 BlockHashCount()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x60090000");
            return result;
        }

        /// <summary>
        /// >> DbWeight
        ///  The weight of runtime database operations the runtime can invoke.
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_support.weights.RuntimeDbWeight DbWeight()
        {
            var result = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_support.weights.RuntimeDbWeight();
            result.Create("0x38CA38010000000098AAF90400000000");
            return result;
        }

        /// <summary>
        /// >> Version
        ///  Get the chain's current version.
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_version.RuntimeVersion Version()
        {
            var result = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_version.RuntimeVersion();
            result.Create("0x20706F6C6B61646F743C7061726974792D706F6C6B61646F74000000000E2400000000000038DF6ACB689907609B0400000037E397FC7C91F5E40100000040FE3AD401F8959A06000000D2BC9897EED08F1503000000F78B278BE53F454C02000000AF2C0297A23E6D3D0200000049EAAF1B548A0CB00100000091D5DF18B0D2CF5801000000ED99C5ACB25EEDF503000000CBCA25E39F14238702000000687AD44AD37F03C201000000AB3C0572291FEB8B01000000BC9D89904F5B923F0100000037C8BB1350A9A2A8010000000C00000000");
            return result;
        }

        /// <summary>
        /// >> SS58Prefix
        ///  The designated SS85 prefix of this chain.
        /// 
        ///  This replaces the "ss58Format" property declared in the chain spec. Reason is
        ///  that the runtime should know about the prefix in order to make use of it as
        ///  an identifier of the chain.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U16 SS58Prefix()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U16();
            result.Create("0x0000");
            return result;
        }
    }

    public enum SystemErrors
    {
        /// <summary>
        /// >> InvalidSpecName
        /// The name of specification does not match between the current runtime
        /// and the new runtime.
        /// </summary>
        InvalidSpecName,
        /// <summary>
        /// >> SpecVersionNeedsToIncrease
        /// The specification version is not allowed to decrease between the current runtime
        /// and the new runtime.
        /// </summary>
        SpecVersionNeedsToIncrease,
        /// <summary>
        /// >> FailedToExtractRuntimeVersion
        /// Failed to extract the runtime version from the new runtime.
        /// 
        /// Either calling `Core_version` or decoding `RuntimeVersion` failed.
        /// </summary>
        FailedToExtractRuntimeVersion,
        /// <summary>
        /// >> NonDefaultComposite
        /// Suicide called when the account has non-default composite data.
        /// </summary>
        NonDefaultComposite,
        /// <summary>
        /// >> NonZeroRefCount
        /// There is a non-zero reference count preventing the account from being purged.
        /// </summary>
        NonZeroRefCount,
        /// <summary>
        /// >> CallFiltered
        /// The origin filter prevent the call to be dispatched.
        /// </summary>
        CallFiltered
    }
}