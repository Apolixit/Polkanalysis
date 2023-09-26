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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9300
{
    public sealed class ParaSchedulerStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> ValidatorGroupsParams
        ///  All the validator groups. One for each core. Indices are into `ActiveValidators` - not the
        ///  broader set of Polkadot validators, but instead just the subset used for parachains during
        ///  this session.
        /// 
        ///  Bound: The number of cores is the sum of the numbers of parachains and parathread multiplexers.
        ///  Reasonably, 100-1000. The dominant factor is the number of validators: safe upper bound at 10k.
        /// </summary>
        public static string ValidatorGroupsParams()
        {
            return RequestGenerator.GetStorage("ParaScheduler", "ValidatorGroups", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ValidatorGroupsDefault
        /// Default value as hex string
        /// </summary>
        public static string ValidatorGroupsDefault()
        {
            return "0x00";
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
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_primitives.v2.ValidatorIndex>>> ValidatorGroups(CancellationToken token)
        {
            string parameters = ValidatorGroupsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_primitives.v2.ValidatorIndex>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ParathreadQueueParams
        ///  A queue of upcoming claims and which core they should be mapped onto.
        /// 
        ///  The number of queued claims is bounded at the `scheduling_lookahead`
        ///  multiplied by the number of parathread multiplexer cores. Reasonably, 10 * 50 = 500.
        /// </summary>
        public static string ParathreadQueueParams()
        {
            return RequestGenerator.GetStorage("ParaScheduler", "ParathreadQueue", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ParathreadQueueDefault
        /// Default value as hex string
        /// </summary>
        public static string ParathreadQueueDefault()
        {
            return "0x0000000000";
        }

        /// <summary>
        /// >> ParathreadQueue
        ///  A queue of upcoming claims and which core they should be mapped onto.
        /// 
        ///  The number of queued claims is bounded at the `scheduling_lookahead`
        ///  multiplied by the number of parathread multiplexer cores. Reasonably, 10 * 50 = 500.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_runtime_parachains.scheduler.ParathreadClaimQueue> ParathreadQueue(CancellationToken token)
        {
            string parameters = ParathreadQueueParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_runtime_parachains.scheduler.ParathreadClaimQueue>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> AvailabilityCoresParams
        ///  One entry for each availability core. Entries are `None` if the core is not currently occupied. Can be
        ///  temporarily `Some` if scheduled but not occupied.
        ///  The i'th parachain belongs to the i'th core, with the remaining cores all being
        ///  parathread-multiplexers.
        /// 
        ///  Bounded by the maximum of either of these two values:
        ///    * The number of parachains and parathread multiplexers
        ///    * The number of validators divided by `configuration.max_validators_per_core`.
        /// </summary>
        public static string AvailabilityCoresParams()
        {
            return RequestGenerator.GetStorage("ParaScheduler", "AvailabilityCores", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> AvailabilityCoresDefault
        /// Default value as hex string
        /// </summary>
        public static string AvailabilityCoresDefault()
        {
            return "0x00";
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
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_primitives.v2.EnumCoreOccupied>>> AvailabilityCores(CancellationToken token)
        {
            string parameters = AvailabilityCoresParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_primitives.v2.EnumCoreOccupied>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ParathreadClaimIndexParams
        ///  An index used to ensure that only one claim on a parathread exists in the queue or is
        ///  currently being handled by an occupied core.
        /// 
        ///  Bounded by the number of parathread cores and scheduling lookahead. Reasonably, 10 * 50 = 500.
        /// </summary>
        public static string ParathreadClaimIndexParams()
        {
            return RequestGenerator.GetStorage("ParaScheduler", "ParathreadClaimIndex", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ParathreadClaimIndexDefault
        /// Default value as hex string
        /// </summary>
        public static string ParathreadClaimIndexDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ParathreadClaimIndex
        ///  An index used to ensure that only one claim on a parathread exists in the queue or is
        ///  currently being handled by an occupied core.
        /// 
        ///  Bounded by the number of parathread cores and scheduling lookahead. Reasonably, 10 * 50 = 500.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_parachain.primitives.Id>> ParathreadClaimIndex(CancellationToken token)
        {
            string parameters = ParathreadClaimIndexParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_parachain.primitives.Id>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SessionStartBlockParams
        ///  The block number where the session start occurred. Used to track how many group rotations have occurred.
        /// 
        ///  Note that in the context of parachains modules the session change is signaled during
        ///  the block and enacted at the end of the block (at the finalization stage, to be exact).
        ///  Thus for all intents and purposes the effect of the session change is observed at the
        ///  block following the session change, block number of which we save in this storage value.
        /// </summary>
        public static string SessionStartBlockParams()
        {
            return RequestGenerator.GetStorage("ParaScheduler", "SessionStartBlock", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> SessionStartBlockDefault
        /// Default value as hex string
        /// </summary>
        public static string SessionStartBlockDefault()
        {
            return "0x00000000";
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
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> SessionStartBlock(CancellationToken token)
        {
            string parameters = SessionStartBlockParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ScheduledParams
        ///  Currently scheduled cores - free but up to be occupied.
        /// 
        ///  Bounded by the number of cores: one for each parachain and parathread multiplexer.
        /// 
        ///  The value contained here will not be valid after the end of a block. Runtime APIs should be used to determine scheduled cores/
        ///  for the upcoming block.
        /// </summary>
        public static string ScheduledParams()
        {
            return RequestGenerator.GetStorage("ParaScheduler", "Scheduled", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ScheduledDefault
        /// Default value as hex string
        /// </summary>
        public static string ScheduledDefault()
        {
            return "0x00";
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
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_runtime_parachains.scheduler.CoreAssignment>> Scheduled(CancellationToken token)
        {
            string parameters = ScheduledParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_runtime_parachains.scheduler.CoreAssignment>>(parameters, blockHash, token);
            return result;
        }

        public ParaSchedulerStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class ParaSchedulerConstants
    {
    }
}