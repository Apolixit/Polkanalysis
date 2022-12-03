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
    /// ITipsStorage interface definition.
    /// </summary>
    public interface ITipsStorage : IStorage
    {
        
        /// <summary>
        /// >> Tips
        ///  TipsMap that are not yet completed. Keyed by the hash of `(reason, who)` from the value.
        ///  This has the insecure enumerable hash function since the key itself is already
        ///  guaranteed to be a secure hash.
        /// </summary>
        Blazscan.NetApiExt.Generated.Model.pallet_tips.OpenTip GetTips(string key);
        
        /// <summary>
        /// >> Reasons
        ///  Simple preimage lookup from the reason's hash to the original data. Again, has an
        ///  insecure enumerable hash since the key is guaranteed to be the result of a secure hash.
        /// </summary>
        Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> GetReasons(string key);
    }
    
    /// <summary>
    /// TipsStorage class definition.
    /// </summary>
    public sealed class TipsStorage : ITipsStorage
    {
        
        /// <summary>
        /// _tipsTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<Blazscan.NetApiExt.Generated.Model.pallet_tips.OpenTip> _tipsTypedStorage;
        
        /// <summary>
        /// _reasonsTypedStorage typed storage field
        /// </summary>
        private TypedMapStorage<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> _reasonsTypedStorage;
        
        /// <summary>
        /// TipsStorage constructor.
        /// </summary>
        public TipsStorage(IStorageDataProvider storageDataProvider, List<IStorageChangeDelegate> storageChangeDelegates)
        {
            this.TipsTypedStorage = new TypedMapStorage<Blazscan.NetApiExt.Generated.Model.pallet_tips.OpenTip>("Tips.Tips", storageDataProvider, storageChangeDelegates);
            this.ReasonsTypedStorage = new TypedMapStorage<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>("Tips.Reasons", storageDataProvider, storageChangeDelegates);
        }
        
        /// <summary>
        /// _tipsTypedStorage property
        /// </summary>
        public TypedMapStorage<Blazscan.NetApiExt.Generated.Model.pallet_tips.OpenTip> TipsTypedStorage
        {
            get
            {
                return _tipsTypedStorage;
            }
            set
            {
                _tipsTypedStorage = value;
            }
        }
        
        /// <summary>
        /// _reasonsTypedStorage property
        /// </summary>
        public TypedMapStorage<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> ReasonsTypedStorage
        {
            get
            {
                return _reasonsTypedStorage;
            }
            set
            {
                _reasonsTypedStorage = value;
            }
        }
        
        /// <summary>
        /// Connects to all storages and initializes the change subscription handling.
        /// </summary>
        public async Task InitializeAsync(Ajuna.ServiceLayer.Storage.IStorageDataProvider dataProvider)
        {
            await TipsTypedStorage.InitializeAsync("Tips", "Tips");
            await ReasonsTypedStorage.InitializeAsync("Tips", "Reasons");
        }
        
        /// <summary>
        /// Implements any storage change for Tips.Tips
        /// </summary>
        [StorageChange("Tips", "Tips")]
        public void OnUpdateTips(string key, string data)
        {
            TipsTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> Tips
        ///  TipsMap that are not yet completed. Keyed by the hash of `(reason, who)` from the value.
        ///  This has the insecure enumerable hash function since the key itself is already
        ///  guaranteed to be a secure hash.
        /// </summary>
        public Blazscan.NetApiExt.Generated.Model.pallet_tips.OpenTip GetTips(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (TipsTypedStorage.Dictionary.TryGetValue(key, out Blazscan.NetApiExt.Generated.Model.pallet_tips.OpenTip result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Implements any storage change for Tips.Reasons
        /// </summary>
        [StorageChange("Tips", "Reasons")]
        public void OnUpdateReasons(string key, string data)
        {
            ReasonsTypedStorage.Update(key, data);
        }
        
        /// <summary>
        /// >> Reasons
        ///  Simple preimage lookup from the reason's hash to the original data. Again, has an
        ///  insecure enumerable hash since the key is guaranteed to be the result of a secure hash.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> GetReasons(string key)
        {
            if ((key == null))
            {
                return null;
            }
            if (ReasonsTypedStorage.Dictionary.TryGetValue(key, out Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> result))
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
