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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Storage
{
    
    
    public sealed class ParachainSystemStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public ParachainSystemStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "PendingValidationCode"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "NewValidationCode"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "ValidationData"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.PersistedValidationData)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "DidSetValidationCode"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.Bool)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "LastRelayChainBlockNumber"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "UpgradeRestrictionSignal"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.EnumUpgradeRestriction>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "RelayStateProof"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_trie.storage_proof.StorageProof)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "RelevantMessagingState"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_pallet_parachain_system.relay_state_snapshot.MessagingStateSnapshot)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "HostConfiguration"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.AbridgedHostConfiguration)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "LastDmqMqcHead"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_primitives_parachain_inherent.MessageQueueChain)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "LastHrmpMqcHeads"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Bajun.NetApiExt.Generated.Types.Base.BTreeMapT1)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "ProcessedDownwardMessages"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "HrmpWatermark"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "HrmpOutboundMessages"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_core_primitives.OutboundHrmpMessage>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "UpwardMessages"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "PendingUpwardMessages"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "AnnouncedHrmpMessagesPerCandidate"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "ReservedXcmpWeightOverride"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U64)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "ReservedDmpWeightOverride"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U64)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "AuthorizedUpgrade"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainSystem", "CustomValidationHeadData"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>)));
        }
        
        /// <summary>
        /// >> PendingValidationCodeParams
        ///  In case of a scheduled upgrade, this storage field contains the validation code to be applied.
        /// 
        ///  As soon as the relay chain gives us the go-ahead signal, we will overwrite the [`:code`][well_known_keys::CODE]
        ///  which will result the next block process with the new validation code. This concludes the upgrade process.
        /// 
        ///  [well_known_keys::CODE]: sp_core::storage::well_known_keys::CODE
        /// </summary>
        public static string PendingValidationCodeParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "PendingValidationCode", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> PendingValidationCode
        ///  In case of a scheduled upgrade, this storage field contains the validation code to be applied.
        /// 
        ///  As soon as the relay chain gives us the go-ahead signal, we will overwrite the [`:code`][well_known_keys::CODE]
        ///  which will result the next block process with the new validation code. This concludes the upgrade process.
        /// 
        ///  [well_known_keys::CODE]: sp_core::storage::well_known_keys::CODE
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> PendingValidationCode(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.PendingValidationCodeParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>(parameters, token);
        }
        
        /// <summary>
        /// >> NewValidationCodeParams
        ///  Validation code that is set by the parachain and is to be communicated to collator and
        ///  consequently the relay-chain.
        /// 
        ///  This will be cleared in `on_initialize` of each new block if no other pallet already set
        ///  the value.
        /// </summary>
        public static string NewValidationCodeParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "NewValidationCode", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> NewValidationCode
        ///  Validation code that is set by the parachain and is to be communicated to collator and
        ///  consequently the relay-chain.
        /// 
        ///  This will be cleared in `on_initialize` of each new block if no other pallet already set
        ///  the value.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> NewValidationCode(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.NewValidationCodeParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>(parameters, token);
        }
        
        /// <summary>
        /// >> ValidationDataParams
        ///  The [`PersistedValidationData`] set for this block.
        ///  This value is expected to be set only once per block and it's never stored
        ///  in the trie.
        /// </summary>
        public static string ValidationDataParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "ValidationData", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> ValidationData
        ///  The [`PersistedValidationData`] set for this block.
        ///  This value is expected to be set only once per block and it's never stored
        ///  in the trie.
        /// </summary>
        public async Task<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.PersistedValidationData> ValidationData(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.ValidationDataParams();
            return await _client.GetStorageAsync<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.PersistedValidationData>(parameters, token);
        }
        
        /// <summary>
        /// >> DidSetValidationCodeParams
        ///  Were the validation data set to notify the relay chain?
        /// </summary>
        public static string DidSetValidationCodeParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "DidSetValidationCode", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> DidSetValidationCode
        ///  Were the validation data set to notify the relay chain?
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.Bool> DidSetValidationCode(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.DidSetValidationCodeParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.Bool>(parameters, token);
        }
        
        /// <summary>
        /// >> LastRelayChainBlockNumberParams
        ///  The relay chain block number associated with the last parachain block.
        /// </summary>
        public static string LastRelayChainBlockNumberParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "LastRelayChainBlockNumber", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> LastRelayChainBlockNumber
        ///  The relay chain block number associated with the last parachain block.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> LastRelayChainBlockNumber(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.LastRelayChainBlockNumberParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
        }
        
        /// <summary>
        /// >> UpgradeRestrictionSignalParams
        ///  An option which indicates if the relay-chain restricts signalling a validation code upgrade.
        ///  In other words, if this is `Some` and [`NewValidationCode`] is `Some` then the produced
        ///  candidate will be invalid.
        /// 
        ///  This storage item is a mirror of the corresponding value for the current parachain from the
        ///  relay-chain. This value is ephemeral which means it doesn't hit the storage. This value is
        ///  set after the inherent.
        /// </summary>
        public static string UpgradeRestrictionSignalParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "UpgradeRestrictionSignal", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> UpgradeRestrictionSignal
        ///  An option which indicates if the relay-chain restricts signalling a validation code upgrade.
        ///  In other words, if this is `Some` and [`NewValidationCode`] is `Some` then the produced
        ///  candidate will be invalid.
        /// 
        ///  This storage item is a mirror of the corresponding value for the current parachain from the
        ///  relay-chain. This value is ephemeral which means it doesn't hit the storage. This value is
        ///  set after the inherent.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.EnumUpgradeRestriction>> UpgradeRestrictionSignal(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.UpgradeRestrictionSignalParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.EnumUpgradeRestriction>>(parameters, token);
        }
        
        /// <summary>
        /// >> RelayStateProofParams
        ///  The state proof for the last relay parent block.
        /// 
        ///  This field is meant to be updated each block with the validation data inherent. Therefore,
        ///  before processing of the inherent, e.g. in `on_initialize` this data may be stale.
        /// 
        ///  This data is also absent from the genesis.
        /// </summary>
        public static string RelayStateProofParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "RelayStateProof", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> RelayStateProof
        ///  The state proof for the last relay parent block.
        /// 
        ///  This field is meant to be updated each block with the validation data inherent. Therefore,
        ///  before processing of the inherent, e.g. in `on_initialize` this data may be stale.
        /// 
        ///  This data is also absent from the genesis.
        /// </summary>
        public async Task<Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_trie.storage_proof.StorageProof> RelayStateProof(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.RelayStateProofParams();
            return await _client.GetStorageAsync<Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_trie.storage_proof.StorageProof>(parameters, token);
        }
        
        /// <summary>
        /// >> RelevantMessagingStateParams
        ///  The snapshot of some state related to messaging relevant to the current parachain as per
        ///  the relay parent.
        /// 
        ///  This field is meant to be updated each block with the validation data inherent. Therefore,
        ///  before processing of the inherent, e.g. in `on_initialize` this data may be stale.
        /// 
        ///  This data is also absent from the genesis.
        /// </summary>
        public static string RelevantMessagingStateParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "RelevantMessagingState", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> RelevantMessagingState
        ///  The snapshot of some state related to messaging relevant to the current parachain as per
        ///  the relay parent.
        /// 
        ///  This field is meant to be updated each block with the validation data inherent. Therefore,
        ///  before processing of the inherent, e.g. in `on_initialize` this data may be stale.
        /// 
        ///  This data is also absent from the genesis.
        /// </summary>
        public async Task<Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_pallet_parachain_system.relay_state_snapshot.MessagingStateSnapshot> RelevantMessagingState(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.RelevantMessagingStateParams();
            return await _client.GetStorageAsync<Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_pallet_parachain_system.relay_state_snapshot.MessagingStateSnapshot>(parameters, token);
        }
        
        /// <summary>
        /// >> HostConfigurationParams
        ///  The parachain host configuration that was obtained from the relay parent.
        /// 
        ///  This field is meant to be updated each block with the validation data inherent. Therefore,
        ///  before processing of the inherent, e.g. in `on_initialize` this data may be stale.
        /// 
        ///  This data is also absent from the genesis.
        /// </summary>
        public static string HostConfigurationParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "HostConfiguration", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> HostConfiguration
        ///  The parachain host configuration that was obtained from the relay parent.
        /// 
        ///  This field is meant to be updated each block with the validation data inherent. Therefore,
        ///  before processing of the inherent, e.g. in `on_initialize` this data may be stale.
        /// 
        ///  This data is also absent from the genesis.
        /// </summary>
        public async Task<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.AbridgedHostConfiguration> HostConfiguration(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.HostConfigurationParams();
            return await _client.GetStorageAsync<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.AbridgedHostConfiguration>(parameters, token);
        }
        
        /// <summary>
        /// >> LastDmqMqcHeadParams
        ///  The last downward message queue chain head we have observed.
        /// 
        ///  This value is loaded before and saved after processing inbound downward messages carried
        ///  by the system inherent.
        /// </summary>
        public static string LastDmqMqcHeadParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "LastDmqMqcHead", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> LastDmqMqcHead
        ///  The last downward message queue chain head we have observed.
        /// 
        ///  This value is loaded before and saved after processing inbound downward messages carried
        ///  by the system inherent.
        /// </summary>
        public async Task<Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_primitives_parachain_inherent.MessageQueueChain> LastDmqMqcHead(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.LastDmqMqcHeadParams();
            return await _client.GetStorageAsync<Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_primitives_parachain_inherent.MessageQueueChain>(parameters, token);
        }
        
        /// <summary>
        /// >> LastHrmpMqcHeadsParams
        ///  The message queue chain heads we have observed per each channel incoming channel.
        /// 
        ///  This value is loaded before and saved after processing inbound downward messages carried
        ///  by the system inherent.
        /// </summary>
        public static string LastHrmpMqcHeadsParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "LastHrmpMqcHeads", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> LastHrmpMqcHeads
        ///  The message queue chain heads we have observed per each channel incoming channel.
        /// 
        ///  This value is loaded before and saved after processing inbound downward messages carried
        ///  by the system inherent.
        /// </summary>
        public async Task<Polkanalysis.Bajun.NetApiExt.Generated.Types.Base.BTreeMapT1> LastHrmpMqcHeads(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.LastHrmpMqcHeadsParams();
            return await _client.GetStorageAsync<Polkanalysis.Bajun.NetApiExt.Generated.Types.Base.BTreeMapT1>(parameters, token);
        }
        
        /// <summary>
        /// >> ProcessedDownwardMessagesParams
        ///  Number of downward messages processed in a block.
        /// 
        ///  This will be cleared in `on_initialize` of each new block.
        /// </summary>
        public static string ProcessedDownwardMessagesParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "ProcessedDownwardMessages", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> ProcessedDownwardMessages
        ///  Number of downward messages processed in a block.
        /// 
        ///  This will be cleared in `on_initialize` of each new block.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> ProcessedDownwardMessages(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.ProcessedDownwardMessagesParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
        }
        
        /// <summary>
        /// >> HrmpWatermarkParams
        ///  HRMP watermark that was set in a block.
        /// 
        ///  This will be cleared in `on_initialize` of each new block.
        /// </summary>
        public static string HrmpWatermarkParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "HrmpWatermark", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> HrmpWatermark
        ///  HRMP watermark that was set in a block.
        /// 
        ///  This will be cleared in `on_initialize` of each new block.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> HrmpWatermark(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.HrmpWatermarkParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
        }
        
        /// <summary>
        /// >> HrmpOutboundMessagesParams
        ///  HRMP messages that were sent in a block.
        /// 
        ///  This will be cleared in `on_initialize` of each new block.
        /// </summary>
        public static string HrmpOutboundMessagesParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "HrmpOutboundMessages", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> HrmpOutboundMessages
        ///  HRMP messages that were sent in a block.
        /// 
        ///  This will be cleared in `on_initialize` of each new block.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_core_primitives.OutboundHrmpMessage>> HrmpOutboundMessages(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.HrmpOutboundMessagesParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_core_primitives.OutboundHrmpMessage>>(parameters, token);
        }
        
        /// <summary>
        /// >> UpwardMessagesParams
        ///  Upward messages that were sent in a block.
        /// 
        ///  This will be cleared in `on_initialize` of each new block.
        /// </summary>
        public static string UpwardMessagesParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "UpwardMessages", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> UpwardMessages
        ///  Upward messages that were sent in a block.
        /// 
        ///  This will be cleared in `on_initialize` of each new block.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>> UpwardMessages(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.UpwardMessagesParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>>(parameters, token);
        }
        
        /// <summary>
        /// >> PendingUpwardMessagesParams
        ///  Upward messages that are still pending and not yet send to the relay chain.
        /// </summary>
        public static string PendingUpwardMessagesParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "PendingUpwardMessages", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> PendingUpwardMessages
        ///  Upward messages that are still pending and not yet send to the relay chain.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>> PendingUpwardMessages(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.PendingUpwardMessagesParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>>(parameters, token);
        }
        
        /// <summary>
        /// >> AnnouncedHrmpMessagesPerCandidateParams
        ///  The number of HRMP messages we observed in `on_initialize` and thus used that number for
        ///  announcing the weight of `on_initialize` and `on_finalize`.
        /// </summary>
        public static string AnnouncedHrmpMessagesPerCandidateParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "AnnouncedHrmpMessagesPerCandidate", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> AnnouncedHrmpMessagesPerCandidate
        ///  The number of HRMP messages we observed in `on_initialize` and thus used that number for
        ///  announcing the weight of `on_initialize` and `on_finalize`.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> AnnouncedHrmpMessagesPerCandidate(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.AnnouncedHrmpMessagesPerCandidateParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
        }
        
        /// <summary>
        /// >> ReservedXcmpWeightOverrideParams
        ///  The weight we reserve at the beginning of the block for processing XCMP messages. This
        ///  overrides the amount set in the Config trait.
        /// </summary>
        public static string ReservedXcmpWeightOverrideParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "ReservedXcmpWeightOverride", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> ReservedXcmpWeightOverride
        ///  The weight we reserve at the beginning of the block for processing XCMP messages. This
        ///  overrides the amount set in the Config trait.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U64> ReservedXcmpWeightOverride(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.ReservedXcmpWeightOverrideParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U64>(parameters, token);
        }
        
        /// <summary>
        /// >> ReservedDmpWeightOverrideParams
        ///  The weight we reserve at the beginning of the block for processing DMP messages. This
        ///  overrides the amount set in the Config trait.
        /// </summary>
        public static string ReservedDmpWeightOverrideParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "ReservedDmpWeightOverride", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> ReservedDmpWeightOverride
        ///  The weight we reserve at the beginning of the block for processing DMP messages. This
        ///  overrides the amount set in the Config trait.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U64> ReservedDmpWeightOverride(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.ReservedDmpWeightOverrideParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U64>(parameters, token);
        }
        
        /// <summary>
        /// >> AuthorizedUpgradeParams
        ///  The next authorized upgrade, if there is one.
        /// </summary>
        public static string AuthorizedUpgradeParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "AuthorizedUpgrade", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> AuthorizedUpgrade
        ///  The next authorized upgrade, if there is one.
        /// </summary>
        public async Task<Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256> AuthorizedUpgrade(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.AuthorizedUpgradeParams();
            return await _client.GetStorageAsync<Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256>(parameters, token);
        }
        
        /// <summary>
        /// >> CustomValidationHeadDataParams
        ///  A custom head data that should be returned as result of `validate_block`.
        /// 
        ///  See [`Pallet::set_custom_validation_head_data`] for more information.
        /// </summary>
        public static string CustomValidationHeadDataParams()
        {
            return RequestGenerator.GetStorage("ParachainSystem", "CustomValidationHeadData", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> CustomValidationHeadData
        ///  A custom head data that should be returned as result of `validate_block`.
        /// 
        ///  See [`Pallet::set_custom_validation_head_data`] for more information.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> CustomValidationHeadData(CancellationToken token)
        {
            string parameters = ParachainSystemStorage.CustomValidationHeadDataParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>(parameters, token);
        }
    }
    
    public sealed class ParachainSystemCalls
    {
        
        /// <summary>
        /// >> set_validation_data
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetValidationData(Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_primitives_parachain_inherent.ParachainInherentData data)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(data.Encode());
            return new Method(1, "ParachainSystem", 0, "set_validation_data", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> sudo_send_upward_message
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SudoSendUpwardMessage(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> message)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(message.Encode());
            return new Method(1, "ParachainSystem", 1, "sudo_send_upward_message", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> authorize_upgrade
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method AuthorizeUpgrade(Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256 code_hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(code_hash.Encode());
            return new Method(1, "ParachainSystem", 2, "authorize_upgrade", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> enact_authorized_upgrade
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method EnactAuthorizedUpgrade(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> code)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(code.Encode());
            return new Method(1, "ParachainSystem", 3, "enact_authorized_upgrade", byteArray.ToArray());
        }
    }
    
    public enum ParachainSystemErrors
    {
        
        /// <summary>
        /// >> OverlappingUpgrades
        /// Attempt to upgrade validation function while existing upgrade pending
        /// </summary>
        OverlappingUpgrades,
        
        /// <summary>
        /// >> ProhibitedByPolkadot
        /// Polkadot currently prohibits this parachain from upgrading its validation function
        /// </summary>
        ProhibitedByPolkadot,
        
        /// <summary>
        /// >> TooBig
        /// The supplied validation function has compiled into a blob larger than Polkadot is
        /// willing to run
        /// </summary>
        TooBig,
        
        /// <summary>
        /// >> ValidationDataNotAvailable
        /// The inherent which supplies the validation data did not run this block
        /// </summary>
        ValidationDataNotAvailable,
        
        /// <summary>
        /// >> HostConfigurationNotAvailable
        /// The inherent which supplies the host configuration did not run this block
        /// </summary>
        HostConfigurationNotAvailable,
        
        /// <summary>
        /// >> NotScheduled
        /// No validation function upgrade is currently scheduled.
        /// </summary>
        NotScheduled,
        
        /// <summary>
        /// >> NothingAuthorized
        /// No code upgrade has been authorized.
        /// </summary>
        NothingAuthorized,
        
        /// <summary>
        /// >> Unauthorized
        /// The given code upgrade has not been authorized.
        /// </summary>
        Unauthorized,
    }
}
