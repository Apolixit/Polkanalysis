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
    
    
    public sealed class FastUnstakeStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public FastUnstakeStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("FastUnstake", "Head"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Polkadot.NetApiExt.Generated.Model.pallet_fast_unstake.types.UnstakeRequest)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("FastUnstake", "Queue"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Ajuna.NetApi.Model.Types.Primitive.U128)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("FastUnstake", "CounterForQueue"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("FastUnstake", "ErasToCheckPerBlock"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
        }
        
        /// <summary>
        /// >> HeadParams
        ///  The current "head of the queue" being unstaked.
        /// </summary>
        public static string HeadParams()
        {
            return RequestGenerator.GetStorage("FastUnstake", "Head", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> HeadDefault
        /// Default value as hex string
        /// </summary>
        public static string HeadDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Head
        ///  The current "head of the queue" being unstaked.
        /// </summary>
        public async Task<Substats.Polkadot.NetApiExt.Generated.Model.pallet_fast_unstake.types.UnstakeRequest> Head(CancellationToken token)
        {
            string parameters = FastUnstakeStorage.HeadParams();
            var result = await _client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.pallet_fast_unstake.types.UnstakeRequest>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> QueueParams
        ///  The map of all accounts wishing to be unstaked.
        /// 
        ///  Keeps track of `AccountId` wishing to unstake and it's corresponding deposit.
        /// </summary>
        public static string QueueParams(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("FastUnstake", "Queue", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> QueueDefault
        /// Default value as hex string
        /// </summary>
        public static string QueueDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Queue
        ///  The map of all accounts wishing to be unstaked.
        /// 
        ///  Keeps track of `AccountId` wishing to unstake and it's corresponding deposit.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U128> Queue(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = FastUnstakeStorage.QueueParams(key);
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U128>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> CounterForQueueParams
        /// Counter for the related counted storage map
        /// </summary>
        public static string CounterForQueueParams()
        {
            return RequestGenerator.GetStorage("FastUnstake", "CounterForQueue", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> CounterForQueueDefault
        /// Default value as hex string
        /// </summary>
        public static string CounterForQueueDefault()
        {
            return "0x00000000";
        }
        
        /// <summary>
        /// >> CounterForQueue
        /// Counter for the related counted storage map
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> CounterForQueue(CancellationToken token)
        {
            string parameters = FastUnstakeStorage.CounterForQueueParams();
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> ErasToCheckPerBlockParams
        ///  Number of eras to check per block.
        /// 
        ///  If set to 0, this pallet does absolutely nothing.
        /// 
        ///  Based on the amount of weight available at `on_idle`, up to this many eras of a single
        ///  nominator might be checked.
        /// </summary>
        public static string ErasToCheckPerBlockParams()
        {
            return RequestGenerator.GetStorage("FastUnstake", "ErasToCheckPerBlock", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> ErasToCheckPerBlockDefault
        /// Default value as hex string
        /// </summary>
        public static string ErasToCheckPerBlockDefault()
        {
            return "0x00000000";
        }
        
        /// <summary>
        /// >> ErasToCheckPerBlock
        ///  Number of eras to check per block.
        /// 
        ///  If set to 0, this pallet does absolutely nothing.
        /// 
        ///  Based on the amount of weight available at `on_idle`, up to this many eras of a single
        ///  nominator might be checked.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> ErasToCheckPerBlock(CancellationToken token)
        {
            string parameters = FastUnstakeStorage.ErasToCheckPerBlockParams();
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
            return result;
        }
    }
    
    public sealed class FastUnstakeCalls
    {
        
        /// <summary>
        /// >> register_fast_unstake
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method RegisterFastUnstake()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(40, "FastUnstake", 0, "register_fast_unstake", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> deregister
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Deregister()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(40, "FastUnstake", 1, "deregister", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> control
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Control(Ajuna.NetApi.Model.Types.Primitive.U32 unchecked_eras_to_check)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(unchecked_eras_to_check.Encode());
            return new Method(40, "FastUnstake", 2, "control", byteArray.ToArray());
        }
    }
    
    public sealed class FastUnstakeConstants
    {
        
        /// <summary>
        /// >> Deposit
        ///  Deposit to take for unstaking, to make sure we're able to slash the it in order to cover
        ///  the costs of resources on unsuccessful unstake.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 Deposit()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00E40B54020000000000000000000000");
            return result;
        }
    }
    
    public enum FastUnstakeErrors
    {
        
        /// <summary>
        /// >> NotController
        /// The provided Controller account was not found.
        /// 
        /// This means that the given account is not bonded.
        /// </summary>
        NotController,
        
        /// <summary>
        /// >> AlreadyQueued
        /// The bonded account has already been queued.
        /// </summary>
        AlreadyQueued,
        
        /// <summary>
        /// >> NotFullyBonded
        /// The bonded account has active unlocking chunks.
        /// </summary>
        NotFullyBonded,
        
        /// <summary>
        /// >> NotQueued
        /// The provided un-staker is not in the `Queue`.
        /// </summary>
        NotQueued,
        
        /// <summary>
        /// >> AlreadyHead
        /// The provided un-staker is already in Head, and cannot deregister.
        /// </summary>
        AlreadyHead,
        
        /// <summary>
        /// >> CallNotAllowed
        /// The call is not allowed at this point because the pallet is not active.
        /// </summary>
        CallNotAllowed,
    }
}
