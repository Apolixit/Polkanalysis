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


namespace Substats.Polkadot.NetApiExt.Generated.Storage
{
    
    
    public sealed class XcmPalletStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public XcmPalletStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmPallet", "QueryCounter"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U64)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmPallet", "Queries"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Ajuna.NetApi.Model.Types.Primitive.U64), typeof(Substats.Polkadot.NetApiExt.Generated.Model.pallet_xcm.pallet.EnumQueryStatus)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmPallet", "AssetTraps"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256), typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmPallet", "SafeXcmVersion"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmPallet", "SupportedVersion"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation>), typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmPallet", "VersionNotifiers"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation>), typeof(Ajuna.NetApi.Model.Types.Primitive.U64)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmPallet", "VersionNotifyTargets"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation>), typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.U32>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmPallet", "VersionDiscoveryQueue"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT22)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmPallet", "CurrentMigration"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Polkadot.NetApiExt.Generated.Model.pallet_xcm.pallet.EnumVersionMigrationStage)));
        }
        
        /// <summary>
        /// >> QueryCounterParams
        ///  The latest available query index.
        /// </summary>
        public static string QueryCounterParams()
        {
            return RequestGenerator.GetStorage("XcmPallet", "QueryCounter", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> QueryCounter
        ///  The latest available query index.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U64> QueryCounter(CancellationToken token)
        {
            string parameters = XcmPalletStorage.QueryCounterParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U64>(parameters, token);
        }
        
        /// <summary>
        /// >> QueriesParams
        ///  The ongoing queries.
        /// </summary>
        public static string QueriesParams(Ajuna.NetApi.Model.Types.Primitive.U64 key)
        {
            return RequestGenerator.GetStorage("XcmPallet", "Queries", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Queries
        ///  The ongoing queries.
        /// </summary>
        public async Task<Substats.Polkadot.NetApiExt.Generated.Model.pallet_xcm.pallet.EnumQueryStatus> Queries(Ajuna.NetApi.Model.Types.Primitive.U64 key, CancellationToken token)
        {
            string parameters = XcmPalletStorage.QueriesParams(key);
            return await _client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.pallet_xcm.pallet.EnumQueryStatus>(parameters, token);
        }
        
        /// <summary>
        /// >> AssetTrapsParams
        ///  The existing asset traps.
        /// 
        ///  Key is the blake2 256 hash of (origin, versioned `MultiAssets`) pair. Value is the number of
        ///  times this pair has been trapped (usually just 1 if it exists at all).
        /// </summary>
        public static string AssetTrapsParams(Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("XcmPallet", "AssetTraps", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> AssetTraps
        ///  The existing asset traps.
        /// 
        ///  Key is the blake2 256 hash of (origin, versioned `MultiAssets`) pair. Value is the number of
        ///  times this pair has been trapped (usually just 1 if it exists at all).
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> AssetTraps(Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = XcmPalletStorage.AssetTrapsParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
        }
        
        /// <summary>
        /// >> SafeXcmVersionParams
        ///  Default version to encode XCM when latest version of destination is unknown. If `None`,
        ///  then the destinations whose XCM version is unknown are considered unreachable.
        /// </summary>
        public static string SafeXcmVersionParams()
        {
            return RequestGenerator.GetStorage("XcmPallet", "SafeXcmVersion", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> SafeXcmVersion
        ///  Default version to encode XCM when latest version of destination is unknown. If `None`,
        ///  then the destinations whose XCM version is unknown are considered unreachable.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> SafeXcmVersion(CancellationToken token)
        {
            string parameters = XcmPalletStorage.SafeXcmVersionParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
        }
        
        /// <summary>
        /// >> SupportedVersionParams
        ///  The Latest versions that we know various locations support.
        /// </summary>
        public static string SupportedVersionParams(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation> key)
        {
            return RequestGenerator.GetStorage("XcmPallet", "SupportedVersion", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, key.Value);
        }
        
        /// <summary>
        /// >> SupportedVersion
        ///  The Latest versions that we know various locations support.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> SupportedVersion(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation> key, CancellationToken token)
        {
            string parameters = XcmPalletStorage.SupportedVersionParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
        }
        
        /// <summary>
        /// >> VersionNotifiersParams
        ///  All locations that we have requested version notifications from.
        /// </summary>
        public static string VersionNotifiersParams(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation> key)
        {
            return RequestGenerator.GetStorage("XcmPallet", "VersionNotifiers", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, key.Value);
        }
        
        /// <summary>
        /// >> VersionNotifiers
        ///  All locations that we have requested version notifications from.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U64> VersionNotifiers(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation> key, CancellationToken token)
        {
            string parameters = XcmPalletStorage.VersionNotifiersParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U64>(parameters, token);
        }
        
        /// <summary>
        /// >> VersionNotifyTargetsParams
        ///  The target locations that are subscribed to our version changes, as well as the most recent
        ///  of our versions we informed them of.
        /// </summary>
        public static string VersionNotifyTargetsParams(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation> key)
        {
            return RequestGenerator.GetStorage("XcmPallet", "VersionNotifyTargets", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, key.Value);
        }
        
        /// <summary>
        /// >> VersionNotifyTargets
        ///  The target locations that are subscribed to our version changes, as well as the most recent
        ///  of our versions we informed them of.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.U32>> VersionNotifyTargets(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation> key, CancellationToken token)
        {
            string parameters = XcmPalletStorage.VersionNotifyTargetsParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.U32>>(parameters, token);
        }
        
        /// <summary>
        /// >> VersionDiscoveryQueueParams
        ///  Destinations whose latest XCM version we would like to know. Duplicates not allowed, and
        ///  the `u32` counter is the number of times that a send to the destination has been attempted,
        ///  which is used as a prioritization.
        /// </summary>
        public static string VersionDiscoveryQueueParams()
        {
            return RequestGenerator.GetStorage("XcmPallet", "VersionDiscoveryQueue", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> VersionDiscoveryQueue
        ///  Destinations whose latest XCM version we would like to know. Duplicates not allowed, and
        ///  the `u32` counter is the number of times that a send to the destination has been attempted,
        ///  which is used as a prioritization.
        /// </summary>
        public async Task<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT22> VersionDiscoveryQueue(CancellationToken token)
        {
            string parameters = XcmPalletStorage.VersionDiscoveryQueueParams();
            return await _client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT22>(parameters, token);
        }
        
        /// <summary>
        /// >> CurrentMigrationParams
        ///  The current migration's stage, if any.
        /// </summary>
        public static string CurrentMigrationParams()
        {
            return RequestGenerator.GetStorage("XcmPallet", "CurrentMigration", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> CurrentMigration
        ///  The current migration's stage, if any.
        /// </summary>
        public async Task<Substats.Polkadot.NetApiExt.Generated.Model.pallet_xcm.pallet.EnumVersionMigrationStage> CurrentMigration(CancellationToken token)
        {
            string parameters = XcmPalletStorage.CurrentMigrationParams();
            return await _client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.pallet_xcm.pallet.EnumVersionMigrationStage>(parameters, token);
        }
    }
    
    public sealed class XcmPalletCalls
    {
        
        /// <summary>
        /// >> send
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Send(Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation dest, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedXcm message)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(message.Encode());
            return new Method(99, "XcmPallet", 0, "send", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> teleport_assets
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method TeleportAssets(Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation dest, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation beneficiary, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiAssets assets, Ajuna.NetApi.Model.Types.Primitive.U32 fee_asset_item)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(beneficiary.Encode());
            byteArray.AddRange(assets.Encode());
            byteArray.AddRange(fee_asset_item.Encode());
            return new Method(99, "XcmPallet", 1, "teleport_assets", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> reserve_transfer_assets
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ReserveTransferAssets(Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation dest, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation beneficiary, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiAssets assets, Ajuna.NetApi.Model.Types.Primitive.U32 fee_asset_item)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(beneficiary.Encode());
            byteArray.AddRange(assets.Encode());
            byteArray.AddRange(fee_asset_item.Encode());
            return new Method(99, "XcmPallet", 2, "reserve_transfer_assets", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> execute
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Execute(Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedXcm message, Substats.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight max_weight)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(message.Encode());
            byteArray.AddRange(max_weight.Encode());
            return new Method(99, "XcmPallet", 3, "execute", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_xcm_version
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ForceXcmVersion(Substats.Polkadot.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation location, Ajuna.NetApi.Model.Types.Primitive.U32 xcm_version)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(location.Encode());
            byteArray.AddRange(xcm_version.Encode());
            return new Method(99, "XcmPallet", 4, "force_xcm_version", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_default_xcm_version
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ForceDefaultXcmVersion(Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U32> maybe_xcm_version)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(maybe_xcm_version.Encode());
            return new Method(99, "XcmPallet", 5, "force_default_xcm_version", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_subscribe_version_notify
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ForceSubscribeVersionNotify(Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation location)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(location.Encode());
            return new Method(99, "XcmPallet", 6, "force_subscribe_version_notify", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_unsubscribe_version_notify
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ForceUnsubscribeVersionNotify(Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation location)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(location.Encode());
            return new Method(99, "XcmPallet", 7, "force_unsubscribe_version_notify", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> limited_reserve_transfer_assets
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method LimitedReserveTransferAssets(Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation dest, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation beneficiary, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiAssets assets, Ajuna.NetApi.Model.Types.Primitive.U32 fee_asset_item, Substats.Polkadot.NetApiExt.Generated.Model.xcm.v2.EnumWeightLimit weight_limit)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(beneficiary.Encode());
            byteArray.AddRange(assets.Encode());
            byteArray.AddRange(fee_asset_item.Encode());
            byteArray.AddRange(weight_limit.Encode());
            return new Method(99, "XcmPallet", 8, "limited_reserve_transfer_assets", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> limited_teleport_assets
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method LimitedTeleportAssets(Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation dest, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiLocation beneficiary, Substats.Polkadot.NetApiExt.Generated.Model.xcm.EnumVersionedMultiAssets assets, Ajuna.NetApi.Model.Types.Primitive.U32 fee_asset_item, Substats.Polkadot.NetApiExt.Generated.Model.xcm.v2.EnumWeightLimit weight_limit)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(beneficiary.Encode());
            byteArray.AddRange(assets.Encode());
            byteArray.AddRange(fee_asset_item.Encode());
            byteArray.AddRange(weight_limit.Encode());
            return new Method(99, "XcmPallet", 9, "limited_teleport_assets", byteArray.ToArray());
        }
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
        AlreadySubscribed,
    }
}
