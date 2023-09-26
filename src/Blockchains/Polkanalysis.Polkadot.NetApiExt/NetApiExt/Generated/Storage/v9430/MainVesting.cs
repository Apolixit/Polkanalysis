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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9430
{
    public sealed class VestingStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> VestingParams
        ///  Information regarding the vesting of a given account.
        /// </summary>
        public static string VestingParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Vesting", "Vesting", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
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
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_vesting.vesting_info.VestingInfo>> Vesting(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = VestingParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_vesting.vesting_info.VestingInfo>>(parameters, blockHash, token);
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
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_vesting.EnumReleases> StorageVersion(CancellationToken token)
        {
            string parameters = StorageVersionParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_vesting.EnumReleases>(parameters, blockHash, token);
            return result;
        }

        public VestingStorage(SubstrateClientExt client)
        {
            _client = client;
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
        InvalidScheduleParams
    }
}