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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage
{
    
    
    public sealed class ChildBountiesStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public ChildBountiesStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ChildBounties", "ChildBountyCount"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ChildBounties", "ParentChildBounties"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Ajuna.NetApi.Model.Types.Primitive.U32), typeof(Ajuna.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ChildBounties", "ChildBounties"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>), typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_child_bounties.ChildBounty)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ChildBounties", "ChildBountyDescriptions"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Ajuna.NetApi.Model.Types.Primitive.U32), typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT25)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ChildBounties", "ChildrenCuratorFees"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Ajuna.NetApi.Model.Types.Primitive.U32), typeof(Ajuna.NetApi.Model.Types.Primitive.U128)));
        }
        
        /// <summary>
        /// >> ChildBountyCountParams
        ///  Number of total child bounties.
        /// </summary>
        public static string ChildBountyCountParams()
        {
            return RequestGenerator.GetStorage("ChildBounties", "ChildBountyCount", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> ChildBountyCount(CancellationToken token)
        {
            string parameters = ChildBountiesStorage.ChildBountyCountParams();
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> ParentChildBountiesParams
        ///  Number of child bounties per parent bounty.
        ///  Map of parent bounty index to number of child bounties.
        /// </summary>
        public static string ParentChildBountiesParams(Ajuna.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("ChildBounties", "ParentChildBounties", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
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
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> ParentChildBounties(Ajuna.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ChildBountiesStorage.ParentChildBountiesParams(key);
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> ChildBountiesParams
        ///  Child bounties that have been added.
        /// </summary>
        public static string ChildBountiesParams(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32> key)
        {
            return RequestGenerator.GetStorage("ChildBounties", "ChildBounties", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, key.Value);
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
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_child_bounties.ChildBounty> ChildBounties(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32> key, CancellationToken token)
        {
            string parameters = ChildBountiesStorage.ChildBountiesParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_child_bounties.ChildBounty>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> ChildBountyDescriptionsParams
        ///  The description of each child-bounty.
        /// </summary>
        public static string ChildBountyDescriptionsParams(Ajuna.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("ChildBounties", "ChildBountyDescriptions", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
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
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT25> ChildBountyDescriptions(Ajuna.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ChildBountiesStorage.ChildBountyDescriptionsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT25>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> ChildrenCuratorFeesParams
        ///  The cumulative child-bounty curator fee for each parent bounty.
        /// </summary>
        public static string ChildrenCuratorFeesParams(Ajuna.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("ChildBounties", "ChildrenCuratorFees", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
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
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U128> ChildrenCuratorFees(Ajuna.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ChildBountiesStorage.ChildrenCuratorFeesParams(key);
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U128>(parameters, token);
            return result;
        }
    }
    
    public sealed class ChildBountiesCalls
    {
        
        /// <summary>
        /// >> add_child_bounty
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method AddChildBounty(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> parent_bounty_id, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128> value, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> description)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(parent_bounty_id.Encode());
            byteArray.AddRange(value.Encode());
            byteArray.AddRange(description.Encode());
            return new Method(38, "ChildBounties", 0, "add_child_bounty", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> propose_curator
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ProposeCurator(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> parent_bounty_id, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> child_bounty_id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress curator, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128> fee)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(parent_bounty_id.Encode());
            byteArray.AddRange(child_bounty_id.Encode());
            byteArray.AddRange(curator.Encode());
            byteArray.AddRange(fee.Encode());
            return new Method(38, "ChildBounties", 1, "propose_curator", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> accept_curator
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method AcceptCurator(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> parent_bounty_id, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> child_bounty_id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(parent_bounty_id.Encode());
            byteArray.AddRange(child_bounty_id.Encode());
            return new Method(38, "ChildBounties", 2, "accept_curator", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> unassign_curator
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method UnassignCurator(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> parent_bounty_id, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> child_bounty_id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(parent_bounty_id.Encode());
            byteArray.AddRange(child_bounty_id.Encode());
            return new Method(38, "ChildBounties", 3, "unassign_curator", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> award_child_bounty
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method AwardChildBounty(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> parent_bounty_id, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> child_bounty_id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress beneficiary)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(parent_bounty_id.Encode());
            byteArray.AddRange(child_bounty_id.Encode());
            byteArray.AddRange(beneficiary.Encode());
            return new Method(38, "ChildBounties", 4, "award_child_bounty", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> claim_child_bounty
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ClaimChildBounty(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> parent_bounty_id, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> child_bounty_id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(parent_bounty_id.Encode());
            byteArray.AddRange(child_bounty_id.Encode());
            return new Method(38, "ChildBounties", 5, "claim_child_bounty", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> close_child_bounty
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method CloseChildBounty(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> parent_bounty_id, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> child_bounty_id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(parent_bounty_id.Encode());
            byteArray.AddRange(child_bounty_id.Encode());
            return new Method(38, "ChildBounties", 6, "close_child_bounty", byteArray.ToArray());
        }
    }
    
    public sealed class ChildBountiesConstants
    {
        
        /// <summary>
        /// >> MaxActiveChildBountyCount
        ///  Maximum number of child bounties that can be added to a parent bounty.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaxActiveChildBountyCount()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0x64000000");
            return result;
        }
        
        /// <summary>
        /// >> ChildBountyValueMinimum
        ///  Minimum value for a child-bounty.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 ChildBountyValueMinimum()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00E40B54020000000000000000000000");
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
        TooManyChildBounties,
    }
}
