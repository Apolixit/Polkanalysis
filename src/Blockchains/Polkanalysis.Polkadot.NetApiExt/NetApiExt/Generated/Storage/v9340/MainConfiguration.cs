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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9340
{
    public sealed class ConfigurationStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> ActiveConfigParams
        ///  The active configuration for the current session.
        /// </summary>
        public static string ActiveConfigParams()
        {
            return RequestGenerator.GetStorage("Configuration", "ActiveConfig", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ActiveConfigDefault
        /// Default value as hex string
        /// </summary>
        public static string ActiveConfigDefault()
        {
            return "0x00000000000000000000000000000000000000000000000000000000000000000200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000100000001000000000000000000060000006400000002000000C800000001000000000000000000000000000000000000000700C817A80402004001000200000002000000";
        }

        /// <summary>
        /// >> ActiveConfig
        ///  The active configuration for the current session.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.polkadot_runtime_parachains.configuration.HostConfiguration> ActiveConfig(CancellationToken token)
        {
            string parameters = ActiveConfigParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.polkadot_runtime_parachains.configuration.HostConfiguration>(parameters, blockHash, token);
            return result;
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
        /// >> PendingConfigsDefault
        /// Default value as hex string
        /// </summary>
        public static string PendingConfigsDefault()
        {
            return "0x00";
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
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.polkadot_runtime_parachains.configuration.HostConfiguration>>> PendingConfigs(CancellationToken token)
        {
            string parameters = PendingConfigsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.polkadot_runtime_parachains.configuration.HostConfiguration>>>(parameters, blockHash, token);
            return result;
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
        /// >> BypassConsistencyCheckDefault
        /// Default value as hex string
        /// </summary>
        public static string BypassConsistencyCheckDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> BypassConsistencyCheck
        ///  If this is set, then the configuration setters will bypass the consistency checks. This
        ///  is meant to be used only as the last resort.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> BypassConsistencyCheck(CancellationToken token)
        {
            string parameters = BypassConsistencyCheckParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockHash, token);
            return result;
        }

        public ConfigurationStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class ConfigurationConstants
    {
    }

    public enum ConfigurationErrors
    {
        /// <summary>
        /// >> InvalidNewValue
        /// The new value for a configuration parameter is invalid.
        /// </summary>
        InvalidNewValue
    }
}