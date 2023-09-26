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
    public sealed class TechnicalMembershipStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> MembersParams
        ///  The current membership, stored as an ordered Vec.
        /// </summary>
        public static string MembersParams()
        {
            return RequestGenerator.GetStorage("TechnicalMembership", "Members", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> MembersDefault
        /// Default value as hex string
        /// </summary>
        public static string MembersDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Members
        ///  The current membership, stored as an ordered Vec.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.sp_core.crypto.AccountId32>> Members(CancellationToken token)
        {
            string parameters = MembersParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.sp_core.crypto.AccountId32>>(parameters, blockHash, token);
            return result;
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
        /// >> PrimeDefault
        /// Default value as hex string
        /// </summary>
        public static string PrimeDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Prime
        ///  The current prime member, if one exists.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.sp_core.crypto.AccountId32> Prime(CancellationToken token)
        {
            string parameters = PrimeParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.sp_core.crypto.AccountId32>(parameters, blockHash, token);
            return result;
        }

        public TechnicalMembershipStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class TechnicalMembershipConstants
    {
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
        TooManyMembers
    }
}