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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9170
{
    public sealed class UmpStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> RelayDispatchQueuesParams
        ///  The messages waiting to be handled by the relay-chain originating from a certain parachain.
        /// 
        ///  Note that some upward messages might have been already processed by the inclusion logic. E.g.
        ///  channel management messages.
        /// 
        ///  The messages are processed in FIFO order.
        /// </summary>
        public static string RelayDispatchQueuesParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Ump", "RelayDispatchQueues", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> RelayDispatchQueuesDefault
        /// Default value as hex string
        /// </summary>
        public static string RelayDispatchQueuesDefault()
        {
            return "0x00";
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
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>> RelayDispatchQueues(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = RelayDispatchQueuesParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>>(parameters, blockHash, token);
            return result;
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
        public static string RelayDispatchQueueSizeParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Ump", "RelayDispatchQueueSize", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> RelayDispatchQueueSizeDefault
        /// Default value as hex string
        /// </summary>
        public static string RelayDispatchQueueSizeDefault()
        {
            return "0x0000000000000000";
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
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> RelayDispatchQueueSize(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = RelayDispatchQueueSizeParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockHash, token);
            return result;
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
            return RequestGenerator.GetStorage("Ump", "NeedsDispatch", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> NeedsDispatchDefault
        /// Default value as hex string
        /// </summary>
        public static string NeedsDispatchDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> NeedsDispatch
        ///  The ordered list of `ParaId`s that have a `RelayDispatchQueue` entry.
        /// 
        ///  Invariant:
        ///  - The set of items from this vector should be exactly the set of the keys in
        ///    `RelayDispatchQueues` and `RelayDispatchQueueSize`.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_parachain.primitives.Id>> NeedsDispatch(CancellationToken token)
        {
            string parameters = NeedsDispatchParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_parachain.primitives.Id>>(parameters, blockHash, token);
            return result;
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
            return RequestGenerator.GetStorage("Ump", "NextDispatchRoundStartWith", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> NextDispatchRoundStartWithDefault
        /// Default value as hex string
        /// </summary>
        public static string NextDispatchRoundStartWithDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> NextDispatchRoundStartWith
        ///  This is the para that gets will get dispatched first during the next upward dispatchable queue
        ///  execution round.
        /// 
        ///  Invariant:
        ///  - If `Some(para)`, then `para` must be present in `NeedsDispatch`.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_parachain.primitives.Id> NextDispatchRoundStartWith(CancellationToken token)
        {
            string parameters = NextDispatchRoundStartWithParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_parachain.primitives.Id>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> OverweightParams
        ///  The messages that exceeded max individual message weight budget.
        /// 
        ///  These messages stay there until manually dispatched.
        /// </summary>
        public static string OverweightParams(Substrate.NetApi.Model.Types.Primitive.U64 key)
        {
            return RequestGenerator.GetStorage("Ump", "Overweight", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> OverweightDefault
        /// Default value as hex string
        /// </summary>
        public static string OverweightDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Overweight
        ///  The messages that exceeded max individual message weight budget.
        /// 
        ///  These messages stay there until manually dispatched.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>> Overweight(Substrate.NetApi.Model.Types.Primitive.U64 key, CancellationToken token)
        {
            string parameters = OverweightParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> OverweightCountParams
        ///  The number of overweight messages ever recorded in `Overweight` (and thus the lowest free
        ///  index).
        /// </summary>
        public static string OverweightCountParams()
        {
            return RequestGenerator.GetStorage("Ump", "OverweightCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> OverweightCountDefault
        /// Default value as hex string
        /// </summary>
        public static string OverweightCountDefault()
        {
            return "0x0000000000000000";
        }

        /// <summary>
        /// >> OverweightCount
        ///  The number of overweight messages ever recorded in `Overweight` (and thus the lowest free
        ///  index).
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U64> OverweightCount(CancellationToken token)
        {
            string parameters = OverweightCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U64>(parameters, blockHash, token);
            return result;
        }

        public UmpStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class UmpConstants
    {
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
        WeightOverLimit
    }
}