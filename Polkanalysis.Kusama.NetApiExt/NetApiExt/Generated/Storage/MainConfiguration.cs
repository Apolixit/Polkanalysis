//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage
{
    
    
    public sealed class ConfigurationStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public ConfigurationStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Configuration", "ActiveConfig"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.configuration.HostConfiguration)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Configuration", "PendingConfigs"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.configuration.HostConfiguration>>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Configuration", "BypassConsistencyCheck"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.Bool)));
        }
        
        /// <summary>
        /// >> ActiveConfigParams
        ///  The active configuration for the current session.
        /// </summary>
        public static string ActiveConfigParams()
        {
            return RequestGenerator.GetStorage("Configuration", "ActiveConfig", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> ActiveConfig
        ///  The active configuration for the current session.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.configuration.HostConfiguration> ActiveConfig(CancellationToken token)
        {
            string parameters = ConfigurationStorage.ActiveConfigParams();
            return await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.configuration.HostConfiguration>(parameters, token);
        }
        
        /// <summary>
        /// >> PendingConfigsParams
        ///  Pending configuration changes.
        /// 
        ///  This is a list of configuration changes, each with a session index at which it should
        ///  be applied.
        /// 
        ///  The list is sorted ascending by session index. Also, this list can only contain at most
        ///  2 items: for the next session and for the `scheduled_session`.
        /// </summary>
        public static string PendingConfigsParams()
        {
            return RequestGenerator.GetStorage("Configuration", "PendingConfigs", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> PendingConfigs
        ///  Pending configuration changes.
        /// 
        ///  This is a list of configuration changes, each with a session index at which it should
        ///  be applied.
        /// 
        ///  The list is sorted ascending by session index. Also, this list can only contain at most
        ///  2 items: for the next session and for the `scheduled_session`.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.configuration.HostConfiguration>>> PendingConfigs(CancellationToken token)
        {
            string parameters = ConfigurationStorage.PendingConfigsParams();
            return await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.configuration.HostConfiguration>>>(parameters, token);
        }
        
        /// <summary>
        /// >> BypassConsistencyCheckParams
        ///  If this is set, then the configuration setters will bypass the consistency checks. This
        ///  is meant to be used only as the last resort.
        /// </summary>
        public static string BypassConsistencyCheckParams()
        {
            return RequestGenerator.GetStorage("Configuration", "BypassConsistencyCheck", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> BypassConsistencyCheck
        ///  If this is set, then the configuration setters will bypass the consistency checks. This
        ///  is meant to be used only as the last resort.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> BypassConsistencyCheck(CancellationToken token)
        {
            string parameters = ConfigurationStorage.BypassConsistencyCheckParams();
            return await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, token);
        }
    }
    
    public sealed class ConfigurationCalls
    {
        
        /// <summary>
        /// >> set_validation_upgrade_cooldown
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetValidationUpgradeCooldown(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 0, "set_validation_upgrade_cooldown", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_validation_upgrade_delay
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetValidationUpgradeDelay(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 1, "set_validation_upgrade_delay", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_code_retention_period
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetCodeRetentionPeriod(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 2, "set_code_retention_period", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_max_code_size
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetMaxCodeSize(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 3, "set_max_code_size", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_max_pov_size
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetMaxPovSize(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 4, "set_max_pov_size", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_max_head_data_size
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetMaxHeadDataSize(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 5, "set_max_head_data_size", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_parathread_cores
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetParathreadCores(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 6, "set_parathread_cores", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_parathread_retries
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetParathreadRetries(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 7, "set_parathread_retries", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_group_rotation_frequency
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetGroupRotationFrequency(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 8, "set_group_rotation_frequency", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_chain_availability_period
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetChainAvailabilityPeriod(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 9, "set_chain_availability_period", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_thread_availability_period
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetThreadAvailabilityPeriod(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 10, "set_thread_availability_period", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_scheduling_lookahead
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetSchedulingLookahead(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 11, "set_scheduling_lookahead", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_max_validators_per_core
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetMaxValidatorsPerCore(Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32> @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 12, "set_max_validators_per_core", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_max_validators
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetMaxValidators(Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32> @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 13, "set_max_validators", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_dispute_period
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetDisputePeriod(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 14, "set_dispute_period", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_dispute_post_conclusion_acceptance_period
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetDisputePostConclusionAcceptancePeriod(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 15, "set_dispute_post_conclusion_acceptance_period", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_dispute_max_spam_slots
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetDisputeMaxSpamSlots(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 16, "set_dispute_max_spam_slots", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_dispute_conclusion_by_time_out_period
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetDisputeConclusionByTimeOutPeriod(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 17, "set_dispute_conclusion_by_time_out_period", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_no_show_slots
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetNoShowSlots(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 18, "set_no_show_slots", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_n_delay_tranches
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetNDelayTranches(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 19, "set_n_delay_tranches", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_zeroth_delay_tranche_width
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetZerothDelayTrancheWidth(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 20, "set_zeroth_delay_tranche_width", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_needed_approvals
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetNeededApprovals(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 21, "set_needed_approvals", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_relay_vrf_modulo_samples
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetRelayVrfModuloSamples(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 22, "set_relay_vrf_modulo_samples", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_max_upward_queue_count
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetMaxUpwardQueueCount(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 23, "set_max_upward_queue_count", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_max_upward_queue_size
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetMaxUpwardQueueSize(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 24, "set_max_upward_queue_size", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_max_downward_message_size
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetMaxDownwardMessageSize(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 25, "set_max_downward_message_size", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_ump_service_total_weight
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetUmpServiceTotalWeight(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 26, "set_ump_service_total_weight", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_max_upward_message_size
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetMaxUpwardMessageSize(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 27, "set_max_upward_message_size", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_max_upward_message_num_per_candidate
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetMaxUpwardMessageNumPerCandidate(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 28, "set_max_upward_message_num_per_candidate", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_hrmp_open_request_ttl
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetHrmpOpenRequestTtl(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 29, "set_hrmp_open_request_ttl", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_hrmp_sender_deposit
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetHrmpSenderDeposit(Substrate.NetApi.Model.Types.Primitive.U128 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 30, "set_hrmp_sender_deposit", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_hrmp_recipient_deposit
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetHrmpRecipientDeposit(Substrate.NetApi.Model.Types.Primitive.U128 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 31, "set_hrmp_recipient_deposit", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_hrmp_channel_max_capacity
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetHrmpChannelMaxCapacity(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 32, "set_hrmp_channel_max_capacity", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_hrmp_channel_max_total_size
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetHrmpChannelMaxTotalSize(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 33, "set_hrmp_channel_max_total_size", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_hrmp_max_parachain_inbound_channels
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetHrmpMaxParachainInboundChannels(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 34, "set_hrmp_max_parachain_inbound_channels", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_hrmp_max_parathread_inbound_channels
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetHrmpMaxParathreadInboundChannels(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 35, "set_hrmp_max_parathread_inbound_channels", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_hrmp_channel_max_message_size
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetHrmpChannelMaxMessageSize(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 36, "set_hrmp_channel_max_message_size", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_hrmp_max_parachain_outbound_channels
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetHrmpMaxParachainOutboundChannels(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 37, "set_hrmp_max_parachain_outbound_channels", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_hrmp_max_parathread_outbound_channels
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetHrmpMaxParathreadOutboundChannels(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 38, "set_hrmp_max_parathread_outbound_channels", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_hrmp_max_message_num_per_candidate
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetHrmpMaxMessageNumPerCandidate(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 39, "set_hrmp_max_message_num_per_candidate", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_ump_max_individual_weight
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetUmpMaxIndividualWeight(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 40, "set_ump_max_individual_weight", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_pvf_checking_enabled
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetPvfCheckingEnabled(Substrate.NetApi.Model.Types.Primitive.Bool @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 41, "set_pvf_checking_enabled", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_pvf_voting_ttl
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetPvfVotingTtl(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 42, "set_pvf_voting_ttl", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_minimum_validation_upgrade_delay
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetMinimumValidationUpgradeDelay(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 43, "set_minimum_validation_upgrade_delay", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_bypass_consistency_check
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetBypassConsistencyCheck(Substrate.NetApi.Model.Types.Primitive.Bool @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(51, "Configuration", 44, "set_bypass_consistency_check", byteArray.ToArray());
        }
    }
    
    public enum ConfigurationErrors
    {
        
        /// <summary>
        /// >> InvalidNewValue
        /// The new value for a configuration parameter is invalid.
        /// </summary>
        InvalidNewValue,
    }
}
