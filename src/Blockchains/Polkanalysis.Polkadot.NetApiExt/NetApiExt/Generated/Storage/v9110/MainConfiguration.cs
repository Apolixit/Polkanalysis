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
            return "0x00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000100000001000000000000000000060000006400000002000000C8000000010000000000000000000000000000000000000000C817A804000000";
        }

        /// <summary>
        /// >> ActiveConfig
        ///  The active configuration for the current session.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_runtime_parachains.configuration.HostConfiguration> ActiveConfig(CancellationToken token)
        {
            string parameters = ActiveConfigParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_runtime_parachains.configuration.HostConfiguration>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PendingConfigParams
        ///  Pending configuration (if any) for the next session.
        /// </summary>
        public static string PendingConfigParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Configuration", "PendingConfig", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> PendingConfigDefault
        /// Default value as hex string
        /// </summary>
        public static string PendingConfigDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> PendingConfig
        ///  Pending configuration (if any) for the next session.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_runtime_parachains.configuration.HostConfiguration> PendingConfig(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = PendingConfigParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_runtime_parachains.configuration.HostConfiguration>(parameters, blockHash, token);
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