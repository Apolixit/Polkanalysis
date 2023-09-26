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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage
{
    public sealed class WhitelistStorage
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
        /// Storage for SpecVersion 9430
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9430.WhitelistStorage _whitelistStorageV9430;
        /// <summary>
        /// Storage for SpecVersion 9420
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9420.WhitelistStorage _whitelistStorageV9420;
        /// <summary>
        /// Storage for SpecVersion 9381
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9381.WhitelistStorage _whitelistStorageV9381;
        /// <summary>
        /// Storage for SpecVersion 9370
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9370.WhitelistStorage _whitelistStorageV9370;
        /// <summary>
        /// Storage for SpecVersion 9360
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9360.WhitelistStorage _whitelistStorageV9360;
        /// <summary>
        /// Storage for SpecVersion 9350
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9350.WhitelistStorage _whitelistStorageV9350;
        /// <summary>
        /// Storage for SpecVersion 9340
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9340.WhitelistStorage _whitelistStorageV9340;
        /// <summary>
        /// Storage for SpecVersion 9320
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9320.WhitelistStorage _whitelistStorageV9320;
        /// <summary>
        /// >> WhitelistedCallParams
        /// </summary>
        public static string WhitelistedCallParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.primitive_types.H256Base key, uint version)
        {
            string param = null;
            if (version == 9430U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9430.WhitelistStorage.WhitelistedCallParams((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.primitive_types.H256)key);
            if (version == 9420U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9420.WhitelistStorage.WhitelistedCallParams((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.primitive_types.H256)key);
            if (version == 9381U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9381.WhitelistStorage.WhitelistedCallParams((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.primitive_types.H256)key);
            if (version == 9370U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9370.WhitelistStorage.WhitelistedCallParams((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.primitive_types.H256)key);
            if (version == 9360U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9360.WhitelistStorage.WhitelistedCallParams((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.primitive_types.H256)key);
            if (version == 9350U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9350.WhitelistStorage.WhitelistedCallParams((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.primitive_types.H256)key);
            if (version == 9340U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9340.WhitelistStorage.WhitelistedCallParams((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.primitive_types.H256)key);
            if (version == 9320U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9320.WhitelistStorage.WhitelistedCallParams((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.primitive_types.H256)key);
            if (param == null)
                throw new System.InvalidOperationException("Error while fetching data");
            return param;
        }

        /// <summary>
        /// >> WhitelistedCallDefault
        /// Default value as hex string
        /// </summary>
        public static string WhitelistedCallDefault(uint version)
        {
            string param = null;
            if (version == 9430U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9430.WhitelistStorage.WhitelistedCallDefault();
            if (version == 9420U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9420.WhitelistStorage.WhitelistedCallDefault();
            if (version == 9381U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9381.WhitelistStorage.WhitelistedCallDefault();
            if (version == 9370U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9370.WhitelistStorage.WhitelistedCallDefault();
            if (version == 9360U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9360.WhitelistStorage.WhitelistedCallDefault();
            if (version == 9350U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9350.WhitelistStorage.WhitelistedCallDefault();
            if (version == 9340U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9340.WhitelistStorage.WhitelistedCallDefault();
            if (version == 9320U)
                param = Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9320.WhitelistStorage.WhitelistedCallDefault();
            if (param == null)
                throw new System.InvalidOperationException("Error while fetching data");
            return param;
        }

        /// <summary>
        /// >> WhitelistedCall
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable> WhitelistedCallAsync(Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.primitive_types.H256Base key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable param = null;
            if (version == 9430U)
            {
                _whitelistStorageV9430.blockHash = blockHash;
                param = await _whitelistStorageV9430.WhitelistedCall((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.primitive_types.H256)key,token);
            }

            if (version == 9420U)
            {
                _whitelistStorageV9420.blockHash = blockHash;
                param = await _whitelistStorageV9420.WhitelistedCall((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.primitive_types.H256)key,token);
            }

            if (version == 9381U)
            {
                _whitelistStorageV9381.blockHash = blockHash;
                param = await _whitelistStorageV9381.WhitelistedCall((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.primitive_types.H256)key,token);
            }

            if (version == 9370U)
            {
                _whitelistStorageV9370.blockHash = blockHash;
                param = await _whitelistStorageV9370.WhitelistedCall((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.primitive_types.H256)key,token);
            }

            if (version == 9360U)
            {
                _whitelistStorageV9360.blockHash = blockHash;
                param = await _whitelistStorageV9360.WhitelistedCall((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.primitive_types.H256)key,token);
            }

            if (version == 9350U)
            {
                _whitelistStorageV9350.blockHash = blockHash;
                param = await _whitelistStorageV9350.WhitelistedCall((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.primitive_types.H256)key,token);
            }

            if (version == 9340U)
            {
                _whitelistStorageV9340.blockHash = blockHash;
                param = await _whitelistStorageV9340.WhitelistedCall((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.primitive_types.H256)key,token);
            }

            if (version == 9320U)
            {
                _whitelistStorageV9320.blockHash = blockHash;
                param = await _whitelistStorageV9320.WhitelistedCall((Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.primitive_types.H256)key,token);
            }

            if (param == null)
                throw new System.InvalidOperationException("Error while fetching data");
            return param;
        }

        public WhitelistStorage(SubstrateClientExt client)
        {
            _client = client;
            _whitelistStorageV9430 = new Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9430.WhitelistStorage(_client);
            _whitelistStorageV9420 = new Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9420.WhitelistStorage(_client);
            _whitelistStorageV9381 = new Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9381.WhitelistStorage(_client);
            _whitelistStorageV9370 = new Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9370.WhitelistStorage(_client);
            _whitelistStorageV9360 = new Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9360.WhitelistStorage(_client);
            _whitelistStorageV9350 = new Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9350.WhitelistStorage(_client);
            _whitelistStorageV9340 = new Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9340.WhitelistStorage(_client);
            _whitelistStorageV9320 = new Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9320.WhitelistStorage(_client);
        }
    }

    public sealed class WhitelistConstants
    {
    }

    public enum WhitelistErrors
    {
        /// <summary>
        /// >> UnavailablePreImage
        /// The preimage of the call hash could not be loaded.
        /// </summary>
        UnavailablePreImage,
        /// <summary>
        /// >> UndecodableCall
        /// The call could not be decoded.
        /// </summary>
        UndecodableCall,
        /// <summary>
        /// >> InvalidCallWeightWitness
        /// The weight of the decoded call was higher than the witness.
        /// </summary>
        InvalidCallWeightWitness,
        /// <summary>
        /// >> CallIsNotWhitelisted
        /// The call was not whitelisted.
        /// </summary>
        CallIsNotWhitelisted,
        /// <summary>
        /// >> CallAlreadyWhitelisted
        /// The call was already whitelisted; No-Op.
        /// </summary>
        CallAlreadyWhitelisted
    }
}