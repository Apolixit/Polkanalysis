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


namespace Substats.Kusama.NetApiExt.Generated.Storage
{
    
    
    public sealed class RecoveryStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public RecoveryStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Recovery", "Recoverable"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Substats.Kusama.NetApiExt.Generated.Model.pallet_recovery.RecoveryConfig)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Recovery", "ActiveRecoveries"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>), typeof(Substats.Kusama.NetApiExt.Generated.Model.pallet_recovery.ActiveRecovery)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Recovery", "Proxy"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32)));
        }
        
        /// <summary>
        /// >> RecoverableParams
        ///  The set of recoverable accounts and their recovery configuration.
        /// </summary>
        public static string RecoverableParams(Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Recovery", "Recoverable", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Recoverable
        ///  The set of recoverable accounts and their recovery configuration.
        /// </summary>
        public async Task<Substats.Kusama.NetApiExt.Generated.Model.pallet_recovery.RecoveryConfig> Recoverable(Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = RecoveryStorage.RecoverableParams(key);
            return await _client.GetStorageAsync<Substats.Kusama.NetApiExt.Generated.Model.pallet_recovery.RecoveryConfig>(parameters, token);
        }
        
        /// <summary>
        /// >> ActiveRecoveriesParams
        ///  Active recovery attempts.
        /// 
        ///  First account is the account to be recovered, and the second account
        ///  is the user trying to recover the account.
        /// </summary>
        public static string ActiveRecoveriesParams(Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> key)
        {
            return RequestGenerator.GetStorage("Recovery", "ActiveRecoveries", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, key.Value);
        }
        
        /// <summary>
        /// >> ActiveRecoveries
        ///  Active recovery attempts.
        /// 
        ///  First account is the account to be recovered, and the second account
        ///  is the user trying to recover the account.
        /// </summary>
        public async Task<Substats.Kusama.NetApiExt.Generated.Model.pallet_recovery.ActiveRecovery> ActiveRecoveries(Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> key, CancellationToken token)
        {
            string parameters = RecoveryStorage.ActiveRecoveriesParams(key);
            return await _client.GetStorageAsync<Substats.Kusama.NetApiExt.Generated.Model.pallet_recovery.ActiveRecovery>(parameters, token);
        }
        
        /// <summary>
        /// >> ProxyParams
        ///  The list of allowed proxy accounts.
        /// 
        ///  Map from the user who can access it to the recovered account.
        /// </summary>
        public static string ProxyParams(Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Recovery", "Proxy", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Proxy
        ///  The list of allowed proxy accounts.
        /// 
        ///  Map from the user who can access it to the recovered account.
        /// </summary>
        public async Task<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> Proxy(Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = RecoveryStorage.ProxyParams(key);
            return await _client.GetStorageAsync<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>(parameters, token);
        }
    }
    
    public sealed class RecoveryCalls
    {
        
        /// <summary>
        /// >> as_recovered
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method AsRecovered(Substats.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress account, Substats.Kusama.NetApiExt.Generated.Model.kusama_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(account.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(27, "Recovery", 0, "as_recovered", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_recovered
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetRecovered(Substats.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress lost, Substats.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress rescuer)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(lost.Encode());
            byteArray.AddRange(rescuer.Encode());
            return new Method(27, "Recovery", 1, "set_recovered", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> create_recovery
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method CreateRecovery(Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> friends, Ajuna.NetApi.Model.Types.Primitive.U16 threshold, Ajuna.NetApi.Model.Types.Primitive.U32 delay_period)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(friends.Encode());
            byteArray.AddRange(threshold.Encode());
            byteArray.AddRange(delay_period.Encode());
            return new Method(27, "Recovery", 2, "create_recovery", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> initiate_recovery
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method InitiateRecovery(Substats.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress account)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(account.Encode());
            return new Method(27, "Recovery", 3, "initiate_recovery", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> vouch_recovery
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method VouchRecovery(Substats.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress lost, Substats.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress rescuer)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(lost.Encode());
            byteArray.AddRange(rescuer.Encode());
            return new Method(27, "Recovery", 4, "vouch_recovery", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> claim_recovery
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ClaimRecovery(Substats.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress account)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(account.Encode());
            return new Method(27, "Recovery", 5, "claim_recovery", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> close_recovery
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method CloseRecovery(Substats.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress rescuer)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(rescuer.Encode());
            return new Method(27, "Recovery", 6, "close_recovery", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_recovery
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method RemoveRecovery()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(27, "Recovery", 7, "remove_recovery", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> cancel_recovered
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method CancelRecovered(Substats.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress account)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(account.Encode());
            return new Method(27, "Recovery", 8, "cancel_recovered", byteArray.ToArray());
        }
    }
    
    public enum RecoveryErrors
    {
        
        /// <summary>
        /// >> NotAllowed
        /// User is not allowed to make a call on behalf of this account
        /// </summary>
        NotAllowed,
        
        /// <summary>
        /// >> ZeroThreshold
        /// Threshold must be greater than zero
        /// </summary>
        ZeroThreshold,
        
        /// <summary>
        /// >> NotEnoughFriends
        /// Friends list must be greater than zero and threshold
        /// </summary>
        NotEnoughFriends,
        
        /// <summary>
        /// >> MaxFriends
        /// Friends list must be less than max friends
        /// </summary>
        MaxFriends,
        
        /// <summary>
        /// >> NotSorted
        /// Friends list must be sorted and free of duplicates
        /// </summary>
        NotSorted,
        
        /// <summary>
        /// >> NotRecoverable
        /// This account is not set up for recovery
        /// </summary>
        NotRecoverable,
        
        /// <summary>
        /// >> AlreadyRecoverable
        /// This account is already set up for recovery
        /// </summary>
        AlreadyRecoverable,
        
        /// <summary>
        /// >> AlreadyStarted
        /// A recovery process has already started for this account
        /// </summary>
        AlreadyStarted,
        
        /// <summary>
        /// >> NotStarted
        /// A recovery process has not started for this rescuer
        /// </summary>
        NotStarted,
        
        /// <summary>
        /// >> NotFriend
        /// This account is not a friend who can vouch
        /// </summary>
        NotFriend,
        
        /// <summary>
        /// >> DelayPeriod
        /// The friend must wait until the delay period to vouch for this recovery
        /// </summary>
        DelayPeriod,
        
        /// <summary>
        /// >> AlreadyVouched
        /// This user has already vouched for this recovery
        /// </summary>
        AlreadyVouched,
        
        /// <summary>
        /// >> Threshold
        /// The threshold for recovering this account has not been met
        /// </summary>
        Threshold,
        
        /// <summary>
        /// >> StillActive
        /// There are still active recovery attempts that need to be closed
        /// </summary>
        StillActive,
        
        /// <summary>
        /// >> AlreadyProxy
        /// This account is already set up for recovery
        /// </summary>
        AlreadyProxy,
        
        /// <summary>
        /// >> BadState
        /// Some internal state is broken.
        /// </summary>
        BadState,
    }
}
