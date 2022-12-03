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


namespace Blazscan.NetApiExt.Generated.Storage
{
    
    
    public sealed class ProxyStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public ProxyStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Proxy", "Proxies"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT17, Ajuna.NetApi.Model.Types.Primitive.U128>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Proxy", "Announcements"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT18, Ajuna.NetApi.Model.Types.Primitive.U128>)));
        }
        
        /// <summary>
        /// >> ProxiesParams
        ///  The set of account proxies. Maps the account which has delegated to the accounts
        ///  which are being delegated to, together with the amount held on deposit.
        /// </summary>
        public static string ProxiesParams(Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Proxy", "Proxies", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Proxies
        ///  The set of account proxies. Maps the account which has delegated to the accounts
        ///  which are being delegated to, together with the amount held on deposit.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT17, Ajuna.NetApi.Model.Types.Primitive.U128>> Proxies(Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = ProxyStorage.ProxiesParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT17, Ajuna.NetApi.Model.Types.Primitive.U128>>(parameters, token);
        }
        
        /// <summary>
        /// >> AnnouncementsParams
        ///  The announcements made by the proxy (key).
        /// </summary>
        public static string AnnouncementsParams(Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Proxy", "Announcements", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Announcements
        ///  The announcements made by the proxy (key).
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT18, Ajuna.NetApi.Model.Types.Primitive.U128>> Announcements(Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = ProxyStorage.AnnouncementsParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT18, Ajuna.NetApi.Model.Types.Primitive.U128>>(parameters, token);
        }
    }
    
    public sealed class ProxyCalls
    {
        
        /// <summary>
        /// >> proxy
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Proxy(Blazscan.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress real, Ajuna.NetApi.Model.Types.Base.BaseOpt<Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumProxyType> force_proxy_type, Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(real.Encode());
            byteArray.AddRange(force_proxy_type.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(29, "Proxy", 0, "proxy", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> add_proxy
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method AddProxy(Blazscan.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress @delegate, Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumProxyType proxy_type, Ajuna.NetApi.Model.Types.Primitive.U32 delay)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@delegate.Encode());
            byteArray.AddRange(proxy_type.Encode());
            byteArray.AddRange(delay.Encode());
            return new Method(29, "Proxy", 1, "add_proxy", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_proxy
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method RemoveProxy(Blazscan.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress @delegate, Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumProxyType proxy_type, Ajuna.NetApi.Model.Types.Primitive.U32 delay)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@delegate.Encode());
            byteArray.AddRange(proxy_type.Encode());
            byteArray.AddRange(delay.Encode());
            return new Method(29, "Proxy", 2, "remove_proxy", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_proxies
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method RemoveProxies()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(29, "Proxy", 3, "remove_proxies", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> create_pure
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method CreatePure(Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumProxyType proxy_type, Ajuna.NetApi.Model.Types.Primitive.U32 delay, Ajuna.NetApi.Model.Types.Primitive.U16 index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(proxy_type.Encode());
            byteArray.AddRange(delay.Encode());
            byteArray.AddRange(index.Encode());
            return new Method(29, "Proxy", 4, "create_pure", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> kill_pure
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method KillPure(Blazscan.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress spawner, Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumProxyType proxy_type, Ajuna.NetApi.Model.Types.Primitive.U16 index, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> height, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> ext_index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(spawner.Encode());
            byteArray.AddRange(proxy_type.Encode());
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(height.Encode());
            byteArray.AddRange(ext_index.Encode());
            return new Method(29, "Proxy", 5, "kill_pure", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> announce
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Announce(Blazscan.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress real, Blazscan.NetApiExt.Generated.Model.primitive_types.H256 call_hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(real.Encode());
            byteArray.AddRange(call_hash.Encode());
            return new Method(29, "Proxy", 6, "announce", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_announcement
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method RemoveAnnouncement(Blazscan.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress real, Blazscan.NetApiExt.Generated.Model.primitive_types.H256 call_hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(real.Encode());
            byteArray.AddRange(call_hash.Encode());
            return new Method(29, "Proxy", 7, "remove_announcement", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> reject_announcement
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method RejectAnnouncement(Blazscan.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress @delegate, Blazscan.NetApiExt.Generated.Model.primitive_types.H256 call_hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@delegate.Encode());
            byteArray.AddRange(call_hash.Encode());
            return new Method(29, "Proxy", 8, "reject_announcement", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> proxy_announced
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ProxyAnnounced(Blazscan.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress @delegate, Blazscan.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress real, Ajuna.NetApi.Model.Types.Base.BaseOpt<Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumProxyType> force_proxy_type, Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@delegate.Encode());
            byteArray.AddRange(real.Encode());
            byteArray.AddRange(force_proxy_type.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(29, "Proxy", 9, "proxy_announced", byteArray.ToArray());
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
        NoSelfProxy,
    }
}
