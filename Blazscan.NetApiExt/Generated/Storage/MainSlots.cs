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
    
    
    public sealed class SlotsStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public SlotsStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Slots", "Leases"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id), typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>>>)));
        }
        
        /// <summary>
        /// >> LeasesParams
        ///  Amounts held on deposit for each (possibly future) leased parachain.
        /// 
        ///  The actual amount locked on its behalf by any account at any time is the maximum of the second values
        ///  of the items in this list whose first value is the account.
        /// 
        ///  The first item in the list is the amount locked for the current Lease Period. Following
        ///  items are for the subsequent lease periods.
        /// 
        ///  The default value (an empty list) implies that the parachain no longer exists (or never
        ///  existed) as far as this pallet is concerned.
        /// 
        ///  If a parachain doesn't exist *yet* but is scheduled to exist in the future, then it
        ///  will be left-padded with one or more `None`s to denote the fact that nothing is held on
        ///  deposit for the non-existent chain currently, but is held at some point in the future.
        /// 
        ///  It is illegal for a `None` value to trail in the list.
        /// </summary>
        public static string LeasesParams(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Slots", "Leases", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Leases
        ///  Amounts held on deposit for each (possibly future) leased parachain.
        /// 
        ///  The actual amount locked on its behalf by any account at any time is the maximum of the second values
        ///  of the items in this list whose first value is the account.
        /// 
        ///  The first item in the list is the amount locked for the current Lease Period. Following
        ///  items are for the subsequent lease periods.
        /// 
        ///  The default value (an empty list) implies that the parachain no longer exists (or never
        ///  existed) as far as this pallet is concerned.
        /// 
        ///  If a parachain doesn't exist *yet* but is scheduled to exist in the future, then it
        ///  will be left-padded with one or more `None`s to denote the fact that nothing is held on
        ///  deposit for the non-existent chain currently, but is held at some point in the future.
        /// 
        ///  It is illegal for a `None` value to trail in the list.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>>>> Leases(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = SlotsStorage.LeasesParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>>>>(parameters, token);
        }
    }
    
    public sealed class SlotsCalls
    {
        
        /// <summary>
        /// >> force_lease
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ForceLease(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id para, Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 leaser, Ajuna.NetApi.Model.Types.Primitive.U128 amount, Ajuna.NetApi.Model.Types.Primitive.U32 period_begin, Ajuna.NetApi.Model.Types.Primitive.U32 period_count)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(para.Encode());
            byteArray.AddRange(leaser.Encode());
            byteArray.AddRange(amount.Encode());
            byteArray.AddRange(period_begin.Encode());
            byteArray.AddRange(period_count.Encode());
            return new Method(71, "Slots", 0, "force_lease", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> clear_all_leases
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ClearAllLeases(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id para)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(para.Encode());
            return new Method(71, "Slots", 1, "clear_all_leases", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> trigger_onboard
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method TriggerOnboard(Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id para)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(para.Encode());
            return new Method(71, "Slots", 2, "trigger_onboard", byteArray.ToArray());
        }
    }
    
    public enum SlotsErrors
    {
        
        /// <summary>
        /// >> ParaNotOnboarding
        /// The parachain ID is not onboarding.
        /// </summary>
        ParaNotOnboarding,
        
        /// <summary>
        /// >> LeaseError
        /// There was an error with the lease.
        /// </summary>
        LeaseError,
    }
}
