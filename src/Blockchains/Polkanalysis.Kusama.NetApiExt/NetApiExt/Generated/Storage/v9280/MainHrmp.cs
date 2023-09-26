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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9280
{
    public sealed class HrmpStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> HrmpOpenChannelRequestsParams
        ///  The set of pending HRMP open channel requests.
        /// 
        ///  The set is accompanied by a list for iteration.
        /// 
        ///  Invariant:
        ///  - There are no channels that exists in list but not in the set and vice versa.
        /// </summary>
        public static string HrmpOpenChannelRequestsParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.HrmpChannelId key)
        {
            return RequestGenerator.GetStorage("Hrmp", "HrmpOpenChannelRequests", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> HrmpOpenChannelRequestsDefault
        /// Default value as hex string
        /// </summary>
        public static string HrmpOpenChannelRequestsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> HrmpOpenChannelRequests
        ///  The set of pending HRMP open channel requests.
        /// 
        ///  The set is accompanied by a list for iteration.
        /// 
        ///  Invariant:
        ///  - There are no channels that exists in list but not in the set and vice versa.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_runtime_parachains.hrmp.HrmpOpenChannelRequest> HrmpOpenChannelRequests(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.HrmpChannelId key, CancellationToken token)
        {
            string parameters = HrmpOpenChannelRequestsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_runtime_parachains.hrmp.HrmpOpenChannelRequest>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> HrmpOpenChannelRequestsListParams
        /// </summary>
        public static string HrmpOpenChannelRequestsListParams()
        {
            return RequestGenerator.GetStorage("Hrmp", "HrmpOpenChannelRequestsList", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> HrmpOpenChannelRequestsListDefault
        /// Default value as hex string
        /// </summary>
        public static string HrmpOpenChannelRequestsListDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> HrmpOpenChannelRequestsList
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.HrmpChannelId>> HrmpOpenChannelRequestsList(CancellationToken token)
        {
            string parameters = HrmpOpenChannelRequestsListParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.HrmpChannelId>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> HrmpOpenChannelRequestCountParams
        ///  This mapping tracks how many open channel requests are initiated by a given sender para.
        ///  Invariant: `HrmpOpenChannelRequests` should contain the same number of items that has
        ///  `(X, _)` as the number of `HrmpOpenChannelRequestCount` for `X`.
        /// </summary>
        public static string HrmpOpenChannelRequestCountParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Hrmp", "HrmpOpenChannelRequestCount", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> HrmpOpenChannelRequestCountDefault
        /// Default value as hex string
        /// </summary>
        public static string HrmpOpenChannelRequestCountDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> HrmpOpenChannelRequestCount
        ///  This mapping tracks how many open channel requests are initiated by a given sender para.
        ///  Invariant: `HrmpOpenChannelRequests` should contain the same number of items that has
        ///  `(X, _)` as the number of `HrmpOpenChannelRequestCount` for `X`.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> HrmpOpenChannelRequestCount(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = HrmpOpenChannelRequestCountParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> HrmpAcceptedChannelRequestCountParams
        ///  This mapping tracks how many open channel requests were accepted by a given recipient para.
        ///  Invariant: `HrmpOpenChannelRequests` should contain the same number of items `(_, X)` with
        ///  `confirmed` set to true, as the number of `HrmpAcceptedChannelRequestCount` for `X`.
        /// </summary>
        public static string HrmpAcceptedChannelRequestCountParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Hrmp", "HrmpAcceptedChannelRequestCount", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> HrmpAcceptedChannelRequestCountDefault
        /// Default value as hex string
        /// </summary>
        public static string HrmpAcceptedChannelRequestCountDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> HrmpAcceptedChannelRequestCount
        ///  This mapping tracks how many open channel requests were accepted by a given recipient para.
        ///  Invariant: `HrmpOpenChannelRequests` should contain the same number of items `(_, X)` with
        ///  `confirmed` set to true, as the number of `HrmpAcceptedChannelRequestCount` for `X`.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> HrmpAcceptedChannelRequestCount(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = HrmpAcceptedChannelRequestCountParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> HrmpCloseChannelRequestsParams
        ///  A set of pending HRMP close channel requests that are going to be closed during the session
        ///  change. Used for checking if a given channel is registered for closure.
        /// 
        ///  The set is accompanied by a list for iteration.
        /// 
        ///  Invariant:
        ///  - There are no channels that exists in list but not in the set and vice versa.
        /// </summary>
        public static string HrmpCloseChannelRequestsParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.HrmpChannelId key)
        {
            return RequestGenerator.GetStorage("Hrmp", "HrmpCloseChannelRequests", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> HrmpCloseChannelRequestsDefault
        /// Default value as hex string
        /// </summary>
        public static string HrmpCloseChannelRequestsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> HrmpCloseChannelRequests
        ///  A set of pending HRMP close channel requests that are going to be closed during the session
        ///  change. Used for checking if a given channel is registered for closure.
        /// 
        ///  The set is accompanied by a list for iteration.
        /// 
        ///  Invariant:
        ///  - There are no channels that exists in list but not in the set and vice versa.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple> HrmpCloseChannelRequests(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.HrmpChannelId key, CancellationToken token)
        {
            string parameters = HrmpCloseChannelRequestsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> HrmpCloseChannelRequestsListParams
        /// </summary>
        public static string HrmpCloseChannelRequestsListParams()
        {
            return RequestGenerator.GetStorage("Hrmp", "HrmpCloseChannelRequestsList", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> HrmpCloseChannelRequestsListDefault
        /// Default value as hex string
        /// </summary>
        public static string HrmpCloseChannelRequestsListDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> HrmpCloseChannelRequestsList
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.HrmpChannelId>> HrmpCloseChannelRequestsList(CancellationToken token)
        {
            string parameters = HrmpCloseChannelRequestsListParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.HrmpChannelId>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> HrmpWatermarksParams
        ///  The HRMP watermark associated with each para.
        ///  Invariant:
        ///  - each para `P` used here as a key should satisfy `Paras::is_valid_para(P)` within a session.
        /// </summary>
        public static string HrmpWatermarksParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Hrmp", "HrmpWatermarks", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> HrmpWatermarksDefault
        /// Default value as hex string
        /// </summary>
        public static string HrmpWatermarksDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> HrmpWatermarks
        ///  The HRMP watermark associated with each para.
        ///  Invariant:
        ///  - each para `P` used here as a key should satisfy `Paras::is_valid_para(P)` within a session.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> HrmpWatermarks(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = HrmpWatermarksParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> HrmpChannelsParams
        ///  HRMP channel data associated with each para.
        ///  Invariant:
        ///  - each participant in the channel should satisfy `Paras::is_valid_para(P)` within a session.
        /// </summary>
        public static string HrmpChannelsParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.HrmpChannelId key)
        {
            return RequestGenerator.GetStorage("Hrmp", "HrmpChannels", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> HrmpChannelsDefault
        /// Default value as hex string
        /// </summary>
        public static string HrmpChannelsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> HrmpChannels
        ///  HRMP channel data associated with each para.
        ///  Invariant:
        ///  - each participant in the channel should satisfy `Paras::is_valid_para(P)` within a session.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_runtime_parachains.hrmp.HrmpChannel> HrmpChannels(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.HrmpChannelId key, CancellationToken token)
        {
            string parameters = HrmpChannelsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_runtime_parachains.hrmp.HrmpChannel>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> HrmpIngressChannelsIndexParams
        ///  Ingress/egress indexes allow to find all the senders and receivers given the opposite side.
        ///  I.e.
        /// 
        ///  (a) ingress index allows to find all the senders for a given recipient.
        ///  (b) egress index allows to find all the recipients for a given sender.
        /// 
        ///  Invariants:
        ///  - for each ingress index entry for `P` each item `I` in the index should present in
        ///    `HrmpChannels` as `(I, P)`.
        ///  - for each egress index entry for `P` each item `E` in the index should present in
        ///    `HrmpChannels` as `(P, E)`.
        ///  - there should be no other dangling channels in `HrmpChannels`.
        ///  - the vectors are sorted.
        /// </summary>
        public static string HrmpIngressChannelsIndexParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Hrmp", "HrmpIngressChannelsIndex", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> HrmpIngressChannelsIndexDefault
        /// Default value as hex string
        /// </summary>
        public static string HrmpIngressChannelsIndexDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> HrmpIngressChannelsIndex
        ///  Ingress/egress indexes allow to find all the senders and receivers given the opposite side.
        ///  I.e.
        /// 
        ///  (a) ingress index allows to find all the senders for a given recipient.
        ///  (b) egress index allows to find all the recipients for a given sender.
        /// 
        ///  Invariants:
        ///  - for each ingress index entry for `P` each item `I` in the index should present in
        ///    `HrmpChannels` as `(I, P)`.
        ///  - for each egress index entry for `P` each item `E` in the index should present in
        ///    `HrmpChannels` as `(P, E)`.
        ///  - there should be no other dangling channels in `HrmpChannels`.
        ///  - the vectors are sorted.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id>> HrmpIngressChannelsIndex(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = HrmpIngressChannelsIndexParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> HrmpEgressChannelsIndexParams
        /// </summary>
        public static string HrmpEgressChannelsIndexParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Hrmp", "HrmpEgressChannelsIndex", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> HrmpEgressChannelsIndexDefault
        /// Default value as hex string
        /// </summary>
        public static string HrmpEgressChannelsIndexDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> HrmpEgressChannelsIndex
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id>> HrmpEgressChannelsIndex(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = HrmpEgressChannelsIndexParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> HrmpChannelContentsParams
        ///  Storage for the messages for each channel.
        ///  Invariant: cannot be non-empty if the corresponding channel in `HrmpChannels` is `None`.
        /// </summary>
        public static string HrmpChannelContentsParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.HrmpChannelId key)
        {
            return RequestGenerator.GetStorage("Hrmp", "HrmpChannelContents", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> HrmpChannelContentsDefault
        /// Default value as hex string
        /// </summary>
        public static string HrmpChannelContentsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> HrmpChannelContents
        ///  Storage for the messages for each channel.
        ///  Invariant: cannot be non-empty if the corresponding channel in `HrmpChannels` is `None`.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_core_primitives.InboundHrmpMessage>> HrmpChannelContents(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.HrmpChannelId key, CancellationToken token)
        {
            string parameters = HrmpChannelContentsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_core_primitives.InboundHrmpMessage>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> HrmpChannelDigestsParams
        ///  Maintains a mapping that can be used to answer the question: What paras sent a message at
        ///  the given block number for a given receiver. Invariants:
        ///  - The inner `Vec<ParaId>` is never empty.
        ///  - The inner `Vec<ParaId>` cannot store two same `ParaId`.
        ///  - The outer vector is sorted ascending by block number and cannot store two items with the
        ///    same block number.
        /// </summary>
        public static string HrmpChannelDigestsParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Hrmp", "HrmpChannelDigests", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> HrmpChannelDigestsDefault
        /// Default value as hex string
        /// </summary>
        public static string HrmpChannelDigestsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> HrmpChannelDigests
        ///  Maintains a mapping that can be used to answer the question: What paras sent a message at
        ///  the given block number for a given receiver. Invariants:
        ///  - The inner `Vec<ParaId>` is never empty.
        ///  - The inner `Vec<ParaId>` cannot store two same `ParaId`.
        ///  - The outer vector is sorted ascending by block number and cannot store two items with the
        ///    same block number.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id>>>> HrmpChannelDigests(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = HrmpChannelDigestsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_parachain.primitives.Id>>>>(parameters, blockHash, token);
            return result;
        }

        public HrmpStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class HrmpConstants
    {
    }

    public enum HrmpErrors
    {
        /// <summary>
        /// >> OpenHrmpChannelToSelf
        /// The sender tried to open a channel to themselves.
        /// </summary>
        OpenHrmpChannelToSelf,
        /// <summary>
        /// >> OpenHrmpChannelInvalidRecipient
        /// The recipient is not a valid para.
        /// </summary>
        OpenHrmpChannelInvalidRecipient,
        /// <summary>
        /// >> OpenHrmpChannelZeroCapacity
        /// The requested capacity is zero.
        /// </summary>
        OpenHrmpChannelZeroCapacity,
        /// <summary>
        /// >> OpenHrmpChannelCapacityExceedsLimit
        /// The requested capacity exceeds the global limit.
        /// </summary>
        OpenHrmpChannelCapacityExceedsLimit,
        /// <summary>
        /// >> OpenHrmpChannelZeroMessageSize
        /// The requested maximum message size is 0.
        /// </summary>
        OpenHrmpChannelZeroMessageSize,
        /// <summary>
        /// >> OpenHrmpChannelMessageSizeExceedsLimit
        /// The open request requested the message size that exceeds the global limit.
        /// </summary>
        OpenHrmpChannelMessageSizeExceedsLimit,
        /// <summary>
        /// >> OpenHrmpChannelAlreadyExists
        /// The channel already exists
        /// </summary>
        OpenHrmpChannelAlreadyExists,
        /// <summary>
        /// >> OpenHrmpChannelAlreadyRequested
        /// There is already a request to open the same channel.
        /// </summary>
        OpenHrmpChannelAlreadyRequested,
        /// <summary>
        /// >> OpenHrmpChannelLimitExceeded
        /// The sender already has the maximum number of allowed outbound channels.
        /// </summary>
        OpenHrmpChannelLimitExceeded,
        /// <summary>
        /// >> AcceptHrmpChannelDoesntExist
        /// The channel from the sender to the origin doesn't exist.
        /// </summary>
        AcceptHrmpChannelDoesntExist,
        /// <summary>
        /// >> AcceptHrmpChannelAlreadyConfirmed
        /// The channel is already confirmed.
        /// </summary>
        AcceptHrmpChannelAlreadyConfirmed,
        /// <summary>
        /// >> AcceptHrmpChannelLimitExceeded
        /// The recipient already has the maximum number of allowed inbound channels.
        /// </summary>
        AcceptHrmpChannelLimitExceeded,
        /// <summary>
        /// >> CloseHrmpChannelUnauthorized
        /// The origin tries to close a channel where it is neither the sender nor the recipient.
        /// </summary>
        CloseHrmpChannelUnauthorized,
        /// <summary>
        /// >> CloseHrmpChannelDoesntExist
        /// The channel to be closed doesn't exist.
        /// </summary>
        CloseHrmpChannelDoesntExist,
        /// <summary>
        /// >> CloseHrmpChannelAlreadyUnderway
        /// The channel close request is already requested.
        /// </summary>
        CloseHrmpChannelAlreadyUnderway,
        /// <summary>
        /// >> CancelHrmpOpenChannelUnauthorized
        /// Canceling is requested by neither the sender nor recipient of the open channel request.
        /// </summary>
        CancelHrmpOpenChannelUnauthorized,
        /// <summary>
        /// >> OpenHrmpChannelDoesntExist
        /// The open request doesn't exist.
        /// </summary>
        OpenHrmpChannelDoesntExist,
        /// <summary>
        /// >> OpenHrmpChannelAlreadyConfirmed
        /// Cannot cancel an HRMP open channel request because it is already confirmed.
        /// </summary>
        OpenHrmpChannelAlreadyConfirmed,
        /// <summary>
        /// >> WrongWitness
        /// The provided witness data is wrong.
        /// </summary>
        WrongWitness
    }
}