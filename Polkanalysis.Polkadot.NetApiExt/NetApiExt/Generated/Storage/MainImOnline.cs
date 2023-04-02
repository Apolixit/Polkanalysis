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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage
{
    
    
    public sealed class ImOnlineStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public ImOnlineStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ImOnline", "HeartbeatAfter"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ImOnline", "Keys"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec.WeakBoundedVecT5)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ImOnline", "ReceivedHeartbeats"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>), typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support.traits.misc.WrapperOpaque)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ImOnline", "AuthoredBlocks"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>), typeof(Substrate.NetApi.Model.Types.Primitive.U32)));
        }
        
        /// <summary>
        /// >> HeartbeatAfterParams
        ///  The block number after which it's ok to send heartbeats in the current
        ///  session.
        /// 
        ///  At the beginning of each session we set this to a value that should fall
        ///  roughly in the middle of the session duration. The idea is to first wait for
        ///  the validators to produce a block in the current session, so that the
        ///  heartbeat later on will not be necessary.
        /// 
        ///  This value will only be used as a fallback if we fail to get a proper session
        ///  progress estimate from `NextSessionRotation`, as those estimates should be
        ///  more accurate then the value we calculate for `HeartbeatAfter`.
        /// </summary>
        public static string HeartbeatAfterParams()
        {
            return RequestGenerator.GetStorage("ImOnline", "HeartbeatAfter", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> HeartbeatAfterDefault
        /// Default value as hex string
        /// </summary>
        public static string HeartbeatAfterDefault()
        {
            return "0x00000000";
        }
        
        /// <summary>
        /// >> HeartbeatAfter
        ///  The block number after which it's ok to send heartbeats in the current
        ///  session.
        /// 
        ///  At the beginning of each session we set this to a value that should fall
        ///  roughly in the middle of the session duration. The idea is to first wait for
        ///  the validators to produce a block in the current session, so that the
        ///  heartbeat later on will not be necessary.
        /// 
        ///  This value will only be used as a fallback if we fail to get a proper session
        ///  progress estimate from `NextSessionRotation`, as those estimates should be
        ///  more accurate then the value we calculate for `HeartbeatAfter`.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> HeartbeatAfter(CancellationToken token)
        {
            string parameters = ImOnlineStorage.HeartbeatAfterParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> KeysParams
        ///  The current set of keys that may issue a heartbeat.
        /// </summary>
        public static string KeysParams()
        {
            return RequestGenerator.GetStorage("ImOnline", "Keys", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> KeysDefault
        /// Default value as hex string
        /// </summary>
        public static string KeysDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Keys
        ///  The current set of keys that may issue a heartbeat.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec.WeakBoundedVecT5> Keys(CancellationToken token)
        {
            string parameters = ImOnlineStorage.KeysParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec.WeakBoundedVecT5>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> ReceivedHeartbeatsParams
        ///  For each session index, we keep a mapping of `SessionIndex` and `AuthIndex` to
        ///  `WrapperOpaque<BoundedOpaqueNetworkState>`.
        /// </summary>
        public static string ReceivedHeartbeatsParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32> key)
        {
            return RequestGenerator.GetStorage("ImOnline", "ReceivedHeartbeats", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, key.Value);
        }
        
        /// <summary>
        /// >> ReceivedHeartbeatsDefault
        /// Default value as hex string
        /// </summary>
        public static string ReceivedHeartbeatsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> ReceivedHeartbeats
        ///  For each session index, we keep a mapping of `SessionIndex` and `AuthIndex` to
        ///  `WrapperOpaque<BoundedOpaqueNetworkState>`.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support.traits.misc.WrapperOpaque> ReceivedHeartbeats(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32> key, CancellationToken token)
        {
            string parameters = ImOnlineStorage.ReceivedHeartbeatsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support.traits.misc.WrapperOpaque>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> AuthoredBlocksParams
        ///  For each session index, we keep a mapping of `ValidatorId<T>` to the
        ///  number of blocks authored by the given authority.
        /// </summary>
        public static string AuthoredBlocksParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> key)
        {
            return RequestGenerator.GetStorage("ImOnline", "AuthoredBlocks", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, key.Value);
        }
        
        /// <summary>
        /// >> AuthoredBlocksDefault
        /// Default value as hex string
        /// </summary>
        public static string AuthoredBlocksDefault()
        {
            return "0x00000000";
        }
        
        /// <summary>
        /// >> AuthoredBlocks
        ///  For each session index, we keep a mapping of `ValidatorId<T>` to the
        ///  number of blocks authored by the given authority.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> AuthoredBlocks(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> key, CancellationToken token)
        {
            string parameters = ImOnlineStorage.AuthoredBlocksParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, token);
            return result;
        }
    }
    
    public sealed class ImOnlineCalls
    {
        
        /// <summary>
        /// >> heartbeat
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Heartbeat(Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_im_online.Heartbeat heartbeat, Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_im_online.sr25519.app_sr25519.Signature signature)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(heartbeat.Encode());
            byteArray.AddRange(signature.Encode());
            return new Method(12, "ImOnline", 0, "heartbeat", byteArray.ToArray());
        }
    }
    
    public sealed class ImOnlineConstants
    {
        
        /// <summary>
        /// >> UnsignedPriority
        ///  A configuration for base priority of unsigned transactions.
        /// 
        ///  This is exposed so that it can be tuned for particular runtime, when
        ///  multiple pallets send unsigned transactions.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 UnsignedPriority()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0xFFFFFFFFFFFFFFFF");
            return result;
        }
    }
    
    public enum ImOnlineErrors
    {
        
        /// <summary>
        /// >> InvalidKey
        /// Non existent public key.
        /// </summary>
        InvalidKey,
        
        /// <summary>
        /// >> DuplicatedHeartbeat
        /// Duplicated heartbeat.
        /// </summary>
        DuplicatedHeartbeat,
    }
}
