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
    /// ITechnicalCommitteeStorage interface definition.
    /// </summary>
    public interface ITechnicalCommitteeStorage : IStorage
    {
        
        /// <summary>
        /// >> Proposals
        ///  The hashes of the active proposals.
        /// </summary>
        Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT10 GetProposals();
        
        /// <summary>
        /// >> ProposalOf
        ///  Actual proposal for a given hash, if it's current.
        /// </summary>
        Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeCall GetProposalOf(string key);
        
        /// <summary>
        /// >> Voting
        ///  Votes on a given proposal, if it is ongoing.
        /// </summary>
        Blazscan.NetApiExt.Generated.Model.pallet_collective.Votes GetVoting(string key);
        
        /// <summary>
        /// >> ProposalCount
        ///  Proposals so far.
        /// </summary>
        Ajuna.NetApi.Model.Types.Primitive.U32 GetProposalCount();
        
        /// <summary>
        /// >> Members
        ///  The current members of the collective. This is stored sorted (just by value).
        /// </summary>
        Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> GetMembers();
        
        /// <summary>
        /// >> Prime
        ///  The prime member that helps determine the default vote behavior in case of absentations.
        /// </summary>
        Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 GetPrime();
    }
    
    /// <summary>
    /// TechnicalCommitteeStorage class definition.
    /// </summary>
    public sealed class TechnicalCommitteeStorage : ITechnicalCommitteeStorage
    {
        
        /// <summary>
        /// _proposalsTypedStorage typed storage field
        /// </summary>
        private TypedStorage<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT10> _proposalsTypedStorage;
        
        /// <summary>
        /// _proposalOfTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeCall> _proposalOfTypedStorage;
        
        /// <summary>
        /// _votingTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<Blazscan.NetApiExt.Generated.Model.pallet_collective.Votes> _votingTypedStorage;
        
        /// <summary>
        /// _proposalCountTypedStorage typed storage field
        /// </summary>
        private TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32> _proposalCountTypedStorage;
        
        /// <summary>
        /// _membersTypedStorage typed storage field
        /// </summary>
        private TypedStorage<Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>> _membersTypedStorage;
        
        /// <summary>
        /// _primeTypedStorage typed storage field
        /// </summary>
        private TypedStorage<Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> _primeTypedStorage;
        
        /// <summary>
        /// TechnicalCommitteeStorage constructor.
        /// </summary>
        public TechnicalCommitteeStorage(IStorageDataProvider storageDataProvider, List<IStorageChangeDelegate> storageChangeDelegates)
        {
            this.ProposalsTypedStorage = new TypedStorage<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT10>("TechnicalCommittee.Proposals", storageDataProvider, storageChangeDelegates);
            this.ProposalOfTypedStorage = new TypedMapStorage<Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeCall>("TechnicalCommittee.ProposalOf", storageDataProvider, storageChangeDelegates);
            this.VotingTypedStorage = new TypedMapStorage<Blazscan.NetApiExt.Generated.Model.pallet_collective.Votes>("TechnicalCommittee.Voting", storageDataProvider, storageChangeDelegates);
            this.ProposalCountTypedStorage = new TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32>("TechnicalCommittee.ProposalCount", storageDataProvider, storageChangeDelegates);
            this.MembersTypedStorage = new TypedStorage<Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>>("TechnicalCommittee.Members", storageDataProvider, storageChangeDelegates);
            this.PrimeTypedStorage = new TypedStorage<Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>("TechnicalCommittee.Prime", storageDataProvider, storageChangeDelegates);
        }
        
        /// <summary>
        /// _proposalsTypedStorage property
        /// </summary>
        public TypedStorage<Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT10> ProposalsTypedStorage
        {
            get
            {
                return _proposalsTypedStorage;
            }
            set
            {
                _proposalsTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _proposalOfTypedStorage property
        /// </summary>
        public TypedMapStorage<Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeCall> ProposalOfTypedStorage
        {
            get
            {
                return _proposalOfTypedStorage;
            }
            set
            {
                _proposalOfTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _votingTypedStorage property
        /// </summary>
        public TypedMapStorage<Blazscan.NetApiExt.Generated.Model.pallet_collective.Votes> VotingTypedStorage
        {
            get
            {
                return _votingTypedStorage;
            }
            set
            {
                _votingTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _proposalCountTypedStorage property
        /// </summary>
        public TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32> ProposalCountTypedStorage
        {
            get
            {
                return _proposalCountTypedStorage;
            }
            set
            {
                _proposalCountTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _membersTypedStorage property
        /// </summary>
        public TypedStorage<Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>> MembersTypedStorage
        {
            get
            {
                return _membersTypedStorage;
            }
            set
            {
                _membersTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _primeTypedStorage property
        /// </summary>
        public TypedStorage<Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> PrimeTypedStorage
        {
            get
            {
                return _primeTypedStorage;
            }
            set
            {
                _primeTypedStorage = value;
            }
        }
        
        /// <summary>
        /// Connects to all storages and initializes the change subscription handling.
        /// </summary>
        public async Task InitializeAsync(Ajuna.ServiceLayer.Storage.IStorageDataProvider dataProvider)
        {
            await ProposalsTypedStorage.InitializeAsync("TechnicalCommittee", "Proposals");
            await ProposalOfTypedStorage.InitializeAsync("TechnicalCommittee", "ProposalOf");
            await VotingTypedStorage.InitializeAsync("TechnicalCommittee", "Voting");
            await ProposalCountTypedStorage.InitializeAsync("TechnicalCommittee", "ProposalCount");
            await MembersTypedStorage.InitializeAsync("TechnicalCommittee", "Members");
            await PrimeTypedStorage.InitializeAsync("TechnicalCommittee", "Prime");
        }
        
        /// <summary>
        /// Implements any storage change for TechnicalCommittee.Proposals
        /// </summary>
        [StorageChange("TechnicalCommittee", "Proposals")]
        public void OnUpdateProposals(string data)
        {
            ProposalsTypedStorage.Update(data);
        }
        
        /// <summary>
        /// >> Proposals
        ///  The hashes of the active proposals.
        /// </summary>
        public Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT10 GetProposals()
        {
            return ProposalsTypedStorage.Get();
        }
        
        /// <summary>
        /// Implements any storage change for TechnicalCommittee.ProposalOf
        /// </summary>
        [StorageChange("TechnicalCommittee", "ProposalOf")]
        public void OnUpdateProposalOf(string key, string data)
        {
            ProposalOfTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> ProposalOf
        ///  Actual proposal for a given hash, if it's current.
        /// </summary>
        public Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeCall GetProposalOf(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (ProposalOfTypedStorage.Dictionary.TryGetValue(key, out Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeCall result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Implements any storage change for TechnicalCommittee.Voting
        /// </summary>
        [StorageChange("TechnicalCommittee", "Voting")]
        public void OnUpdateVoting(string key, string data)
        {
            VotingTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> Voting
        ///  Votes on a given proposal, if it is ongoing.
        /// </summary>
        public Blazscan.NetApiExt.Generated.Model.pallet_collective.Votes GetVoting(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (VotingTypedStorage.Dictionary.TryGetValue(key, out Blazscan.NetApiExt.Generated.Model.pallet_collective.Votes result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Implements any storage change for TechnicalCommittee.ProposalCount
        /// </summary>
        [StorageChange("TechnicalCommittee", "ProposalCount")]
        public void OnUpdateProposalCount(string data)
        {
            ProposalCountTypedStorage.Update(data);
        }
        
        /// <summary>
        /// >> ProposalCount
        ///  Proposals so far.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 GetProposalCount()
        {
            return ProposalCountTypedStorage.Get();
        }
        
        /// <summary>
        /// Implements any storage change for TechnicalCommittee.Members
        /// </summary>
        [StorageChange("TechnicalCommittee", "Members")]
        public void OnUpdateMembers(string data)
        {
            MembersTypedStorage.Update(data);
        }
        
        /// <summary>
        /// >> Members
        ///  The current members of the collective. This is stored sorted (just by value).
        /// </summary>
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> GetMembers()
        {
            return MembersTypedStorage.Get();
        }
        
        /// <summary>
        /// Implements any storage change for TechnicalCommittee.Prime
        /// </summary>
        [StorageChange("TechnicalCommittee", "Prime")]
        public void OnUpdatePrime(string data)
        {
            PrimeTypedStorage.Update(data);
        }
        
        /// <summary>
        /// >> Prime
        ///  The prime member that helps determine the default vote behavior in case of absentations.
        /// </summary>
        public Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 GetPrime()
        {
            return PrimeTypedStorage.Get();
        }
    }
}
