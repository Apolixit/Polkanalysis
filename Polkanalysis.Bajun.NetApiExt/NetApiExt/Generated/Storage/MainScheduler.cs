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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Storage
{
    
    
    public sealed class SchedulerStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public SchedulerStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Scheduler", "Agenda"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substrate.NetApi.Model.Types.Primitive.U32), typeof(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3>>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Scheduler", "Lookup"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>), typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>)));
        }
        
        /// <summary>
        /// >> AgendaParams
        ///  Items to be executed, indexed by the block number that they should be executed on.
        /// </summary>
        public static string AgendaParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Scheduler", "Agenda", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Agenda
        ///  Items to be executed, indexed by the block number that they should be executed on.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3>>> Agenda(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = SchedulerStorage.AgendaParams(key);
            return await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_scheduler.ScheduledV3>>>(parameters, token);
        }
        
        /// <summary>
        /// >> LookupParams
        ///  Lookup from identity to the block number and index of the task.
        /// </summary>
        public static string LookupParams(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> key)
        {
            return RequestGenerator.GetStorage("Scheduler", "Lookup", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Lookup
        ///  Lookup from identity to the block number and index of the task.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> Lookup(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> key, CancellationToken token)
        {
            string parameters = SchedulerStorage.LookupParams(key);
            return await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, token);
        }
    }
    
    public sealed class SchedulerCalls
    {
        
        /// <summary>
        /// >> schedule
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Schedule(Substrate.NetApi.Model.Types.Primitive.U32 when, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> maybe_periodic, Substrate.NetApi.Model.Types.Primitive.U8 priority, Polkanalysis.Bajun.NetApiExt.Generated.Model.frame_support.traits.schedule.EnumMaybeHashed call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(when.Encode());
            byteArray.AddRange(maybe_periodic.Encode());
            byteArray.AddRange(priority.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(9, "Scheduler", 0, "schedule", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> cancel
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Cancel(Substrate.NetApi.Model.Types.Primitive.U32 when, Substrate.NetApi.Model.Types.Primitive.U32 index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(when.Encode());
            byteArray.AddRange(index.Encode());
            return new Method(9, "Scheduler", 1, "cancel", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> schedule_named
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ScheduleNamed(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> id, Substrate.NetApi.Model.Types.Primitive.U32 when, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> maybe_periodic, Substrate.NetApi.Model.Types.Primitive.U8 priority, Polkanalysis.Bajun.NetApiExt.Generated.Model.frame_support.traits.schedule.EnumMaybeHashed call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(id.Encode());
            byteArray.AddRange(when.Encode());
            byteArray.AddRange(maybe_periodic.Encode());
            byteArray.AddRange(priority.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(9, "Scheduler", 2, "schedule_named", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> cancel_named
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method CancelNamed(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(id.Encode());
            return new Method(9, "Scheduler", 3, "cancel_named", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> schedule_after
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ScheduleAfter(Substrate.NetApi.Model.Types.Primitive.U32 after, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> maybe_periodic, Substrate.NetApi.Model.Types.Primitive.U8 priority, Polkanalysis.Bajun.NetApiExt.Generated.Model.frame_support.traits.schedule.EnumMaybeHashed call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(after.Encode());
            byteArray.AddRange(maybe_periodic.Encode());
            byteArray.AddRange(priority.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(9, "Scheduler", 4, "schedule_after", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> schedule_named_after
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ScheduleNamedAfter(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> id, Substrate.NetApi.Model.Types.Primitive.U32 after, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> maybe_periodic, Substrate.NetApi.Model.Types.Primitive.U8 priority, Polkanalysis.Bajun.NetApiExt.Generated.Model.frame_support.traits.schedule.EnumMaybeHashed call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(id.Encode());
            byteArray.AddRange(after.Encode());
            byteArray.AddRange(maybe_periodic.Encode());
            byteArray.AddRange(priority.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(9, "Scheduler", 5, "schedule_named_after", byteArray.ToArray());
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
        RescheduleNoChange,
    }
}
