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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage
{
    public sealed class UtilityStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        public async Task<uint> GetVersionAsync(CancellationToken token)
        {
            var result = await _client.State.GetRuntimeVersionAtAsync(blockHash, token);
            return result.SpecVersion;
        }

        /// <summary>
        /// Storage for SpecVersion 9110
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9110.UtilityStorage _utilityStorageV9110;
        /// <summary>
        /// Storage for SpecVersion 9122
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9122.UtilityStorage _utilityStorageV9122;
        /// <summary>
        /// Storage for SpecVersion 9140
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9140.UtilityStorage _utilityStorageV9140;
        /// <summary>
        /// Storage for SpecVersion 9151
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9151.UtilityStorage _utilityStorageV9151;
        /// <summary>
        /// Storage for SpecVersion 9170
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9170.UtilityStorage _utilityStorageV9170;
        /// <summary>
        /// Storage for SpecVersion 9180
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9180.UtilityStorage _utilityStorageV9180;
        /// <summary>
        /// Storage for SpecVersion 9190
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9190.UtilityStorage _utilityStorageV9190;
        /// <summary>
        /// Storage for SpecVersion 9200
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9200.UtilityStorage _utilityStorageV9200;
        /// <summary>
        /// Storage for SpecVersion 9220
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9220.UtilityStorage _utilityStorageV9220;
        /// <summary>
        /// Storage for SpecVersion 9230
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9230.UtilityStorage _utilityStorageV9230;
        /// <summary>
        /// Storage for SpecVersion 9250
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9250.UtilityStorage _utilityStorageV9250;
        /// <summary>
        /// Storage for SpecVersion 9260
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9260.UtilityStorage _utilityStorageV9260;
        /// <summary>
        /// Storage for SpecVersion 9270
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9270.UtilityStorage _utilityStorageV9270;
        /// <summary>
        /// Storage for SpecVersion 9280
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9280.UtilityStorage _utilityStorageV9280;
        /// <summary>
        /// Storage for SpecVersion 9281
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9281.UtilityStorage _utilityStorageV9281;
        /// <summary>
        /// Storage for SpecVersion 9291
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9291.UtilityStorage _utilityStorageV9291;
        /// <summary>
        /// Storage for SpecVersion 9300
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9300.UtilityStorage _utilityStorageV9300;
        /// <summary>
        /// Storage for SpecVersion 9340
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9340.UtilityStorage _utilityStorageV9340;
        /// <summary>
        /// Storage for SpecVersion 9360
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9360.UtilityStorage _utilityStorageV9360;
        /// <summary>
        /// Storage for SpecVersion 9370
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9370.UtilityStorage _utilityStorageV9370;
        /// <summary>
        /// Storage for SpecVersion 9420
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9420.UtilityStorage _utilityStorageV9420;
        /// <summary>
        /// Storage for SpecVersion 9430
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9430.UtilityStorage _utilityStorageV9430;
        public UtilityStorage(SubstrateClientExt client)
        {
            _client = client;
            _utilityStorageV9110 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9110.UtilityStorage(_client);
            _utilityStorageV9122 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9122.UtilityStorage(_client);
            _utilityStorageV9140 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9140.UtilityStorage(_client);
            _utilityStorageV9151 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9151.UtilityStorage(_client);
            _utilityStorageV9170 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9170.UtilityStorage(_client);
            _utilityStorageV9180 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9180.UtilityStorage(_client);
            _utilityStorageV9190 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9190.UtilityStorage(_client);
            _utilityStorageV9200 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9200.UtilityStorage(_client);
            _utilityStorageV9220 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9220.UtilityStorage(_client);
            _utilityStorageV9230 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9230.UtilityStorage(_client);
            _utilityStorageV9250 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9250.UtilityStorage(_client);
            _utilityStorageV9260 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9260.UtilityStorage(_client);
            _utilityStorageV9270 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9270.UtilityStorage(_client);
            _utilityStorageV9280 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9280.UtilityStorage(_client);
            _utilityStorageV9281 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9281.UtilityStorage(_client);
            _utilityStorageV9291 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9291.UtilityStorage(_client);
            _utilityStorageV9300 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9300.UtilityStorage(_client);
            _utilityStorageV9340 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9340.UtilityStorage(_client);
            _utilityStorageV9360 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9360.UtilityStorage(_client);
            _utilityStorageV9370 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9370.UtilityStorage(_client);
            _utilityStorageV9420 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9420.UtilityStorage(_client);
            _utilityStorageV9430 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9430.UtilityStorage(_client);
        }
    }

    public sealed class UtilityConstants
    {
        /// <summary>
        /// >> batched_calls_limit
        ///  The limit on the number of batched calls.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 batched_calls_limit(uint version)
        {
            Substrate.NetApi.Model.Types.Primitive.U32 result = null;
            if (version == 9110U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9110.UtilityConstants().batched_calls_limit();
            if (version == 9122U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9122.UtilityConstants().batched_calls_limit();
            if (version == 9140U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9140.UtilityConstants().batched_calls_limit();
            if (version == 9151U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9151.UtilityConstants().batched_calls_limit();
            if (version == 9170U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9170.UtilityConstants().batched_calls_limit();
            if (version == 9180U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9180.UtilityConstants().batched_calls_limit();
            if (version == 9190U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9190.UtilityConstants().batched_calls_limit();
            if (version == 9200U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9200.UtilityConstants().batched_calls_limit();
            if (version == 9220U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9220.UtilityConstants().batched_calls_limit();
            if (version == 9230U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9230.UtilityConstants().batched_calls_limit();
            if (version == 9250U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9250.UtilityConstants().batched_calls_limit();
            if (version == 9260U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9260.UtilityConstants().batched_calls_limit();
            if (version == 9270U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9270.UtilityConstants().batched_calls_limit();
            if (version == 9280U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9280.UtilityConstants().batched_calls_limit();
            if (version == 9281U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9281.UtilityConstants().batched_calls_limit();
            if (version == 9291U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9291.UtilityConstants().batched_calls_limit();
            if (version == 9300U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9300.UtilityConstants().batched_calls_limit();
            if (version == 9340U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9340.UtilityConstants().batched_calls_limit();
            if (version == 9360U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9360.UtilityConstants().batched_calls_limit();
            if (version == 9370U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9370.UtilityConstants().batched_calls_limit();
            if (version == 9420U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9420.UtilityConstants().batched_calls_limit();
            if (version == 9430U)
                result = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9430.UtilityConstants().batched_calls_limit();
            if (result == null)
                throw new System.InvalidOperationException("Error while fetching data");
            return result;
        }
    }

    public enum UtilityErrors
    {
        /// <summary>
        /// >> TooManyCalls
        /// Too many calls batched.
        /// </summary>
        TooManyCalls
    }
}