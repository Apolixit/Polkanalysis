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
    public sealed class AuthorityDiscoveryStorage
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
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9110.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9110;
        /// <summary>
        /// Storage for SpecVersion 9122
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9122.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9122;
        /// <summary>
        /// Storage for SpecVersion 9140
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9140.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9140;
        /// <summary>
        /// Storage for SpecVersion 9151
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9151.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9151;
        /// <summary>
        /// Storage for SpecVersion 9170
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9170.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9170;
        /// <summary>
        /// Storage for SpecVersion 9180
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9180.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9180;
        /// <summary>
        /// Storage for SpecVersion 9190
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9190.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9190;
        /// <summary>
        /// Storage for SpecVersion 9200
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9200.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9200;
        /// <summary>
        /// Storage for SpecVersion 9220
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9220.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9220;
        /// <summary>
        /// Storage for SpecVersion 9230
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9230.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9230;
        /// <summary>
        /// Storage for SpecVersion 9250
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9250.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9250;
        /// <summary>
        /// Storage for SpecVersion 9260
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9260.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9260;
        /// <summary>
        /// Storage for SpecVersion 9270
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9270.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9270;
        /// <summary>
        /// Storage for SpecVersion 9280
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9280.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9280;
        /// <summary>
        /// Storage for SpecVersion 9281
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9281.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9281;
        /// <summary>
        /// Storage for SpecVersion 9291
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9291.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9291;
        /// <summary>
        /// Storage for SpecVersion 9300
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9300.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9300;
        /// <summary>
        /// Storage for SpecVersion 9340
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9340.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9340;
        /// <summary>
        /// Storage for SpecVersion 9360
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9360.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9360;
        /// <summary>
        /// Storage for SpecVersion 9370
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9370.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9370;
        /// <summary>
        /// Storage for SpecVersion 9420
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9420.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9420;
        /// <summary>
        /// Storage for SpecVersion 9430
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9430.AuthorityDiscoveryStorage _authorityDiscoveryStorageV9430;
        public AuthorityDiscoveryStorage(SubstrateClientExt client)
        {
            _client = client;
            _authorityDiscoveryStorageV9110 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9110.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9122 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9122.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9140 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9140.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9151 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9151.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9170 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9170.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9180 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9180.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9190 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9190.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9200 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9200.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9220 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9220.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9230 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9230.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9250 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9250.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9260 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9260.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9270 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9270.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9280 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9280.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9281 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9281.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9291 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9291.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9300 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9300.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9340 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9340.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9360 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9360.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9370 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9370.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9420 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9420.AuthorityDiscoveryStorage(_client);
            _authorityDiscoveryStorageV9430 = new Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9430.AuthorityDiscoveryStorage(_client);
        }
    }

    public sealed class AuthorityDiscoveryConstants
    {
    }
}