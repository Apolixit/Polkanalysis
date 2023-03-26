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
    
    
    public sealed class CouncilMembershipStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public CouncilMembershipStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("CouncilMembership", "Members"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT22)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("CouncilMembership", "Prime"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32)));
        }
        
        /// <summary>
        /// >> MembersParams
        ///  The current membership, stored as an ordered Vec.
        /// </summary>
        public static string MembersParams()
        {
            return RequestGenerator.GetStorage("CouncilMembership", "Members", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> Members
        ///  The current membership, stored as an ordered Vec.
        /// </summary>
        public async Task<Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT22> Members(CancellationToken token)
        {
            string parameters = CouncilMembershipStorage.MembersParams();
            return await _client.GetStorageAsync<Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT22>(parameters, token);
        }
        
        /// <summary>
        /// >> PrimeParams
        ///  The current prime member, if one exists.
        /// </summary>
        public static string PrimeParams()
        {
            return RequestGenerator.GetStorage("CouncilMembership", "Prime", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> Prime
        ///  The current prime member, if one exists.
        /// </summary>
        public async Task<Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> Prime(CancellationToken token)
        {
            string parameters = CouncilMembershipStorage.PrimeParams();
            return await _client.GetStorageAsync<Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>(parameters, token);
        }
    }
    
    public sealed class CouncilMembershipCalls
    {
        
        /// <summary>
        /// >> add_member
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method AddMember(Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 who)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(who.Encode());
            return new Method(43, "CouncilMembership", 0, "add_member", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_member
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method RemoveMember(Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 who)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(who.Encode());
            return new Method(43, "CouncilMembership", 1, "remove_member", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> swap_member
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SwapMember(Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 remove, Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 add)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(remove.Encode());
            byteArray.AddRange(add.Encode());
            return new Method(43, "CouncilMembership", 2, "swap_member", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> reset_members
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ResetMembers(Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> members)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(members.Encode());
            return new Method(43, "CouncilMembership", 3, "reset_members", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> change_key
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ChangeKey(Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(43, "CouncilMembership", 4, "change_key", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_prime
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetPrime(Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 who)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(who.Encode());
            return new Method(43, "CouncilMembership", 5, "set_prime", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> clear_prime
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ClearPrime()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(43, "CouncilMembership", 6, "clear_prime", byteArray.ToArray());
        }
    }
    
    public enum CouncilMembershipErrors
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
