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


namespace Blazscan.NetApiExt.Generated.Storage
{
    
    
    public sealed class UmpStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public UmpStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Ump", "RelayDispatchQueues"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id), typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Ump", "RelayDispatchQueueSize"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id), typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Ump", "NeedsDispatch"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Ump", "NextDispatchRoundStartWith"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Ump", "Overweight"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Ajuna.NetApi.Model.Types.Primitive.U64), typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Ump", "OverweightCount"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U64)));
        }
        
        /// <summary>
        /// >> RelayDispatchQueuesParams
        ///  The messages waiting to be handled by the relay-chain originating from a certain parachain.
        /// 
        ///  Note that some upward messages might have been already processed by the inclusion logic. E.g.
        ///  channel management messages.
        /// 
        ///  The messages are processed in FIFO order.
        /// </summary>
        public static string RelayDispatchQueuesParams(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Ump", "RelayDispatchQueues", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> RelayDispatchQueues
        ///  The messages waiting to be handled by the relay-chain originating from a certain parachain.
        /// 
        ///  Note that some upward messages might have been already processed by the inclusion logic. E.g.
        ///  channel management messages.
        /// 
        ///  The messages are processed in FIFO order.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>> RelayDispatchQueues(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = UmpStorage.RelayDispatchQueuesParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>>(parameters, token);
        }
        
        /// <summary>
        /// >> RelayDispatchQueueSizeParams
        ///  Size of the dispatch queues. Caches sizes of the queues in `RelayDispatchQueue`.
        /// 
        ///  First item in the tuple is the count of messages and second
        ///  is the total length (in bytes) of the message payloads.
        /// 
        ///  Note that this is an auxiliary mapping: it's possible to tell the byte size and the number of
        ///  messages only looking at `RelayDispatchQueues`. This mapping is separate to avoid the cost of
        ///  loading the whole message queue if only the total size and count are required.
        /// 
        ///  Invariant:
        ///  - The set of keys should exactly match the set of keys of `RelayDispatchQueues`.
        /// </summary>
        public static string RelayDispatchQueueSizeParams(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Ump", "RelayDispatchQueueSize", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> RelayDispatchQueueSize
        ///  Size of the dispatch queues. Caches sizes of the queues in `RelayDispatchQueue`.
        /// 
        ///  First item in the tuple is the count of messages and second
        ///  is the total length (in bytes) of the message payloads.
        /// 
        ///  Note that this is an auxiliary mapping: it's possible to tell the byte size and the number of
        ///  messages only looking at `RelayDispatchQueues`. This mapping is separate to avoid the cost of
        ///  loading the whole message queue if only the total size and count are required.
        /// 
        ///  Invariant:
        ///  - The set of keys should exactly match the set of keys of `RelayDispatchQueues`.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>> RelayDispatchQueueSize(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = UmpStorage.RelayDispatchQueueSizeParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>>(parameters, token);
        }
        
        /// <summary>
        /// >> NeedsDispatchParams
        ///  The ordered list of `ParaId`s that have a `RelayDispatchQueue` entry.
        /// 
        ///  Invariant:
        ///  - The set of items from this vector should be exactly the set of the keys in
        ///    `RelayDispatchQueues` and `RelayDispatchQueueSize`.
        /// </summary>
        public static string NeedsDispatchParams()
        {
            return RequestGenerator.GetStorage("Ump", "NeedsDispatch", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> NeedsDispatch
        ///  The ordered list of `ParaId`s that have a `RelayDispatchQueue` entry.
        /// 
        ///  Invariant:
        ///  - The set of items from this vector should be exactly the set of the keys in
        ///    `RelayDispatchQueues` and `RelayDispatchQueueSize`.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>> NeedsDispatch(CancellationToken token)
        {
            string parameters = UmpStorage.NeedsDispatchParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>>(parameters, token);
        }
        
        /// <summary>
        /// >> NextDispatchRoundStartWithParams
        ///  This is the para that gets will get dispatched first during the next upward dispatchable queue
        ///  execution round.
        /// 
        ///  Invariant:
        ///  - If `Some(para)`, then `para` must be present in `NeedsDispatch`.
        /// </summary>
        public static string NextDispatchRoundStartWithParams()
        {
            return RequestGenerator.GetStorage("Ump", "NextDispatchRoundStartWith", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> NextDispatchRoundStartWith
        ///  This is the para that gets will get dispatched first during the next upward dispatchable queue
        ///  execution round.
        /// 
        ///  Invariant:
        ///  - If `Some(para)`, then `para` must be present in `NeedsDispatch`.
        /// </summary>
        public async Task<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id> NextDispatchRoundStartWith(CancellationToken token)
        {
            string parameters = UmpStorage.NextDispatchRoundStartWithParams();
            return await _client.GetStorageAsync<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(parameters, token);
        }
        
        /// <summary>
        /// >> OverweightParams
        ///  The messages that exceeded max individual message weight budget.
        /// 
        ///  These messages stay there until manually dispatched.
        /// </summary>
        public static string OverweightParams(Ajuna.NetApi.Model.Types.Primitive.U64 key)
        {
            return RequestGenerator.GetStorage("Ump", "Overweight", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Overweight
        ///  The messages that exceeded max individual message weight budget.
        /// 
        ///  These messages stay there until manually dispatched.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>> Overweight(Ajuna.NetApi.Model.Types.Primitive.U64 key, CancellationToken token)
        {
            string parameters = UmpStorage.OverweightParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>>(parameters, token);
        }
        
        /// <summary>
        /// >> OverweightCountParams
        ///  The number of overweight messages ever recorded in `Overweight` (and thus the lowest free
        ///  index).
        /// </summary>
        public static string OverweightCountParams()
        {
            return RequestGenerator.GetStorage("Ump", "OverweightCount", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> OverweightCount
        ///  The number of overweight messages ever recorded in `Overweight` (and thus the lowest free
        ///  index).
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U64> OverweightCount(CancellationToken token)
        {
            string parameters = UmpStorage.OverweightCountParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U64>(parameters, token);
        }
    }
    
    public sealed class UmpCalls
    {
        
        /// <summary>
        /// >> service_overweight
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ServiceOverweight(Ajuna.NetApi.Model.Types.Primitive.U64 index, Blazscan.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight weight_limit)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(weight_limit.Encode());
            return new Method(59, "Ump", 0, "service_overweight", byteArray.ToArray());
        }
    }
    
    public enum UmpErrors
    {
        
        /// <summary>
        /// >> UnknownMessageIndex
        /// The message index given is unknown.
        /// </summary>
        UnknownMessageIndex,
        
        /// <summary>
        /// >> WeightOverLimit
        /// The amount of weight given is possibly not enough for executing the message.
        /// </summary>
        WeightOverLimit,
    }
}
