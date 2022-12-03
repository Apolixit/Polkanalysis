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
    /// IBountiesStorage interface definition.
    /// </summary>
    public interface IBountiesStorage : IStorage
    {
        
        /// <summary>
        /// >> BountyCount
        ///  Number of bounty proposals that have been made.
        /// </summary>
        Ajuna.NetApi.Model.Types.Primitive.U32 GetBountyCount();
        
        /// <summary>
        /// >> Bounties
        ///  Bounties that have been made.
        /// </summary>
        Blazscan.NetApiExt.Generated.Model.pallet_bounties.Bounty GetBounties(string key);
        
        /// <summary>
        /// >> BountyDescriptions
        ///  The description of each bounty.
        /// </summary>
        Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT19 GetBountyDescriptions(string key);
        
        /// <summary>
        /// >> BountyApprovals
        ///  Bounty indices that have been approved but not yet funded.
        /// </summary>
        Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT12 GetBountyApprovals();
    }
    
    /// <summary>
    /// BountiesStorage class definition.
    /// </summary>
    public sealed class BountiesStorage : IBountiesStorage
    {
        
        /// <summary>
        /// _bountyCountTypedStorage typed storage field
        /// </summary>
        private TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32> _bountyCountTypedStorage;
        
        /// <summary>
        /// _bountiesTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<Blazscan.NetApiExt.Generated.Model.pallet_bounties.Bounty> _bountiesTypedStorage;
        
        /// <summary>
        /// _bountyDescriptionsTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT19> _bountyDescriptionsTypedStorage;
        
        /// <summary>
        /// _bountyApprovalsTypedStorage typed storage field
        /// </summary>
        private TypedStorage<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT12> _bountyApprovalsTypedStorage;
        
        /// <summary>
        /// BountiesStorage constructor.
        /// </summary>
        public BountiesStorage(IStorageDataProvider storageDataProvider, List<IStorageChangeDelegate> storageChangeDelegates)
        {
            this.BountyCountTypedStorage = new TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32>("Bounties.BountyCount", storageDataProvider, storageChangeDelegates);
            this.BountiesTypedStorage = new TypedMapStorage<Blazscan.NetApiExt.Generated.Model.pallet_bounties.Bounty>("Bounties.Bounties", storageDataProvider, storageChangeDelegates);
            this.BountyDescriptionsTypedStorage = new TypedMapStorage<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT19>("Bounties.BountyDescriptions", storageDataProvider, storageChangeDelegates);
            this.BountyApprovalsTypedStorage = new TypedStorage<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT12>("Bounties.BountyApprovals", storageDataProvider, storageChangeDelegates);
        }
        
        /// <summary>
        /// _bountyCountTypedStorage property
        /// </summary>
        public TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32> BountyCountTypedStorage
        {
            get
            {
                return _bountyCountTypedStorage;
            }
            set
            {
                _bountyCountTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _bountiesTypedStorage property
        /// </summary>
        public TypedMapStorage<Blazscan.NetApiExt.Generated.Model.pallet_bounties.Bounty> BountiesTypedStorage
        {
            get
            {
                return _bountiesTypedStorage;
            }
            set
            {
                _bountiesTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _bountyDescriptionsTypedStorage property
        /// </summary>
        public TypedMapStorage<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT19> BountyDescriptionsTypedStorage
        {
            get
            {
                return _bountyDescriptionsTypedStorage;
            }
            set
            {
                _bountyDescriptionsTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _bountyApprovalsTypedStorage property
        /// </summary>
        public TypedStorage<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT12> BountyApprovalsTypedStorage
        {
            get
            {
                return _bountyApprovalsTypedStorage;
            }
            set
            {
                _bountyApprovalsTypedStorage = value;
            }
        }
        
        /// <summary>
        /// Connects to all storages and initializes the change subscription handling.
        /// </summary>
        public async Task InitializeAsync(Ajuna.ServiceLayer.Storage.IStorageDataProvider dataProvider)
        {
            await BountyCountTypedStorage.InitializeAsync("Bounties", "BountyCount");
            await BountiesTypedStorage.InitializeAsync("Bounties", "Bounties");
            await BountyDescriptionsTypedStorage.InitializeAsync("Bounties", "BountyDescriptions");
            await BountyApprovalsTypedStorage.InitializeAsync("Bounties", "BountyApprovals");
        }
        
        /// <summary>
        /// Implements any storage change for Bounties.BountyCount
        /// </summary>
        [StorageChange("Bounties", "BountyCount")]
        public void OnUpdateBountyCount(string data)
        {
            BountyCountTypedStorage.Update(data);
        }
        
        /// <summary>
        /// >> BountyCount
        ///  Number of bounty proposals that have been made.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 GetBountyCount()
        {
            return BountyCountTypedStorage.Get();
        }
        
        /// <summary>
        /// Implements any storage change for Bounties.Bounties
        /// </summary>
        [StorageChange("Bounties", "Bounties")]
        public void OnUpdateBounties(string key, string data)
        {
            BountiesTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> Bounties
        ///  Bounties that have been made.
        /// </summary>
        public Blazscan.NetApiExt.Generated.Model.pallet_bounties.Bounty GetBounties(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (BountiesTypedStorage.Dictionary.TryGetValue(key, out Blazscan.NetApiExt.Generated.Model.pallet_bounties.Bounty result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Implements any storage change for Bounties.BountyDescriptions
        /// </summary>
        [StorageChange("Bounties", "BountyDescriptions")]
        public void OnUpdateBountyDescriptions(string key, string data)
        {
            BountyDescriptionsTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> BountyDescriptions
        ///  The description of each bounty.
        /// </summary>
        public Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT19 GetBountyDescriptions(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (BountyDescriptionsTypedStorage.Dictionary.TryGetValue(key, out Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT19 result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Implements any storage change for Bounties.BountyApprovals
        /// </summary>
        [StorageChange("Bounties", "BountyApprovals")]
        public void OnUpdateBountyApprovals(string data)
        {
            BountyApprovalsTypedStorage.Update(data);
        }
        
        /// <summary>
        /// >> BountyApprovals
        ///  Bounty indices that have been approved but not yet funded.
        /// </summary>
        public Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT12 GetBountyApprovals()
        {
            return BountyApprovalsTypedStorage.Get();
        }
    }
}
