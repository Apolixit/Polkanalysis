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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9291
{
    public sealed class XcmPalletStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> QueryCounterParams
        ///  The latest available query index.
        /// </summary>
        public static string QueryCounterParams()
        {
            return RequestGenerator.GetStorage("XcmPallet", "QueryCounter", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> QueryCounterDefault
        /// Default value as hex string
        /// </summary>
        public static string QueryCounterDefault()
        {
            return "0x0000000000000000";
        }

        /// <summary>
        /// >> QueryCounter
        ///  The latest available query index.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U64> QueryCounter(CancellationToken token)
        {
            string parameters = QueryCounterParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U64>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> QueriesParams
        ///  The ongoing queries.
        /// </summary>
        public static string QueriesParams(Substrate.NetApi.Model.Types.Primitive.U64 key)
        {
            return RequestGenerator.GetStorage("XcmPallet", "Queries", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> QueriesDefault
        /// Default value as hex string
        /// </summary>
        public static string QueriesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Queries
        ///  The ongoing queries.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.pallet_xcm.pallet.EnumQueryStatus> Queries(Substrate.NetApi.Model.Types.Primitive.U64 key, CancellationToken token)
        {
            string parameters = QueriesParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.pallet_xcm.pallet.EnumQueryStatus>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> AssetTrapsParams
        ///  The existing asset traps.
        /// 
        ///  Key is the blake2 256 hash of (origin, versioned `MultiAssets`) pair. Value is the number of
        ///  times this pair has been trapped (usually just 1 if it exists at all).
        /// </summary>
        public static string AssetTrapsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("XcmPallet", "AssetTraps", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> AssetTrapsDefault
        /// Default value as hex string
        /// </summary>
        public static string AssetTrapsDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> AssetTraps
        ///  The existing asset traps.
        /// 
        ///  Key is the blake2 256 hash of (origin, versioned `MultiAssets`) pair. Value is the number of
        ///  times this pair has been trapped (usually just 1 if it exists at all).
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> AssetTraps(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = AssetTrapsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SafeXcmVersionParams
        ///  Default version to encode XCM when latest version of destination is unknown. If `None`,
        ///  then the destinations whose XCM version is unknown are considered unreachable.
        /// </summary>
        public static string SafeXcmVersionParams()
        {
            return RequestGenerator.GetStorage("XcmPallet", "SafeXcmVersion", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> SafeXcmVersionDefault
        /// Default value as hex string
        /// </summary>
        public static string SafeXcmVersionDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> SafeXcmVersion
        ///  Default version to encode XCM when latest version of destination is unknown. If `None`,
        ///  then the destinations whose XCM version is unknown are considered unreachable.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> SafeXcmVersion(CancellationToken token)
        {
            string parameters = SafeXcmVersionParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SupportedVersionParams
        ///  The Latest versions that we know various locations support.
        /// </summary>
        public static string SupportedVersionParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.xcm.EnumVersionedMultiLocation> key)
        {
            return RequestGenerator.GetStorage("XcmPallet", "SupportedVersion", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat, Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, key.Value);
        }

        /// <summary>
        /// >> SupportedVersionDefault
        /// Default value as hex string
        /// </summary>
        public static string SupportedVersionDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> SupportedVersion
        ///  The Latest versions that we know various locations support.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> SupportedVersion(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.xcm.EnumVersionedMultiLocation> key, CancellationToken token)
        {
            string parameters = SupportedVersionParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> VersionNotifiersParams
        ///  All locations that we have requested version notifications from.
        /// </summary>
        public static string VersionNotifiersParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.xcm.EnumVersionedMultiLocation> key)
        {
            return RequestGenerator.GetStorage("XcmPallet", "VersionNotifiers", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat, Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, key.Value);
        }

        /// <summary>
        /// >> VersionNotifiersDefault
        /// Default value as hex string
        /// </summary>
        public static string VersionNotifiersDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> VersionNotifiers
        ///  All locations that we have requested version notifications from.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U64> VersionNotifiers(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.xcm.EnumVersionedMultiLocation> key, CancellationToken token)
        {
            string parameters = VersionNotifiersParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U64>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> VersionNotifyTargetsParams
        ///  The target locations that are subscribed to our version changes, as well as the most recent
        ///  of our versions we informed them of.
        /// </summary>
        public static string VersionNotifyTargetsParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.xcm.EnumVersionedMultiLocation> key)
        {
            return RequestGenerator.GetStorage("XcmPallet", "VersionNotifyTargets", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat, Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, key.Value);
        }

        /// <summary>
        /// >> VersionNotifyTargetsDefault
        /// Default value as hex string
        /// </summary>
        public static string VersionNotifyTargetsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> VersionNotifyTargets
        ///  The target locations that are subscribed to our version changes, as well as the most recent
        ///  of our versions we informed them of.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U32>> VersionNotifyTargets(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.xcm.EnumVersionedMultiLocation> key, CancellationToken token)
        {
            string parameters = VersionNotifyTargetsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> VersionDiscoveryQueueParams
        ///  Destinations whose latest XCM version we would like to know. Duplicates not allowed, and
        ///  the `u32` counter is the number of times that a send to the destination has been attempted,
        ///  which is used as a prioritization.
        /// </summary>
        public static string VersionDiscoveryQueueParams()
        {
            return RequestGenerator.GetStorage("XcmPallet", "VersionDiscoveryQueue", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> VersionDiscoveryQueueDefault
        /// Default value as hex string
        /// </summary>
        public static string VersionDiscoveryQueueDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> VersionDiscoveryQueue
        ///  Destinations whose latest XCM version we would like to know. Duplicates not allowed, and
        ///  the `u32` counter is the number of times that a send to the destination has been attempted,
        ///  which is used as a prioritization.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.xcm.EnumVersionedMultiLocation, Substrate.NetApi.Model.Types.Primitive.U32>>> VersionDiscoveryQueue(CancellationToken token)
        {
            string parameters = VersionDiscoveryQueueParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.xcm.EnumVersionedMultiLocation, Substrate.NetApi.Model.Types.Primitive.U32>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CurrentMigrationParams
        ///  The current migration's stage, if any.
        /// </summary>
        public static string CurrentMigrationParams()
        {
            return RequestGenerator.GetStorage("XcmPallet", "CurrentMigration", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CurrentMigrationDefault
        /// Default value as hex string
        /// </summary>
        public static string CurrentMigrationDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> CurrentMigration
        ///  The current migration's stage, if any.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.pallet_xcm.pallet.EnumVersionMigrationStage> CurrentMigration(CancellationToken token)
        {
            string parameters = CurrentMigrationParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.pallet_xcm.pallet.EnumVersionMigrationStage>(parameters, blockHash, token);
            return result;
        }

        public XcmPalletStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class XcmPalletConstants
    {
    }

    public enum XcmPalletErrors
    {
        /// <summary>
        /// >> Unreachable
        /// The desired destination was unreachable, generally because there is a no way of routing
        /// to it.
        /// </summary>
        Unreachable,
        /// <summary>
        /// >> SendFailure
        /// There was some other issue (i.e. not to do with routing) in sending the message. Perhaps
        /// a lack of space for buffering the message.
        /// </summary>
        SendFailure,
        /// <summary>
        /// >> Filtered
        /// The message execution fails the filter.
        /// </summary>
        Filtered,
        /// <summary>
        /// >> UnweighableMessage
        /// The message's weight could not be determined.
        /// </summary>
        UnweighableMessage,
        /// <summary>
        /// >> DestinationNotInvertible
        /// The destination `MultiLocation` provided cannot be inverted.
        /// </summary>
        DestinationNotInvertible,
        /// <summary>
        /// >> Empty
        /// The assets to be sent are empty.
        /// </summary>
        Empty,
        /// <summary>
        /// >> CannotReanchor
        /// Could not re-anchor the assets to declare the fees for the destination chain.
        /// </summary>
        CannotReanchor,
        /// <summary>
        /// >> TooManyAssets
        /// Too many assets have been attempted for transfer.
        /// </summary>
        TooManyAssets,
        /// <summary>
        /// >> InvalidOrigin
        /// Origin is invalid for sending.
        /// </summary>
        InvalidOrigin,
        /// <summary>
        /// >> BadVersion
        /// The version of the `Versioned` value used is not able to be interpreted.
        /// </summary>
        BadVersion,
        /// <summary>
        /// >> BadLocation
        /// The given location could not be used (e.g. because it cannot be expressed in the
        /// desired version of XCM).
        /// </summary>
        BadLocation,
        /// <summary>
        /// >> NoSubscription
        /// The referenced subscription could not be found.
        /// </summary>
        NoSubscription,
        /// <summary>
        /// >> AlreadySubscribed
        /// The location is invalid since it already has a subscription from us.
        /// </summary>
        AlreadySubscribed
    }
}