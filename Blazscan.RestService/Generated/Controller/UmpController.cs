//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using Ajuna.ServiceLayer.Attributes;
using Blazscan.RestService.Generated.Storage;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Blazscan.RestService.Generated.Controller
{
    
    
    /// <summary>
    /// UmpController controller to access storages.
    /// </summary>
    [ApiController()]
    [Route("[controller]")]
    public sealed class UmpController : ControllerBase
    {
        
        private IUmpStorage _umpStorage;
        
        /// <summary>
        /// UmpController constructor.
        /// </summary>
        public UmpController(IUmpStorage umpStorage)
        {
            _umpStorage = umpStorage;
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
        [HttpGet("RelayDispatchQueues")]
        [ProducesResponseType(typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>), 200)]
        [StorageKeyBuilder(typeof(Blazscan.NetApiExt.Generated.Storage.UmpStorage), "RelayDispatchQueuesParams", typeof(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id))]
        public IActionResult GetRelayDispatchQueues(string key)
        {
            return this.Ok(_umpStorage.GetRelayDispatchQueues(key));
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
        [HttpGet("RelayDispatchQueueSize")]
        [ProducesResponseType(typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>), 200)]
        [StorageKeyBuilder(typeof(Blazscan.NetApiExt.Generated.Storage.UmpStorage), "RelayDispatchQueueSizeParams", typeof(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id))]
        public IActionResult GetRelayDispatchQueueSize(string key)
        {
            return this.Ok(_umpStorage.GetRelayDispatchQueueSize(key));
        }
        
        /// <summary>
        /// >> NeedsDispatch
        ///  The ordered list of `ParaId`s that have a `RelayDispatchQueue` entry.
        /// 
        ///  Invariant:
        ///  - The set of items from this vector should be exactly the set of the keys in
        ///    `RelayDispatchQueues` and `RelayDispatchQueueSize`.
        /// </summary>
        [HttpGet("NeedsDispatch")]
        [ProducesResponseType(typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>), 200)]
        [StorageKeyBuilder(typeof(Blazscan.NetApiExt.Generated.Storage.UmpStorage), "NeedsDispatchParams")]
        public IActionResult GetNeedsDispatch()
        {
            return this.Ok(_umpStorage.GetNeedsDispatch());
        }
        
        /// <summary>
        /// >> NextDispatchRoundStartWith
        ///  This is the para that gets will get dispatched first during the next upward dispatchable queue
        ///  execution round.
        /// 
        ///  Invariant:
        ///  - If `Some(para)`, then `para` must be present in `NeedsDispatch`.
        /// </summary>
        [HttpGet("NextDispatchRoundStartWith")]
        [ProducesResponseType(typeof(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id), 200)]
        [StorageKeyBuilder(typeof(Blazscan.NetApiExt.Generated.Storage.UmpStorage), "NextDispatchRoundStartWithParams")]
        public IActionResult GetNextDispatchRoundStartWith()
        {
            return this.Ok(_umpStorage.GetNextDispatchRoundStartWith());
        }
        
        /// <summary>
        /// >> Overweight
        ///  The messages that exceeded max individual message weight budget.
        /// 
        ///  These messages stay there until manually dispatched.
        /// </summary>
        [HttpGet("Overweight")]
        [ProducesResponseType(typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>), 200)]
        [StorageKeyBuilder(typeof(Blazscan.NetApiExt.Generated.Storage.UmpStorage), "OverweightParams", typeof(Ajuna.NetApi.Model.Types.Primitive.U64))]
        public IActionResult GetOverweight(string key)
        {
            return this.Ok(_umpStorage.GetOverweight(key));
        }
        
        /// <summary>
        /// >> OverweightCount
        ///  The number of overweight messages ever recorded in `Overweight` (and thus the lowest free
        ///  index).
        /// </summary>
        [HttpGet("OverweightCount")]
        [ProducesResponseType(typeof(Ajuna.NetApi.Model.Types.Primitive.U64), 200)]
        [StorageKeyBuilder(typeof(Blazscan.NetApiExt.Generated.Storage.UmpStorage), "OverweightCountParams")]
        public IActionResult GetOverweightCount()
        {
            return this.Ok(_umpStorage.GetOverweightCount());
        }
    }
}
