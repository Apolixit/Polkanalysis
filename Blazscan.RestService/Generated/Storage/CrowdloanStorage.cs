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
    /// ICrowdloanStorage interface definition.
    /// </summary>
    public interface ICrowdloanStorage : IStorage
    {
        
        /// <summary>
        /// >> Funds
        ///  Info on all of the funds.
        /// </summary>
        Blazscan.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.FundInfo GetFunds(string key);
        
        /// <summary>
        /// >> NewRaise
        ///  The funds that have had additional contributions during the last block. This is used
        ///  in order to determine which funds should submit new or updated bids.
        /// </summary>
        Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id> GetNewRaise();
        
        /// <summary>
        /// >> EndingsCount
        ///  The number of auctions that have entered into their ending period so far.
        /// </summary>
        Ajuna.NetApi.Model.Types.Primitive.U32 GetEndingsCount();
        
        /// <summary>
        /// >> NextFundIndex
        ///  Tracker for the next available fund index
        /// </summary>
        Ajuna.NetApi.Model.Types.Primitive.U32 GetNextFundIndex();
    }
    
    /// <summary>
    /// CrowdloanStorage class definition.
    /// </summary>
    public sealed class CrowdloanStorage : ICrowdloanStorage
    {
        
        /// <summary>
        /// _fundsTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<Blazscan.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.FundInfo> _fundsTypedStorage;
        
        /// <summary>
        /// _newRaiseTypedStorage typed storage field
        /// </summary>
        private TypedStorage<Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>> _newRaiseTypedStorage;
        
        /// <summary>
        /// _endingsCountTypedStorage typed storage field
        /// </summary>
        private TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32> _endingsCountTypedStorage;
        
        /// <summary>
        /// _nextFundIndexTypedStorage typed storage field
        /// </summary>
        private TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32> _nextFundIndexTypedStorage;
        
        /// <summary>
        /// CrowdloanStorage constructor.
        /// </summary>
        public CrowdloanStorage(IStorageDataProvider storageDataProvider, List<IStorageChangeDelegate> storageChangeDelegates)
        {
            this.FundsTypedStorage = new TypedMapStorage<Blazscan.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.FundInfo>("Crowdloan.Funds", storageDataProvider, storageChangeDelegates);
            this.NewRaiseTypedStorage = new TypedStorage<Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>>("Crowdloan.NewRaise", storageDataProvider, storageChangeDelegates);
            this.EndingsCountTypedStorage = new TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32>("Crowdloan.EndingsCount", storageDataProvider, storageChangeDelegates);
            this.NextFundIndexTypedStorage = new TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32>("Crowdloan.NextFundIndex", storageDataProvider, storageChangeDelegates);
        }
        
        /// <summary>
        /// _fundsTypedStorage property
        /// </summary>
        public TypedMapStorage<Blazscan.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.FundInfo> FundsTypedStorage
        {
            get
            {
                return _fundsTypedStorage;
            }
            set
            {
                _fundsTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _newRaiseTypedStorage property
        /// </summary>
        public TypedStorage<Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>> NewRaiseTypedStorage
        {
            get
            {
                return _newRaiseTypedStorage;
            }
            set
            {
                _newRaiseTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _endingsCountTypedStorage property
        /// </summary>
        public TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32> EndingsCountTypedStorage
        {
            get
            {
                return _endingsCountTypedStorage;
            }
            set
            {
                _endingsCountTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _nextFundIndexTypedStorage property
        /// </summary>
        public TypedStorage<Ajuna.NetApi.Model.Types.Primitive.U32> NextFundIndexTypedStorage
        {
            get
            {
                return _nextFundIndexTypedStorage;
            }
            set
            {
                _nextFundIndexTypedStorage = value;
            }
        }
        
        /// <summary>
        /// Connects to all storages and initializes the change subscription handling.
        /// </summary>
        public async Task InitializeAsync(Ajuna.ServiceLayer.Storage.IStorageDataProvider dataProvider)
        {
            await FundsTypedStorage.InitializeAsync("Crowdloan", "Funds");
            await NewRaiseTypedStorage.InitializeAsync("Crowdloan", "NewRaise");
            await EndingsCountTypedStorage.InitializeAsync("Crowdloan", "EndingsCount");
            await NextFundIndexTypedStorage.InitializeAsync("Crowdloan", "NextFundIndex");
        }
        
        /// <summary>
        /// Implements any storage change for Crowdloan.Funds
        /// </summary>
        [StorageChange("Crowdloan", "Funds")]
        public void OnUpdateFunds(string key, string data)
        {
            FundsTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> Funds
        ///  Info on all of the funds.
        /// </summary>
        public Blazscan.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.FundInfo GetFunds(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (FundsTypedStorage.Dictionary.TryGetValue(key, out Blazscan.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.FundInfo result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Implements any storage change for Crowdloan.NewRaise
        /// </summary>
        [StorageChange("Crowdloan", "NewRaise")]
        public void OnUpdateNewRaise(string data)
        {
            NewRaiseTypedStorage.Update(data);
        }
        
        /// <summary>
        /// >> NewRaise
        ///  The funds that have had additional contributions during the last block. This is used
        ///  in order to determine which funds should submit new or updated bids.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id> GetNewRaise()
        {
            return NewRaiseTypedStorage.Get();
        }
        
        /// <summary>
        /// Implements any storage change for Crowdloan.EndingsCount
        /// </summary>
        [StorageChange("Crowdloan", "EndingsCount")]
        public void OnUpdateEndingsCount(string data)
        {
            EndingsCountTypedStorage.Update(data);
        }
        
        /// <summary>
        /// >> EndingsCount
        ///  The number of auctions that have entered into their ending period so far.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 GetEndingsCount()
        {
            return EndingsCountTypedStorage.Get();
        }
        
        /// <summary>
        /// Implements any storage change for Crowdloan.NextFundIndex
        /// </summary>
        [StorageChange("Crowdloan", "NextFundIndex")]
        public void OnUpdateNextFundIndex(string data)
        {
            NextFundIndexTypedStorage.Update(data);
        }
        
        /// <summary>
        /// >> NextFundIndex
        ///  Tracker for the next available fund index
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 GetNextFundIndex()
        {
            return NextFundIndexTypedStorage.Get();
        }
    }
}
