//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage
{
    
    
    public sealed class TechnicalMembershipStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public TechnicalMembershipStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("TechnicalMembership", "Members"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT14)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("TechnicalMembership", "Prime"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32)));
        }
        
        /// <summary>
        /// >> MembersParams
        ///  The current membership, stored as an ordered Vec.
        /// </summary>
        public static string MembersParams()
        {
            return RequestGenerator.GetStorage("TechnicalMembership", "Members", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> Members
        ///  The current membership, stored as an ordered Vec.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT14> Members(CancellationToken token)
        {
            string parameters = TechnicalMembershipStorage.MembersParams();
            return await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT14>(parameters, token);
        }
        
        /// <summary>
        /// >> PrimeParams
        ///  The current prime member, if one exists.
        /// </summary>
        public static string PrimeParams()
        {
            return RequestGenerator.GetStorage("TechnicalMembership", "Prime", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> Prime
        ///  The current prime member, if one exists.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> Prime(CancellationToken token)
        {
            string parameters = TechnicalMembershipStorage.PrimeParams();
            return await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>(parameters, token);
        }
    }
    
    public sealed class TechnicalMembershipCalls
    {
        
        /// <summary>
        /// >> add_member
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method AddMember(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress who)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(who.Encode());
            return new Method(17, "TechnicalMembership", 0, "add_member", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_member
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method RemoveMember(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress who)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(who.Encode());
            return new Method(17, "TechnicalMembership", 1, "remove_member", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> swap_member
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SwapMember(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress remove, Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress add)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(remove.Encode());
            byteArray.AddRange(add.Encode());
            return new Method(17, "TechnicalMembership", 2, "swap_member", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> reset_members
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ResetMembers(Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> members)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(members.Encode());
            return new Method(17, "TechnicalMembership", 3, "reset_members", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> change_key
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ChangeKey(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(17, "TechnicalMembership", 4, "change_key", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_prime
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetPrime(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress who)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(who.Encode());
            return new Method(17, "TechnicalMembership", 5, "set_prime", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> clear_prime
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ClearPrime()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(17, "TechnicalMembership", 6, "clear_prime", byteArray.ToArray());
        }
    }
    
    public enum TechnicalMembershipErrors
    {
        
        /// <summary>
        /// >> AlreadyMember
        /// Already a member.
        /// </summary>
        AlreadyMember,
        
        /// <summary>
        /// >> NotMember
        /// Not a member.
        /// </summary>
        NotMember,
        
        /// <summary>
        /// >> TooManyMembers
        /// Too many members.
        /// </summary>
        TooManyMembers,
    }
}
