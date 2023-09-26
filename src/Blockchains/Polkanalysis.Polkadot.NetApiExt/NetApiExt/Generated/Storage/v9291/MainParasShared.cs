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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9291
{
    public sealed class ParasSharedStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> CurrentSessionIndexParams
        ///  The current session index.
        /// </summary>
        public static string CurrentSessionIndexParams()
        {
            return RequestGenerator.GetStorage("ParasShared", "CurrentSessionIndex", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CurrentSessionIndexDefault
        /// Default value as hex string
        /// </summary>
        public static string CurrentSessionIndexDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> CurrentSessionIndex
        ///  The current session index.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> CurrentSessionIndex(CancellationToken token)
        {
            string parameters = CurrentSessionIndexParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ActiveValidatorIndicesParams
        ///  All the validators actively participating in parachain consensus.
        ///  Indices are into the broader validator set.
        /// </summary>
        public static string ActiveValidatorIndicesParams()
        {
            return RequestGenerator.GetStorage("ParasShared", "ActiveValidatorIndices", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ActiveValidatorIndicesDefault
        /// Default value as hex string
        /// </summary>
        public static string ActiveValidatorIndicesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ActiveValidatorIndices
        ///  All the validators actively participating in parachain consensus.
        ///  Indices are into the broader validator set.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.polkadot_primitives.v2.ValidatorIndex>> ActiveValidatorIndices(CancellationToken token)
        {
            string parameters = ActiveValidatorIndicesParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.polkadot_primitives.v2.ValidatorIndex>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ActiveValidatorKeysParams
        ///  The parachain attestation keys of the validators actively participating in parachain consensus.
        ///  This should be the same length as `ActiveValidatorIndices`.
        /// </summary>
        public static string ActiveValidatorKeysParams()
        {
            return RequestGenerator.GetStorage("ParasShared", "ActiveValidatorKeys", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ActiveValidatorKeysDefault
        /// Default value as hex string
        /// </summary>
        public static string ActiveValidatorKeysDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ActiveValidatorKeys
        ///  The parachain attestation keys of the validators actively participating in parachain consensus.
        ///  This should be the same length as `ActiveValidatorIndices`.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.polkadot_primitives.v2.validator_app.Public>> ActiveValidatorKeys(CancellationToken token)
        {
            string parameters = ActiveValidatorKeysParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.polkadot_primitives.v2.validator_app.Public>>(parameters, blockHash, token);
            return result;
        }

        public ParasSharedStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class ParasSharedConstants
    {
    }
}