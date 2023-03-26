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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Storage
{
    
    
    public sealed class AuraExtStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public AuraExtStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AuraExt", "Authorities"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT19)));
        }
        
        /// <summary>
        /// >> AuthoritiesParams
        ///  Serves as cache for the authorities.
        /// 
        ///  The authorities in AuRa are overwritten in `on_initialize` when we switch to a new session,
        ///  but we require the old authorities to verify the seal when validating a PoV. This will always
        ///  be updated to the latest AuRa authorities in `on_finalize`.
        /// </summary>
        public static string AuthoritiesParams()
        {
            return RequestGenerator.GetStorage("AuraExt", "Authorities", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> Authorities
        ///  Serves as cache for the authorities.
        /// 
        ///  The authorities in AuRa are overwritten in `on_initialize` when we switch to a new session,
        ///  but we require the old authorities to verify the seal when validating a PoV. This will always
        ///  be updated to the latest AuRa authorities in `on_finalize`.
        /// </summary>
        public async Task<Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT19> Authorities(CancellationToken token)
        {
            string parameters = AuraExtStorage.AuthoritiesParams();
            return await _client.GetStorageAsync<Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT19>(parameters, token);
        }
    }
    
    public sealed class AuraExtCalls
    {
    }
}
