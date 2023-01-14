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
    
    
    public sealed class AuraStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public AuraStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Aura", "Authorities"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT19)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Aura", "CurrentSlot"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Bajun.NetApiExt.Generated.Model.sp_consensus_slots.Slot)));
        }
        
        /// <summary>
        /// >> AuthoritiesParams
        ///  The current authority set.
        /// </summary>
        public static string AuthoritiesParams()
        {
            return RequestGenerator.GetStorage("Aura", "Authorities", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> Authorities
        ///  The current authority set.
        /// </summary>
        public async Task<Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT19> Authorities(CancellationToken token)
        {
            string parameters = AuraStorage.AuthoritiesParams();
            return await _client.GetStorageAsync<Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT19>(parameters, token);
        }
        
        /// <summary>
        /// >> CurrentSlotParams
        ///  The current slot of this block.
        /// 
        ///  This will be set in `on_initialize`.
        /// </summary>
        public static string CurrentSlotParams()
        {
            return RequestGenerator.GetStorage("Aura", "CurrentSlot", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> CurrentSlot
        ///  The current slot of this block.
        /// 
        ///  This will be set in `on_initialize`.
        /// </summary>
        public async Task<Substats.Bajun.NetApiExt.Generated.Model.sp_consensus_slots.Slot> CurrentSlot(CancellationToken token)
        {
            string parameters = AuraStorage.CurrentSlotParams();
            return await _client.GetStorageAsync<Substats.Bajun.NetApiExt.Generated.Model.sp_consensus_slots.Slot>(parameters, token);
        }
    }
    
    public sealed class AuraCalls
    {
    }
}
