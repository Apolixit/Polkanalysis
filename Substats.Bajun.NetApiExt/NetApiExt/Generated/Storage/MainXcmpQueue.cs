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


namespace Substats.Bajun.NetApiExt.Generated.Storage
{
    
    
    public sealed class XcmpQueueStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public XcmpQueueStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "InboundXcmpStatus"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.InboundChannelDetails>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "InboundXcmpMessages"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat,
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U32>), typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "OutboundXcmpStatus"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.OutboundChannelDetails>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "OutboundXcmpMessages"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat,
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U16>), typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "SignalMessages"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id), typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "QueueConfig"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.QueueConfigData)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "Overweight"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Ajuna.NetApi.Model.Types.Primitive.U64), typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "OverweightCount"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U64)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "QueueSuspended"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.Bool)));
        }
        
        /// <summary>
        /// >> InboundXcmpStatusParams
        ///  Status of the inbound XCMP channels.
        /// </summary>
        public static string InboundXcmpStatusParams()
        {
            return RequestGenerator.GetStorage("XcmpQueue", "InboundXcmpStatus", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> InboundXcmpStatus
        ///  Status of the inbound XCMP channels.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.InboundChannelDetails>> InboundXcmpStatus(CancellationToken token)
        {
            string parameters = XcmpQueueStorage.InboundXcmpStatusParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.InboundChannelDetails>>(parameters, token);
        }
        
        /// <summary>
        /// >> InboundXcmpMessagesParams
        ///  Inbound aggregate XCMP messages. It can only be one per ParaId/block.
        /// </summary>
        public static string InboundXcmpMessagesParams(Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U32> key)
        {
            return RequestGenerator.GetStorage("XcmpQueue", "InboundXcmpMessages", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat,
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, key.Value);
        }
        
        /// <summary>
        /// >> InboundXcmpMessages
        ///  Inbound aggregate XCMP messages. It can only be one per ParaId/block.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> InboundXcmpMessages(Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U32> key, CancellationToken token)
        {
            string parameters = XcmpQueueStorage.InboundXcmpMessagesParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>(parameters, token);
        }
        
        /// <summary>
        /// >> OutboundXcmpStatusParams
        ///  The non-empty XCMP channels in order of becoming non-empty, and the index of the first
        ///  and last outbound message. If the two indices are equal, then it indicates an empty
        ///  queue and there must be a non-`Ok` `OutboundStatus`. We assume queues grow no greater
        ///  than 65535 items. Queue indices for normal messages begin at one; zero is reserved in
        ///  case of the need to send a high-priority signal message this block.
        ///  The bool is true if there is a signal message waiting to be sent.
        /// </summary>
        public static string OutboundXcmpStatusParams()
        {
            return RequestGenerator.GetStorage("XcmpQueue", "OutboundXcmpStatus", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> OutboundXcmpStatus
        ///  The non-empty XCMP channels in order of becoming non-empty, and the index of the first
        ///  and last outbound message. If the two indices are equal, then it indicates an empty
        ///  queue and there must be a non-`Ok` `OutboundStatus`. We assume queues grow no greater
        ///  than 65535 items. Queue indices for normal messages begin at one; zero is reserved in
        ///  case of the need to send a high-priority signal message this block.
        ///  The bool is true if there is a signal message waiting to be sent.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.OutboundChannelDetails>> OutboundXcmpStatus(CancellationToken token)
        {
            string parameters = XcmpQueueStorage.OutboundXcmpStatusParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.OutboundChannelDetails>>(parameters, token);
        }
        
        /// <summary>
        /// >> OutboundXcmpMessagesParams
        ///  The messages outbound in a given XCMP channel.
        /// </summary>
        public static string OutboundXcmpMessagesParams(Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U16> key)
        {
            return RequestGenerator.GetStorage("XcmpQueue", "OutboundXcmpMessages", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat,
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, key.Value);
        }
        
        /// <summary>
        /// >> OutboundXcmpMessages
        ///  The messages outbound in a given XCMP channel.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> OutboundXcmpMessages(Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U16> key, CancellationToken token)
        {
            string parameters = XcmpQueueStorage.OutboundXcmpMessagesParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>(parameters, token);
        }
        
        /// <summary>
        /// >> SignalMessagesParams
        ///  Any signal messages waiting to be sent.
        /// </summary>
        public static string SignalMessagesParams(Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("XcmpQueue", "SignalMessages", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> SignalMessages
        ///  Any signal messages waiting to be sent.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> SignalMessages(Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = XcmpQueueStorage.SignalMessagesParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>(parameters, token);
        }
        
        /// <summary>
        /// >> QueueConfigParams
        ///  The configuration which controls the dynamics of the outbound queue.
        /// </summary>
        public static string QueueConfigParams()
        {
            return RequestGenerator.GetStorage("XcmpQueue", "QueueConfig", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> QueueConfig
        ///  The configuration which controls the dynamics of the outbound queue.
        /// </summary>
        public async Task<Substats.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.QueueConfigData> QueueConfig(CancellationToken token)
        {
            string parameters = XcmpQueueStorage.QueueConfigParams();
            return await _client.GetStorageAsync<Substats.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.QueueConfigData>(parameters, token);
        }
        
        /// <summary>
        /// >> OverweightParams
        ///  The messages that exceeded max individual message weight budget.
        /// 
        ///  These message stay in this storage map until they are manually dispatched via
        ///  `service_overweight`.
        /// </summary>
        public static string OverweightParams(Ajuna.NetApi.Model.Types.Primitive.U64 key)
        {
            return RequestGenerator.GetStorage("XcmpQueue", "Overweight", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Overweight
        ///  The messages that exceeded max individual message weight budget.
        /// 
        ///  These message stay in this storage map until they are manually dispatched via
        ///  `service_overweight`.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>> Overweight(Ajuna.NetApi.Model.Types.Primitive.U64 key, CancellationToken token)
        {
            string parameters = XcmpQueueStorage.OverweightParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>>(parameters, token);
        }
        
        /// <summary>
        /// >> OverweightCountParams
        ///  The number of overweight messages ever recorded in `Overweight`. Also doubles as the next
        ///  available free overweight index.
        /// </summary>
        public static string OverweightCountParams()
        {
            return RequestGenerator.GetStorage("XcmpQueue", "OverweightCount", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> OverweightCount
        ///  The number of overweight messages ever recorded in `Overweight`. Also doubles as the next
        ///  available free overweight index.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U64> OverweightCount(CancellationToken token)
        {
            string parameters = XcmpQueueStorage.OverweightCountParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U64>(parameters, token);
        }
        
        /// <summary>
        /// >> QueueSuspendedParams
        ///  Whether or not the XCMP queue is suspended from executing incoming XCMs or not.
        /// </summary>
        public static string QueueSuspendedParams()
        {
            return RequestGenerator.GetStorage("XcmpQueue", "QueueSuspended", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> QueueSuspended
        ///  Whether or not the XCMP queue is suspended from executing incoming XCMs or not.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.Bool> QueueSuspended(CancellationToken token)
        {
            string parameters = XcmpQueueStorage.QueueSuspendedParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.Bool>(parameters, token);
        }
    }
    
    public sealed class XcmpQueueCalls
    {
        
        /// <summary>
        /// >> service_overweight
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ServiceOverweight(Ajuna.NetApi.Model.Types.Primitive.U64 index, Ajuna.NetApi.Model.Types.Primitive.U64 weight_limit)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(weight_limit.Encode());
            return new Method(30, "XcmpQueue", 0, "service_overweight", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> suspend_xcm_execution
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SuspendXcmExecution()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(30, "XcmpQueue", 1, "suspend_xcm_execution", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> resume_xcm_execution
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ResumeXcmExecution()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(30, "XcmpQueue", 2, "resume_xcm_execution", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> update_suspend_threshold
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method UpdateSuspendThreshold(Ajuna.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(30, "XcmpQueue", 3, "update_suspend_threshold", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> update_drop_threshold
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method UpdateDropThreshold(Ajuna.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(30, "XcmpQueue", 4, "update_drop_threshold", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> update_resume_threshold
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method UpdateResumeThreshold(Ajuna.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(30, "XcmpQueue", 5, "update_resume_threshold", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> update_threshold_weight
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method UpdateThresholdWeight(Ajuna.NetApi.Model.Types.Primitive.U64 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(30, "XcmpQueue", 6, "update_threshold_weight", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> update_weight_restrict_decay
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method UpdateWeightRestrictDecay(Ajuna.NetApi.Model.Types.Primitive.U64 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(30, "XcmpQueue", 7, "update_weight_restrict_decay", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> update_xcmp_max_individual_weight
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method UpdateXcmpMaxIndividualWeight(Ajuna.NetApi.Model.Types.Primitive.U64 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(30, "XcmpQueue", 8, "update_xcmp_max_individual_weight", byteArray.ToArray());
        }
    }
    
    public enum XcmpQueueErrors
    {
        
        /// <summary>
        /// >> FailedToSend
        /// Failed to send XCM message.
        /// </summary>
        FailedToSend,
        
        /// <summary>
        /// >> BadXcmOrigin
        /// Bad XCM origin.
        /// </summary>
        BadXcmOrigin,
        
        /// <summary>
        /// >> BadXcm
        /// Bad XCM data.
        /// </summary>
        BadXcm,
        
        /// <summary>
        /// >> BadOverweightIndex
        /// Bad overweight index.
        /// </summary>
        BadOverweightIndex,
        
        /// <summary>
        /// >> WeightOverLimit
        /// Provided weight is possibly not enough to execute the message.
        /// </summary>
        WeightOverLimit,
    }
}
