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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9230
{
    public sealed class SchedulerStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> AgendaParams
        ///  Items to be executed, indexed by the block number that they should be executed on.
        /// </summary>
        public static string AgendaParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Scheduler", "Agenda", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> AgendaDefault
        /// Default value as hex string
        /// </summary>
        public static string AgendaDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Agenda
        ///  Items to be executed, indexed by the block number that they should be executed on.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.pallet_scheduler.ScheduledV3>>> Agenda(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = AgendaParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.pallet_scheduler.ScheduledV3>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> LookupParams
        ///  Lookup from identity to the block number and index of the task.
        /// </summary>
        public static string LookupParams(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> key)
        {
            return RequestGenerator.GetStorage("Scheduler", "Lookup", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> LookupDefault
        /// Default value as hex string
        /// </summary>
        public static string LookupDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Lookup
        ///  Lookup from identity to the block number and index of the task.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> Lookup(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> key, CancellationToken token)
        {
            string parameters = LookupParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockHash, token);
            return result;
        }

        public SchedulerStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class SchedulerConstants
    {
        /// <summary>
        /// >> MaximumWeight
        ///  The maximum weight that may be scheduled per block for any dispatchables of less
        ///  priority than `schedule::HARD_DEADLINE`.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 MaximumWeight()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0x00806E8774010000");
            return result;
        }

        /// <summary>
        /// >> MaxScheduledPerBlock
        ///  The maximum number of scheduled calls in the queue for a single block.
        ///  Not strictly enforced, but used for weight estimation.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxScheduledPerBlock()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x32000000");
            return result;
        }
    }

    public enum SchedulerErrors
    {
        /// <summary>
        /// >> FailedToSchedule
        /// Failed to schedule a call
        /// </summary>
        FailedToSchedule,
        /// <summary>
        /// >> NotFound
        /// Cannot find the scheduled call.
        /// </summary>
        NotFound,
        /// <summary>
        /// >> TargetBlockNumberInPast
        /// Given target block number is in the past.
        /// </summary>
        TargetBlockNumberInPast,
        /// <summary>
        /// >> RescheduleNoChange
        /// Reschedule failed because it does not change scheduled time.
        /// </summary>
        RescheduleNoChange
    }
}