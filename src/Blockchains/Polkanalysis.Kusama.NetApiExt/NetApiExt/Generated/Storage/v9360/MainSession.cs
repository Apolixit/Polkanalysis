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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9360
{
    public sealed class SessionStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> ValidatorsParams
        ///  The current set of validators.
        /// </summary>
        public static string ValidatorsParams()
        {
            return RequestGenerator.GetStorage("Session", "Validators", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ValidatorsDefault
        /// Default value as hex string
        /// </summary>
        public static string ValidatorsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Validators
        ///  The current set of validators.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32>> Validators(CancellationToken token)
        {
            string parameters = ValidatorsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CurrentIndexParams
        ///  Current index of the session.
        /// </summary>
        public static string CurrentIndexParams()
        {
            return RequestGenerator.GetStorage("Session", "CurrentIndex", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CurrentIndexDefault
        /// Default value as hex string
        /// </summary>
        public static string CurrentIndexDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> CurrentIndex
        ///  Current index of the session.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> CurrentIndex(CancellationToken token)
        {
            string parameters = CurrentIndexParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> QueuedChangedParams
        ///  True if the underlying economic identities or weighting behind the validators
        ///  has changed in the queued validator set.
        /// </summary>
        public static string QueuedChangedParams()
        {
            return RequestGenerator.GetStorage("Session", "QueuedChanged", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> QueuedChangedDefault
        /// Default value as hex string
        /// </summary>
        public static string QueuedChangedDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> QueuedChanged
        ///  True if the underlying economic identities or weighting behind the validators
        ///  has changed in the queued validator set.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> QueuedChanged(CancellationToken token)
        {
            string parameters = QueuedChangedParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> QueuedKeysParams
        ///  The queued keys for the next session. When the next session begins, these keys
        ///  will be used to determine the validator's session keys.
        /// </summary>
        public static string QueuedKeysParams()
        {
            return RequestGenerator.GetStorage("Session", "QueuedKeys", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> QueuedKeysDefault
        /// Default value as hex string
        /// </summary>
        public static string QueuedKeysDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> QueuedKeys
        ///  The queued keys for the next session. When the next session begins, these keys
        ///  will be used to determine the validator's session keys.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.kusama_runtime.SessionKeys>>> QueuedKeys(CancellationToken token)
        {
            string parameters = QueuedKeysParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.kusama_runtime.SessionKeys>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> DisabledValidatorsParams
        ///  Indices of disabled validators.
        /// 
        ///  The vec is always kept sorted so that we can find whether a given validator is
        ///  disabled using binary search. It gets cleared when `on_session_ending` returns
        ///  a new set of identities.
        /// </summary>
        public static string DisabledValidatorsParams()
        {
            return RequestGenerator.GetStorage("Session", "DisabledValidators", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> DisabledValidatorsDefault
        /// Default value as hex string
        /// </summary>
        public static string DisabledValidatorsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> DisabledValidators
        ///  Indices of disabled validators.
        /// 
        ///  The vec is always kept sorted so that we can find whether a given validator is
        ///  disabled using binary search. It gets cleared when `on_session_ending` returns
        ///  a new set of identities.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>> DisabledValidators(CancellationToken token)
        {
            string parameters = DisabledValidatorsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> NextKeysParams
        ///  The next session keys for a validator.
        /// </summary>
        public static string NextKeysParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Session", "NextKeys", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> NextKeysDefault
        /// Default value as hex string
        /// </summary>
        public static string NextKeysDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> NextKeys
        ///  The next session keys for a validator.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.kusama_runtime.SessionKeys> NextKeys(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = NextKeysParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.kusama_runtime.SessionKeys>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> KeyOwnerParams
        ///  The owner of a key. The key is the `KeyTypeId` + the encoded key.
        /// </summary>
        public static string KeyOwnerParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.KeyTypeId, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> key)
        {
            return RequestGenerator.GetStorage("Session", "KeyOwner", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> KeyOwnerDefault
        /// Default value as hex string
        /// </summary>
        public static string KeyOwnerDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> KeyOwner
        ///  The owner of a key. The key is the `KeyTypeId` + the encoded key.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32> KeyOwner(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.KeyTypeId, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> key, CancellationToken token)
        {
            string parameters = KeyOwnerParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32>(parameters, blockHash, token);
            return result;
        }

        public SessionStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class SessionConstants
    {
    }

    public enum SessionErrors
    {
        /// <summary>
        /// >> InvalidProof
        /// Invalid ownership proof.
        /// </summary>
        InvalidProof,
        /// <summary>
        /// >> NoAssociatedValidatorId
        /// No associated validator ID for account.
        /// </summary>
        NoAssociatedValidatorId,
        /// <summary>
        /// >> DuplicatedKey
        /// Registered duplicate key.
        /// </summary>
        DuplicatedKey,
        /// <summary>
        /// >> NoKeys
        /// No keys are associated with this account.
        /// </summary>
        NoKeys,
        /// <summary>
        /// >> NoAccount
        /// Key setting account is not live, so it's impossible to associate keys.
        /// </summary>
        NoAccount
    }
}