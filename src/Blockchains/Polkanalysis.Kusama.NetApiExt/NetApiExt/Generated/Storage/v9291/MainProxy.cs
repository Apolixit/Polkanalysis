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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9291
{
    public sealed class ProxyStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> ProxiesParams
        ///  The set of account proxies. Maps the account which has delegated to the accounts
        ///  which are being delegated to, together with the amount held on deposit.
        /// </summary>
        public static string ProxiesParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Proxy", "Proxies", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ProxiesDefault
        /// Default value as hex string
        /// </summary>
        public static string ProxiesDefault()
        {
            return "0x0000000000000000000000000000000000";
        }

        /// <summary>
        /// >> Proxies
        ///  The set of account proxies. Maps the account which has delegated to the accounts
        ///  which are being delegated to, together with the amount held on deposit.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.pallet_proxy.ProxyDefinition>, Substrate.NetApi.Model.Types.Primitive.U128>> Proxies(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = ProxiesParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.pallet_proxy.ProxyDefinition>, Substrate.NetApi.Model.Types.Primitive.U128>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> AnnouncementsParams
        ///  The announcements made by the proxy (key).
        /// </summary>
        public static string AnnouncementsParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Proxy", "Announcements", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> AnnouncementsDefault
        /// Default value as hex string
        /// </summary>
        public static string AnnouncementsDefault()
        {
            return "0x0000000000000000000000000000000000";
        }

        /// <summary>
        /// >> Announcements
        ///  The announcements made by the proxy (key).
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.pallet_proxy.Announcement>, Substrate.NetApi.Model.Types.Primitive.U128>> Announcements(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = AnnouncementsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.pallet_proxy.Announcement>, Substrate.NetApi.Model.Types.Primitive.U128>>(parameters, blockHash, token);
            return result;
        }

        public ProxyStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class ProxyConstants
    {
        /// <summary>
        /// >> ProxyDepositBase
        ///  The base amount of currency needed to reserve for creating a proxy.
        /// 
        ///  This is held for an additional storage item whose value size is
        ///  `sizeof(Balance)` bytes and whose key size is `sizeof(AccountId)` bytes.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 ProxyDepositBase()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0xB07D3B870F0000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> ProxyDepositFactor
        ///  The amount of currency needed per proxy added.
        /// 
        ///  This is held for adding 32 bytes plus an instance of `ProxyType` more into a
        ///  pre-existing storage value. Thus, when configuring `ProxyDepositFactor` one should take
        ///  into account `32 + proxy_type.encode().len()` bytes of data.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 ProxyDepositFactor()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x34738E06000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> MaxProxies
        ///  The maximum amount of proxies allowed for a single account.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxProxies()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x20000000");
            return result;
        }

        /// <summary>
        /// >> MaxPending
        ///  The maximum amount of time-delayed announcements that are allowed to be pending.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxPending()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x20000000");
            return result;
        }

        /// <summary>
        /// >> AnnouncementDepositBase
        ///  The base amount of currency needed to reserve for creating an announcement.
        /// 
        ///  This is held when a new storage item holding a `Balance` is created (typically 16
        ///  bytes).
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 AnnouncementDepositBase()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0xB07D3B870F0000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> AnnouncementDepositFactor
        ///  The amount of currency needed per announcement made.
        /// 
        ///  This is held for adding an `AccountId`, `Hash` and `BlockNumber` (typically 68 bytes)
        ///  into a pre-existing storage value.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 AnnouncementDepositFactor()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x68E61C0D000000000000000000000000");
            return result;
        }
    }

    public enum ProxyErrors
    {
        /// <summary>
        /// >> TooMany
        /// There are too many proxies registered or too many announcements pending.
        /// </summary>
        TooMany,
        /// <summary>
        /// >> NotFound
        /// Proxy registration not found.
        /// </summary>
        NotFound,
        /// <summary>
        /// >> NotProxy
        /// Sender is not a proxy of the account to be proxied.
        /// </summary>
        NotProxy,
        /// <summary>
        /// >> Unproxyable
        /// A call which is incompatible with the proxy type's filter was attempted.
        /// </summary>
        Unproxyable,
        /// <summary>
        /// >> Duplicate
        /// Account is already a proxy.
        /// </summary>
        Duplicate,
        /// <summary>
        /// >> NoPermission
        /// Call may not be made by proxy because it may escalate its privileges.
        /// </summary>
        NoPermission,
        /// <summary>
        /// >> Unannounced
        /// Announcement, if made at all, was made too recently.
        /// </summary>
        Unannounced,
        /// <summary>
        /// >> NoSelfProxy
        /// Cannot add self as proxy.
        /// </summary>
        NoSelfProxy
    }
}