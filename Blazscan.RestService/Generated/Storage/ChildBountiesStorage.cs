//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using Ajuna.ServiceLayer.Attributes;
using Ajuna.ServiceLayer.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Blazscan.RestService.Generated.Storage
{
    
    
    /// <summary>
    /// IChildBountiesStorage interface definition.
    /// </summary>
    public interface IChildBountiesStorage : IStorage
    {
        
        /// <summary>
        /// >> ChildBountyCount
        ///  Number of total child bounties.
        /// </summary>
        Ajuna.NetApi.Model.Types.Primitive.U32 GetChildBountyCount();
        
        /// <summary>
        /// >> ParentChildBounties
        ///  Number of child bounties per parent bounty.
        ///  Map of parent bounty index to number of child bounties.
        /// </summary>
        Ajuna.NetApi.Model.Types.Primitive.U32 GetParentChildBounties(string key);
        
        /// <summary>
        /// >> ChildBounties
        ///  Child bounties that have been added.
        /// </summary>
        Blazscan.NetApiExt.Generated.Model.pallet_child_bounties.ChildBounty GetChildBounties(string key);
        
        /// <summary>
        /// >> ChildBountyDescriptions
        ///  The description of each child-bounty.
        /// </summary>
        Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT19 GetChildBountyDescriptions(string key);
        
        /// <summary>
        /// >> ChildrenCuratorFees
        ///  The cumulative child-bounty curator fee for each parent bounty.
        /// </summary>
        Ajuna.NetApi.Model.Types.Primitive.U128 GetChildrenCuratorFees(string key);
    }
    
    /// <summary>
    /// ChildBountiesStorage class definition.
    /// </summary>
    public sealed class ChildBountiesStorage : IChildBountiesStorage
    {
        
        /// <summary>
        /// _childBountyCountTypedStorage typed storage field
        /// </summary>
        private TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32> _childBountyCountTypedStorage;
        
        /// <summary>
        /// _parentChildBountiesTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<Ajuna.NetApi.Model.Types.Primitive.U32> _parentChildBountiesTypedStorage;
        
        /// <summary>
        /// _childBountiesTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<Blazscan.NetApiExt.Generated.Model.pallet_child_bounties.ChildBounty> _childBountiesTypedStorage;
        
        /// <summary>
        /// _childBountyDescriptionsTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT19> _childBountyDescriptionsTypedStorage;
        
        /// <summary>
        /// _childrenCuratorFeesTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<Ajuna.NetApi.Model.Types.Primitive.U128> _childrenCuratorFeesTypedStorage;
        
        /// <summary>
        /// ChildBountiesStorage constructor.
        /// </summary>
        public ChildBountiesStorage(IStorageDataProvider storageDataProvider, List<IStorageChangeDelegate> storageChangeDelegates)
        {
            this.ChildBountyCountTypedStorage = new TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32>("ChildBounties.ChildBountyCount", storageDataProvider, storageChangeDelegates);
            this.ParentChildBountiesTypedStorage = new TypedMapStorage<Ajuna.NetApi.Model.Types.Primitive.U32>("ChildBounties.ParentChildBounties", storageDataProvider, storageChangeDelegates);
            this.ChildBountiesTypedStorage = new TypedMapStorage<Blazscan.NetApiExt.Generated.Model.pallet_child_bounties.ChildBounty>("ChildBounties.ChildBounties", storageDataProvider, storageChangeDelegates);
            this.ChildBountyDescriptionsTypedStorage = new TypedMapStorage<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT19>("ChildBounties.ChildBountyDescriptions", storageDataProvider, storageChangeDelegates);
            this.ChildrenCuratorFeesTypedStorage = new TypedMapStorage<Ajuna.NetApi.Model.Types.Primitive.U128>("ChildBounties.ChildrenCuratorFees", storageDataProvider, storageChangeDelegates);
        }
        
        /// <summary>
        /// _childBountyCountTypedStorage property
        /// </summary>
        public TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32> ChildBountyCountTypedStorage
        {
            get
            {
                return _childBountyCountTypedStorage;
            }
            set
            {
                _childBountyCountTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _parentChildBountiesTypedStorage property
        /// </summary>
        public TypedMapStorage<Ajuna.NetApi.Model.Types.Primitive.U32> ParentChildBountiesTypedStorage
        {
            get
            {
                return _parentChildBountiesTypedStorage;
            }
            set
            {
                _parentChildBountiesTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _childBountiesTypedStorage property
        /// </summary>
        public TypedMapStorage<Blazscan.NetApiExt.Generated.Model.pallet_child_bounties.ChildBounty> ChildBountiesTypedStorage
        {
            get
            {
                return _childBountiesTypedStorage;
            }
            set
            {
                _childBountiesTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _childBountyDescriptionsTypedStorage property
        /// </summary>
        public TypedMapStorage<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT19> ChildBountyDescriptionsTypedStorage
        {
            get
            {
                return _childBountyDescriptionsTypedStorage;
            }
            set
            {
                _childBountyDescriptionsTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _childrenCuratorFeesTypedStorage property
        /// </summary>
        public TypedMapStorage<Ajuna.NetApi.Model.Types.Primitive.U128> ChildrenCuratorFeesTypedStorage
        {
            get
            {
                return _childrenCuratorFeesTypedStorage;
            }
            set
            {
                _childrenCuratorFeesTypedStorage = value;
            }
        }
        
        /// <summary>
        /// Connects to all storages and initializes the change subscription handling.
        /// </summary>
        public async Task InitializeAsync(Ajuna.ServiceLayer.Storage.IStorageDataProvider dataProvider)
        {
            await ChildBountyCountTypedStorage.InitializeAsync("ChildBounties", "ChildBountyCount");
            await ParentChildBountiesTypedStorage.InitializeAsync("ChildBounties", "ParentChildBounties");
            await ChildBountiesTypedStorage.InitializeAsync("ChildBounties", "ChildBounties");
            await ChildBountyDescriptionsTypedStorage.InitializeAsync("ChildBounties", "ChildBountyDescriptions");
            await ChildrenCuratorFeesTypedStorage.InitializeAsync("ChildBounties", "ChildrenCuratorFees");
        }
        
        /// <summary>
        /// Implements any storage change for ChildBounties.ChildBountyCount
        /// </summary>
        [StorageChange("ChildBounties", "ChildBountyCount")]
        public void OnUpdateChildBountyCount(string data)
        {
            ChildBountyCountTypedStorage.Update(data);
        }
        
        /// <summary>
        /// >> ChildBountyCount
        ///  Number of total child bounties.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 GetChildBountyCount()
        {
            return ChildBountyCountTypedStorage.Get();
        }
        
        /// <summary>
        /// Implements any storage change for ChildBounties.ParentChildBounties
        /// </summary>
        [StorageChange("ChildBounties", "ParentChildBounties")]
        public void OnUpdateParentChildBounties(string key, string data)
        {
            ParentChildBountiesTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> ParentChildBounties
        ///  Number of child bounties per parent bounty.
        ///  Map of parent bounty index to number of child bounties.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 GetParentChildBounties(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (ParentChildBountiesTypedStorage.Dictionary.TryGetValue(key, out Ajuna.NetApi.Model.Types.Primitive.U32 result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Implements any storage change for ChildBounties.ChildBounties
        /// </summary>
        [StorageChange("ChildBounties", "ChildBounties")]
        public void OnUpdateChildBounties(string key, string data)
        {
            ChildBountiesTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> ChildBounties
        ///  Child bounties that have been added.
        /// </summary>
        public Blazscan.NetApiExt.Generated.Model.pallet_child_bounties.ChildBounty GetChildBounties(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (ChildBountiesTypedStorage.Dictionary.TryGetValue(key, out Blazscan.NetApiExt.Generated.Model.pallet_child_bounties.ChildBounty result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Implements any storage change for ChildBounties.ChildBountyDescriptions
        /// </summary>
        [StorageChange("ChildBounties", "ChildBountyDescriptions")]
        public void OnUpdateChildBountyDescriptions(string key, string data)
        {
            ChildBountyDescriptionsTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> ChildBountyDescriptions
        ///  The description of each child-bounty.
        /// </summary>
        public Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT19 GetChildBountyDescriptions(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (ChildBountyDescriptionsTypedStorage.Dictionary.TryGetValue(key, out Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT19 result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Implements any storage change for ChildBounties.ChildrenCuratorFees
        /// </summary>
        [StorageChange("ChildBounties", "ChildrenCuratorFees")]
        public void OnUpdateChildrenCuratorFees(string key, string data)
        {
            ChildrenCuratorFeesTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> ChildrenCuratorFees
        ///  The cumulative child-bounty curator fee for each parent bounty.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 GetChildrenCuratorFees(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (ChildrenCuratorFeesTypedStorage.Dictionary.TryGetValue(key, out Ajuna.NetApi.Model.Types.Primitive.U128 result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
