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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9420
{
    public sealed class WhitelistStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> WhitelistedCallParams
        /// </summary>
        public static string WhitelistedCallParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Whitelist", "WhitelistedCall", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> WhitelistedCallDefault
        /// Default value as hex string
        /// </summary>
        public static string WhitelistedCallDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> WhitelistedCall
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple> WhitelistedCall(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = WhitelistedCallParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple>(parameters, blockHash, token);
            return result;
        }

        public WhitelistStorage(SubstrateClientExt client)
        {
            _client = client;
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