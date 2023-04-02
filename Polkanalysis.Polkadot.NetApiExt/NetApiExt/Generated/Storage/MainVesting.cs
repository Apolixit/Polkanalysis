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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage
{
    
    
    public sealed class VestingStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public VestingStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Vesting", "Vesting"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT18)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Vesting", "StorageVersion"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_vesting.EnumReleases)));
        }
        
        /// <summary>
        /// >> VestingParams
        ///  Information regarding the vesting of a given account.
        /// </summary>
        public static string VestingParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Vesting", "Vesting", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> VestingDefault
        /// Default value as hex string
        /// </summary>
        public static string VestingDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Vesting
        ///  Information regarding the vesting of a given account.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT18> Vesting(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = VestingStorage.VestingParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT18>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> StorageVersionParams
        ///  Storage version of the pallet.
        /// 
        ///  New networks start with latest version, as determined by the genesis build.
        /// </summary>
        public static string StorageVersionParams()
        {
            return RequestGenerator.GetStorage("Vesting", "StorageVersion", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> StorageVersionDefault
        /// Default value as hex string
        /// </summary>
        public static string StorageVersionDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> StorageVersion
        ///  Storage version of the pallet.
        /// 
        ///  New networks start with latest version, as determined by the genesis build.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_vesting.EnumReleases> StorageVersion(CancellationToken token)
        {
            string parameters = VestingStorage.StorageVersionParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_vesting.EnumReleases>(parameters, token);
            return result;
        }
    }
    
    public sealed class VestingCalls
    {
        
        /// <summary>
        /// >> vest
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Vest()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(25, "Vesting", 0, "vest", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> vest_other
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method VestOther(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress target)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(target.Encode());
            return new Method(25, "Vesting", 1, "vest_other", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> vested_transfer
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method VestedTransfer(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress target, Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_vesting.vesting_info.VestingInfo schedule)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(target.Encode());
            byteArray.AddRange(schedule.Encode());
            return new Method(25, "Vesting", 2, "vested_transfer", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_vested_transfer
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ForceVestedTransfer(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress source, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress target, Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_vesting.vesting_info.VestingInfo schedule)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(source.Encode());
            byteArray.AddRange(target.Encode());
            byteArray.AddRange(schedule.Encode());
            return new Method(25, "Vesting", 3, "force_vested_transfer", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> merge_schedules
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method MergeSchedules(Substrate.NetApi.Model.Types.Primitive.U32 schedule1_index, Substrate.NetApi.Model.Types.Primitive.U32 schedule2_index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(schedule1_index.Encode());
            byteArray.AddRange(schedule2_index.Encode());
            return new Method(25, "Vesting", 4, "merge_schedules", byteArray.ToArray());
        }
    }
    
    public sealed class VestingConstants
    {
        
        /// <summary>
        /// >> MinVestedTransfer
        ///  The minimum amount transferred to call `vested_transfer`.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 MinVestedTransfer()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00E40B54020000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxVestingSchedules
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxVestingSchedules()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x1C000000");
            return result;
        }
    }
    
    public enum VestingErrors
    {
        
        /// <summary>
        /// >> NotVesting
        /// The account given is not vesting.
        /// </summary>
        NotVesting,
        
        /// <summary>
        /// >> AtMaxVestingSchedules
        /// The account already has `MaxVestingSchedules` count of schedules and thus
        /// cannot add another one. Consider merging existing schedules in order to add another.
        /// </summary>
        AtMaxVestingSchedules,
        
        /// <summary>
        /// >> AmountLow
        /// Amount being transferred is too low to create a vesting schedule.
        /// </summary>
        AmountLow,
        
        /// <summary>
        /// >> ScheduleIndexOutOfBounds
        /// An index was out of bounds of the vesting schedules.
        /// </summary>
        ScheduleIndexOutOfBounds,
        
        /// <summary>
        /// >> InvalidScheduleParams
        /// Failed to create a new schedule because some parameter was invalid.
        /// </summary>
        InvalidScheduleParams,
    }
}
