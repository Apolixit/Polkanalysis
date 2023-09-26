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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9340
{
    public sealed class SlotsStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> LeasesParams
        ///  Amounts held on deposit for each (possibly future) leased parachain.
        /// 
        ///  The actual amount locked on its behalf by any account at any time is the maximum of the second values
        ///  of the items in this list whose first value is the account.
        /// 
        ///  The first item in the list is the amount locked for the current Lease Period. Following
        ///  items are for the subsequent lease periods.
        /// 
        ///  The default value (an empty list) implies that the parachain no longer exists (or never
        ///  existed) as far as this pallet is concerned.
        /// 
        ///  If a parachain doesn't exist *yet* but is scheduled to exist in the future, then it
        ///  will be left-padded with one or more `None`s to denote the fact that nothing is held on
        ///  deposit for the non-existent chain currently, but is held at some point in the future.
        /// 
        ///  It is illegal for a `None` value to trail in the list.
        /// </summary>
        public static string LeasesParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Slots", "Leases", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> LeasesDefault
        /// Default value as hex string
        /// </summary>
        public static string LeasesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Leases
        ///  Amounts held on deposit for each (possibly future) leased parachain.
        /// 
        ///  The actual amount locked on its behalf by any account at any time is the maximum of the second values
        ///  of the items in this list whose first value is the account.
        /// 
        ///  The first item in the list is the amount locked for the current Lease Period. Following
        ///  items are for the subsequent lease periods.
        /// 
        ///  The default value (an empty list) implies that the parachain no longer exists (or never
        ///  existed) as far as this pallet is concerned.
        /// 
        ///  If a parachain doesn't exist *yet* but is scheduled to exist in the future, then it
        ///  will be left-padded with one or more `None`s to denote the fact that nothing is held on
        ///  deposit for the non-existent chain currently, but is held at some point in the future.
        /// 
        ///  It is illegal for a `None` value to trail in the list.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>>> Leases(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = LeasesParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>>>(parameters, blockHash, token);
            return result;
        }

        public SlotsStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class SlotsConstants
    {
        /// <summary>
        /// >> LeasePeriod
        ///  The number of blocks over which a single period lasts.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 LeasePeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00751200");
            return result;
        }

        /// <summary>
        /// >> LeaseOffset
        ///  The number of blocks to offset each lease period by.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 LeaseOffset()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00100E00");
            return result;
        }
    }

    public enum SlotsErrors
    {
        /// <summary>
        /// >> ParaNotOnboarding
        /// The parachain ID is not onboarding.
        /// </summary>
        ParaNotOnboarding,
        /// <summary>
        /// >> LeaseError
        /// There was an error with the lease.
        /// </summary>
        LeaseError
    }
}