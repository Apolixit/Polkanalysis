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
    /// ParaSchedulerController controller to access storages.
    /// </summary>
    [ApiController()]
    [Route("[controller]")]
    public sealed class ParaSchedulerController : ControllerBase
    {
        
        private IParaSchedulerStorage _paraSchedulerStorage;
        
        /// <summary>
        /// ParaSchedulerController constructor.
        /// </summary>
        public ParaSchedulerController(IParaSchedulerStorage paraSchedulerStorage)
        {
            _paraSchedulerStorage = paraSchedulerStorage;
        }
        
        /// <summary>
        /// >> ValidatorGroups
        ///  All the validator groups. One for each core. Indices are into `ActiveValidators` - not the
        ///  broader set of Polkadot validators, but instead just the subset used for parachains during
        ///  this session.
        /// 
        ///  Bound: The number of cores is the sum of the numbers of parachains and parathread multiplexers.
        ///  Reasonably, 100-1000. The dominant factor is the number of validators: safe upper bound at 10k.
        /// </summary>
        [HttpGet("ValidatorGroups")]
        [ProducesResponseType(typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex>>), 200)]
        [StorageKeyBuilder(typeof(Blazscan.NetApiExt.Generated.Storage.ParaSchedulerStorage), "ValidatorGroupsParams")]
        public IActionResult GetValidatorGroups()
        {
            return this.Ok(_paraSchedulerStorage.GetValidatorGroups());
        }
        
        /// <summary>
        /// >> ParathreadQueue
        ///  A queue of upcoming claims and which core they should be mapped onto.
        /// 
        ///  The number of queued claims is bounded at the `scheduling_lookahead`
        ///  multiplied by the number of parathread multiplexer cores. Reasonably, 10 * 50 = 500.
        /// </summary>
        [HttpGet("ParathreadQueue")]
        [ProducesResponseType(typeof(Blazscan.NetApiExt.Generated.Model.polkadot_runtime_parachains.scheduler.ParathreadClaimQueue), 200)]
        [StorageKeyBuilder(typeof(Blazscan.NetApiExt.Generated.Storage.ParaSchedulerStorage), "ParathreadQueueParams")]
        public IActionResult GetParathreadQueue()
        {
            return this.Ok(_paraSchedulerStorage.GetParathreadQueue());
        }
        
        /// <summary>
        /// >> AvailabilityCores
        ///  One entry for each availability core. Entries are `None` if the core is not currently occupied. Can be
        ///  temporarily `Some` if scheduled but not occupied.
        ///  The i'th parachain belongs to the i'th core, with the remaining cores all being
        ///  parathread-multiplexers.
        /// 
        ///  Bounded by the maximum of either of these two values:
        ///    * The number of parachains and parathread multiplexers
        ///    * The number of validators divided by `configuration.max_validators_per_core`.
        /// </summary>
        [HttpGet("AvailabilityCores")]
        [ProducesResponseType(typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseOpt<Blazscan.NetApiExt.Generated.Model.polkadot_primitives.v2.EnumCoreOccupied>>), 200)]
        [StorageKeyBuilder(typeof(Blazscan.NetApiExt.Generated.Storage.ParaSchedulerStorage), "AvailabilityCoresParams")]
        public IActionResult GetAvailabilityCores()
        {
            return this.Ok(_paraSchedulerStorage.GetAvailabilityCores());
        }
        
        /// <summary>
        /// >> ParathreadClaimIndex
        ///  An index used to ensure that only one claim on a parathread exists in the queue or is
        ///  currently being handled by an occupied core.
        /// 
        ///  Bounded by the number of parathread cores and scheduling lookahead. Reasonably, 10 * 50 = 500.
        /// </summary>
        [HttpGet("ParathreadClaimIndex")]
        [ProducesResponseType(typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>), 200)]
        [StorageKeyBuilder(typeof(Blazscan.NetApiExt.Generated.Storage.ParaSchedulerStorage), "ParathreadClaimIndexParams")]
        public IActionResult GetParathreadClaimIndex()
        {
            return this.Ok(_paraSchedulerStorage.GetParathreadClaimIndex());
        }
        
        /// <summary>
        /// >> SessionStartBlock
        ///  The block number where the session start occurred. Used to track how many group rotations have occurred.
        /// 
        ///  Note that in the context of parachains modules the session change is signaled during
        ///  the block and enacted at the end of the block (at the finalization stage, to be exact).
        ///  Thus for all intents and purposes the effect of the session change is observed at the
        ///  block following the session change, block number of which we save in this storage value.
        /// </summary>
        [HttpGet("SessionStartBlock")]
        [ProducesResponseType(typeof(Ajuna.NetApi.Model.Types.Primitive.U32), 200)]
        [StorageKeyBuilder(typeof(Blazscan.NetApiExt.Generated.Storage.ParaSchedulerStorage), "SessionStartBlockParams")]
        public IActionResult GetSessionStartBlock()
        {
            return this.Ok(_paraSchedulerStorage.GetSessionStartBlock());
        }
        
        /// <summary>
        /// >> Scheduled
        ///  Currently scheduled cores - free but up to be occupied.
        /// 
        ///  Bounded by the number of cores: one for each parachain and parathread multiplexer.
        /// 
        ///  The value contained here will not be valid after the end of a block. Runtime APIs should be used to determine scheduled cores/
        ///  for the upcoming block.
        /// </summary>
        [HttpGet("Scheduled")]
        [ProducesResponseType(typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.polkadot_runtime_parachains.scheduler.CoreAssignment>), 200)]
        [StorageKeyBuilder(typeof(Blazscan.NetApiExt.Generated.Storage.ParaSchedulerStorage), "ScheduledParams")]
        public IActionResult GetScheduled()
        {
            return this.Ok(_paraSchedulerStorage.GetScheduled());
        }
    }
}
