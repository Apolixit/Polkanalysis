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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9250
{
    public sealed class ChildBountiesStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> ChildBountyCountParams
        ///  Number of total child bounties.
        /// </summary>
        public static string ChildBountyCountParams()
        {
            return RequestGenerator.GetStorage("ChildBounties", "ChildBountyCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ChildBountyCountDefault
        /// Default value as hex string
        /// </summary>
        public static string ChildBountyCountDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> ChildBountyCount
        ///  Number of total child bounties.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> ChildBountyCount(CancellationToken token)
        {
            string parameters = ChildBountyCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ParentChildBountiesParams
        ///  Number of child bounties per parent bounty.
        ///  Map of parent bounty index to number of child bounties.
        /// </summary>
        public static string ParentChildBountiesParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("ChildBounties", "ParentChildBounties", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ParentChildBountiesDefault
        /// Default value as hex string
        /// </summary>
        public static string ParentChildBountiesDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> ParentChildBounties
        ///  Number of child bounties per parent bounty.
        ///  Map of parent bounty index to number of child bounties.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> ParentChildBounties(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ParentChildBountiesParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ChildBountiesParams
        ///  Child bounties that have been added.
        /// </summary>
        public static string ChildBountiesParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32> key)
        {
            return RequestGenerator.GetStorage("ChildBounties", "ChildBounties", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat, Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, key.Value);
        }

        /// <summary>
        /// >> ChildBountiesDefault
        /// Default value as hex string
        /// </summary>
        public static string ChildBountiesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ChildBounties
        ///  Child bounties that have been added.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.pallet_child_bounties.ChildBounty> ChildBounties(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32> key, CancellationToken token)
        {
            string parameters = ChildBountiesParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.pallet_child_bounties.ChildBounty>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ChildBountyDescriptionsParams
        ///  The description of each child-bounty.
        /// </summary>
        public static string ChildBountyDescriptionsParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("ChildBounties", "ChildBountyDescriptions", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ChildBountyDescriptionsDefault
        /// Default value as hex string
        /// </summary>
        public static string ChildBountyDescriptionsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ChildBountyDescriptions
        ///  The description of each child-bounty.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> ChildBountyDescriptions(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ChildBountyDescriptionsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ChildrenCuratorFeesParams
        ///  The cumulative child-bounty curator fee for each parent bounty.
        /// </summary>
        public static string ChildrenCuratorFeesParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("ChildBounties", "ChildrenCuratorFees", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ChildrenCuratorFeesDefault
        /// Default value as hex string
        /// </summary>
        public static string ChildrenCuratorFeesDefault()
        {
            return "0x00000000000000000000000000000000";
        }

        /// <summary>
        /// >> ChildrenCuratorFees
        ///  The cumulative child-bounty curator fee for each parent bounty.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U128> ChildrenCuratorFees(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ChildrenCuratorFeesParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U128>(parameters, blockHash, token);
            return result;
        }

        public ChildBountiesStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class ChildBountiesConstants
    {
        /// <summary>
        /// >> MaxActiveChildBountyCount
        ///  Maximum number of child bounties that can be added to a parent bounty.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxActiveChildBountyCount()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x64000000");
            return result;
        }

        /// <summary>
        /// >> ChildBountyValueMinimum
        ///  Minimum value for a child-bounty.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 ChildBountyValueMinimum()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0xA486BC27000000000000000000000000");
            return result;
        }
    }

    public enum ChildBountiesErrors
    {
        /// <summary>
        /// >> ParentBountyNotActive
        /// The parent bounty is not in active state.
        /// </summary>
        ParentBountyNotActive,
        /// <summary>
        /// >> InsufficientBountyBalance
        /// The bounty balance is not enough to add new child-bounty.
        /// </summary>
        InsufficientBountyBalance,
        /// <summary>
        /// >> TooManyChildBounties
        /// Number of child bounties exceeds limit `MaxActiveChildBountyCount`.
        /// </summary>
        TooManyChildBounties
    }
}