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
    
    
    public sealed class AwesomeAvatarsStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public AwesomeAvatarsStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AwesomeAvatars", "Organizer"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AwesomeAvatars", "CurrentSeasonId"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U16)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AwesomeAvatars", "IsSeasonActive"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.Bool)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AwesomeAvatars", "Seasons"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Ajuna.NetApi.Model.Types.Primitive.U16), typeof(Substats.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.Season)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AwesomeAvatars", "GlobalConfigs"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.GlobalConfig)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AwesomeAvatars", "Avatars"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Substats.Bajun.NetApiExt.Generated.Model.primitive_types.H256), typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.Avatar>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AwesomeAvatars", "Owners"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT6)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AwesomeAvatars", "LastMintedBlockNumbers"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AwesomeAvatars", "FreeMints"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Ajuna.NetApi.Model.Types.Primitive.U16)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AwesomeAvatars", "Trade"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Substats.Bajun.NetApiExt.Generated.Model.primitive_types.H256), typeof(Ajuna.NetApi.Model.Types.Primitive.U128)));
        }
        
        /// <summary>
        /// >> OrganizerParams
        /// </summary>
        public static string OrganizerParams()
        {
            return RequestGenerator.GetStorage("AwesomeAvatars", "Organizer", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> Organizer
        /// </summary>
        public async Task<Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> Organizer(CancellationToken token)
        {
            string parameters = AwesomeAvatarsStorage.OrganizerParams();
            return await _client.GetStorageAsync<Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>(parameters, token);
        }
        
        /// <summary>
        /// >> CurrentSeasonIdParams
        /// </summary>
        public static string CurrentSeasonIdParams()
        {
            return RequestGenerator.GetStorage("AwesomeAvatars", "CurrentSeasonId", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> CurrentSeasonId
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U16> CurrentSeasonId(CancellationToken token)
        {
            string parameters = AwesomeAvatarsStorage.CurrentSeasonIdParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U16>(parameters, token);
        }
        
        /// <summary>
        /// >> IsSeasonActiveParams
        /// </summary>
        public static string IsSeasonActiveParams()
        {
            return RequestGenerator.GetStorage("AwesomeAvatars", "IsSeasonActive", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> IsSeasonActive
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.Bool> IsSeasonActive(CancellationToken token)
        {
            string parameters = AwesomeAvatarsStorage.IsSeasonActiveParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.Bool>(parameters, token);
        }
        
        /// <summary>
        /// >> SeasonsParams
        ///  Storage for the seasons.
        /// </summary>
        public static string SeasonsParams(Ajuna.NetApi.Model.Types.Primitive.U16 key)
        {
            return RequestGenerator.GetStorage("AwesomeAvatars", "Seasons", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Seasons
        ///  Storage for the seasons.
        /// </summary>
        public async Task<Substats.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.Season> Seasons(Ajuna.NetApi.Model.Types.Primitive.U16 key, CancellationToken token)
        {
            string parameters = AwesomeAvatarsStorage.SeasonsParams(key);
            return await _client.GetStorageAsync<Substats.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.Season>(parameters, token);
        }
        
        /// <summary>
        /// >> GlobalConfigsParams
        /// </summary>
        public static string GlobalConfigsParams()
        {
            return RequestGenerator.GetStorage("AwesomeAvatars", "GlobalConfigs", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> GlobalConfigs
        /// </summary>
        public async Task<Substats.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.GlobalConfig> GlobalConfigs(CancellationToken token)
        {
            string parameters = AwesomeAvatarsStorage.GlobalConfigsParams();
            return await _client.GetStorageAsync<Substats.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.GlobalConfig>(parameters, token);
        }
        
        /// <summary>
        /// >> AvatarsParams
        /// </summary>
        public static string AvatarsParams(Substats.Bajun.NetApiExt.Generated.Model.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("AwesomeAvatars", "Avatars", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Avatars
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.Avatar>> Avatars(Substats.Bajun.NetApiExt.Generated.Model.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = AwesomeAvatarsStorage.AvatarsParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.Avatar>>(parameters, token);
        }
        
        /// <summary>
        /// >> OwnersParams
        /// </summary>
        public static string OwnersParams(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("AwesomeAvatars", "Owners", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Owners
        /// </summary>
        public async Task<Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT6> Owners(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = AwesomeAvatarsStorage.OwnersParams(key);
            return await _client.GetStorageAsync<Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT6>(parameters, token);
        }
        
        /// <summary>
        /// >> LastMintedBlockNumbersParams
        /// </summary>
        public static string LastMintedBlockNumbersParams(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("AwesomeAvatars", "LastMintedBlockNumbers", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> LastMintedBlockNumbers
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> LastMintedBlockNumbers(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = AwesomeAvatarsStorage.LastMintedBlockNumbersParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
        }
        
        /// <summary>
        /// >> FreeMintsParams
        /// </summary>
        public static string FreeMintsParams(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("AwesomeAvatars", "FreeMints", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> FreeMints
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U16> FreeMints(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = AwesomeAvatarsStorage.FreeMintsParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U16>(parameters, token);
        }
        
        /// <summary>
        /// >> TradeParams
        /// </summary>
        public static string TradeParams(Substats.Bajun.NetApiExt.Generated.Model.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("AwesomeAvatars", "Trade", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Trade
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U128> Trade(Substats.Bajun.NetApiExt.Generated.Model.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = AwesomeAvatarsStorage.TradeParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U128>(parameters, token);
        }
    }
    
    public sealed class AwesomeAvatarsCalls
    {
        
        /// <summary>
        /// >> mint
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Mint(Substats.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.MintOption mint_option)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(mint_option.Encode());
            return new Method(50, "AwesomeAvatars", 0, "mint", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> forge
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Forge(Substats.Bajun.NetApiExt.Generated.Model.primitive_types.H256 leader, Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT6 sacrifices)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(leader.Encode());
            byteArray.AddRange(sacrifices.Encode());
            return new Method(50, "AwesomeAvatars", 1, "forge", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> transfer_free_mints
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method TransferFreeMints(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 dest, Ajuna.NetApi.Model.Types.Primitive.U16 how_many)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(how_many.Encode());
            return new Method(50, "AwesomeAvatars", 2, "transfer_free_mints", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_price
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetPrice(Substats.Bajun.NetApiExt.Generated.Model.primitive_types.H256 avatar_id, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128> price)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(avatar_id.Encode());
            byteArray.AddRange(price.Encode());
            return new Method(50, "AwesomeAvatars", 3, "set_price", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_price
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method RemovePrice(Substats.Bajun.NetApiExt.Generated.Model.primitive_types.H256 avatar_id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(avatar_id.Encode());
            return new Method(50, "AwesomeAvatars", 4, "remove_price", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> buy
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Buy(Substats.Bajun.NetApiExt.Generated.Model.primitive_types.H256 avatar_id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(avatar_id.Encode());
            return new Method(50, "AwesomeAvatars", 5, "buy", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_organizer
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetOrganizer(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 organizer)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(organizer.Encode());
            return new Method(50, "AwesomeAvatars", 6, "set_organizer", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> upsert_season
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method UpsertSeason(Ajuna.NetApi.Model.Types.Primitive.U16 season_id, Substats.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.Season season)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(season_id.Encode());
            byteArray.AddRange(season.Encode());
            return new Method(50, "AwesomeAvatars", 7, "upsert_season", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> update_global_config
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method UpdateGlobalConfig(Substats.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.GlobalConfig new_global_config)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(new_global_config.Encode());
            return new Method(50, "AwesomeAvatars", 8, "update_global_config", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> issue_free_mints
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method IssueFreeMints(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 dest, Ajuna.NetApi.Model.Types.Primitive.U16 how_many)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(how_many.Encode());
            return new Method(50, "AwesomeAvatars", 9, "issue_free_mints", byteArray.ToArray());
        }
    }
    
    public enum AwesomeAvatarsErrors
    {
        
        /// <summary>
        /// >> OrganizerNotSet
        /// There is no account set as the organizer
        /// </summary>
        OrganizerNotSet,
        
        /// <summary>
        /// >> EarlyStartTooEarly
        /// The season starts before the previous season has ended.
        /// </summary>
        EarlyStartTooEarly,
        
        /// <summary>
        /// >> EarlyStartTooLate
        /// The season season start later than its early access
        /// </summary>
        EarlyStartTooLate,
        
        /// <summary>
        /// >> SeasonStartTooLate
        /// The season start date is newer than its end date.
        /// </summary>
        SeasonStartTooLate,
        
        /// <summary>
        /// >> SeasonEndTooLate
        /// The season ends after the new season has started.
        /// </summary>
        SeasonEndTooLate,
        
        /// <summary>
        /// >> UnknownSeason
        /// The season doesn't exist.
        /// </summary>
        UnknownSeason,
        
        /// <summary>
        /// >> UnknownAvatar
        /// The avatar doesn't exist.
        /// </summary>
        UnknownAvatar,
        
        /// <summary>
        /// >> UnknownAvatarForSale
        /// The avatar for sale doesn't exist.
        /// </summary>
        UnknownAvatarForSale,
        
        /// <summary>
        /// >> UnknownTier
        /// The tier doesn't exist.
        /// </summary>
        UnknownTier,
        
        /// <summary>
        /// >> NonSequentialSeasonId
        /// The season ID of a season to create is not sequential.
        /// </summary>
        NonSequentialSeasonId,
        
        /// <summary>
        /// >> IncorrectRarityPercentages
        /// Rarity percentages don't add up to 100
        /// </summary>
        IncorrectRarityPercentages,
        
        /// <summary>
        /// >> TooManyRarityPercentages
        /// Max tier is achievable through forging only. Therefore the number of rarity percentages
        /// must be less than that of tiers for a season.
        /// </summary>
        TooManyRarityPercentages,
        
        /// <summary>
        /// >> DuplicatedRarityTier
        /// Some rarity tier are duplicated.
        /// </summary>
        DuplicatedRarityTier,
        
        /// <summary>
        /// >> MintClosed
        /// Minting is not available at the moment.
        /// </summary>
        MintClosed,
        
        /// <summary>
        /// >> ForgeClosed
        /// Forging is not available at the moment.
        /// </summary>
        ForgeClosed,
        
        /// <summary>
        /// >> TradeClosed
        /// Trading is not available at the moment.
        /// </summary>
        TradeClosed,
        
        /// <summary>
        /// >> OutOfSeason
        /// No season active currently.
        /// </summary>
        OutOfSeason,
        
        /// <summary>
        /// >> MaxOwnershipReached
        /// Max ownership reached.
        /// </summary>
        MaxOwnershipReached,
        
        /// <summary>
        /// >> Ownership
        /// Avatar belongs to someone else.
        /// </summary>
        Ownership,
        
        /// <summary>
        /// >> IncorrectDna
        /// Incorrect DNA.
        /// </summary>
        IncorrectDna,
        
        /// <summary>
        /// >> IncorrectAvatarId
        /// Incorrect Avatar ID.
        /// </summary>
        IncorrectAvatarId,
        
        /// <summary>
        /// >> MintCooldown
        /// The player must wait cooldown period.
        /// </summary>
        MintCooldown,
        
        /// <summary>
        /// >> InsufficientFunds
        /// The player has not enough funds.
        /// </summary>
        InsufficientFunds,
        
        /// <summary>
        /// >> MaxComponentsTooLow
        /// The season's max components value is less than the minimum allowed (1).
        /// </summary>
        MaxComponentsTooLow,
        
        /// <summary>
        /// >> MaxComponentsTooHigh
        /// The season's max components value is more than the maximum allowed (random byte: 32).
        /// </summary>
        MaxComponentsTooHigh,
        
        /// <summary>
        /// >> MaxVariationsTooLow
        /// The season's max variations value is less than the minimum allowed (1).
        /// </summary>
        MaxVariationsTooLow,
        
        /// <summary>
        /// >> MaxVariationsTooHigh
        /// The season's max variations value is more than the maximum allowed (15).
        /// </summary>
        MaxVariationsTooHigh,
        
        /// <summary>
        /// >> InsufficientFreeMints
        /// The player has not enough free mints available.
        /// </summary>
        InsufficientFreeMints,
        
        /// <summary>
        /// >> TooFewSacrifices
        /// Less than minimum allowed sacrifices are used for forging.
        /// </summary>
        TooFewSacrifices,
        
        /// <summary>
        /// >> TooManySacrifices
        /// More than maximum allowed sacrifices are used for forging.
        /// </summary>
        TooManySacrifices,
        
        /// <summary>
        /// >> LeaderSacrificed
        /// Leader is being sacrificed.
        /// </summary>
        LeaderSacrificed,
        
        /// <summary>
        /// >> AvatarInTrade
        /// An avatar listed for trade is used to forge.
        /// </summary>
        AvatarInTrade,
    }
}
