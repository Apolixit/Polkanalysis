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


namespace Substats.Polkadot.NetApiExt.Generated.Storage
{
    
    
    public sealed class ParasSharedStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public ParasSharedStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParasShared", "CurrentSessionIndex"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParasShared", "ActiveValidatorIndices"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParasShared", "ActiveValidatorKeys"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public>)));
        }
        
        /// <summary>
        /// >> CurrentSessionIndexParams
        ///  The current session index.
        /// </summary>
        public static string CurrentSessionIndexParams()
        {
            return RequestGenerator.GetStorage("ParasShared", "CurrentSessionIndex", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> CurrentSessionIndex(CancellationToken token)
        {
            string parameters = ParasSharedStorage.CurrentSessionIndexParams();
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> ActiveValidatorIndicesParams
        ///  All the validators actively participating in parachain consensus.
        ///  Indices are into the broader validator set.
        /// </summary>
        public static string ActiveValidatorIndicesParams()
        {
            return RequestGenerator.GetStorage("ParasShared", "ActiveValidatorIndices", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex>> ActiveValidatorIndices(CancellationToken token)
        {
            string parameters = ParasSharedStorage.ActiveValidatorIndicesParams();
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex>>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> ActiveValidatorKeysParams
        ///  The parachain attestation keys of the validators actively participating in parachain consensus.
        ///  This should be the same length as `ActiveValidatorIndices`.
        /// </summary>
        public static string ActiveValidatorKeysParams()
        {
            return RequestGenerator.GetStorage("ParasShared", "ActiveValidatorKeys", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public>> ActiveValidatorKeys(CancellationToken token)
        {
            string parameters = ParasSharedStorage.ActiveValidatorKeysParams();
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public>>(parameters, token);
            return result;
        }
    }
    
    public sealed class ParasSharedCalls
    {
    }
    
    public sealed class ParasSharedConstants
    {
    }
}
