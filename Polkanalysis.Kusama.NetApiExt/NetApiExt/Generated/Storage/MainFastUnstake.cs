//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage
{
    
    
    public sealed class FastUnstakeStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public FastUnstakeStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("FastUnstake", "Head"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_fast_unstake.types.UnstakeRequest)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("FastUnstake", "Queue"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Substrate.NetApi.Model.Types.Primitive.U128)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("FastUnstake", "CounterForQueue"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("FastUnstake", "ErasToCheckPerBlock"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.U32)));
        }
        
        /// <summary>
        /// >> HeadParams
        ///  The current "head of the queue" being unstaked.
        /// </summary>
        public static string HeadParams()
        {
            return RequestGenerator.GetStorage("FastUnstake", "Head", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> Head
        ///  The current "head of the queue" being unstaked.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_fast_unstake.types.UnstakeRequest> Head(CancellationToken token)
        {
            string parameters = FastUnstakeStorage.HeadParams();
            return await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_fast_unstake.types.UnstakeRequest>(parameters, token);
        }
        
        /// <summary>
        /// >> QueueParams
        ///  The map of all accounts wishing to be unstaked.
        /// 
        ///  Keeps track of `AccountId` wishing to unstake and it's corresponding deposit.
        /// </summary>
        public static string QueueParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("FastUnstake", "Queue", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Queue
        ///  The map of all accounts wishing to be unstaked.
        /// 
        ///  Keeps track of `AccountId` wishing to unstake and it's corresponding deposit.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U128> Queue(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = FastUnstakeStorage.QueueParams(key);
            return await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U128>(parameters, token);
        }
        
        /// <summary>
        /// >> CounterForQueueParams
        /// Counter for the related counted storage map
        /// </summary>
        public static string CounterForQueueParams()
        {
            return RequestGenerator.GetStorage("FastUnstake", "CounterForQueue", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> CounterForQueue
        /// Counter for the related counted storage map
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> CounterForQueue(CancellationToken token)
        {
            string parameters = FastUnstakeStorage.CounterForQueueParams();
            return await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, token);
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
            return RequestGenerator.GetStorage("FastUnstake", "ErasToCheckPerBlock", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> ErasToCheckPerBlock(CancellationToken token)
        {
            string parameters = FastUnstakeStorage.ErasToCheckPerBlockParams();
            return await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, token);
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
            return new Method(42, "FastUnstake", 0, "register_fast_unstake", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> deregister
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Deregister()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(42, "FastUnstake", 1, "deregister", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> control
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Control(Substrate.NetApi.Model.Types.Primitive.U32 unchecked_eras_to_check)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(unchecked_eras_to_check.Encode());
            return new Method(42, "FastUnstake", 2, "control", byteArray.ToArray());
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
