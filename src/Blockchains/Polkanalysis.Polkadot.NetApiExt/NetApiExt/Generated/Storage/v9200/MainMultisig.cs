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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9200
{
    public sealed class MultisigStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> MultisigsParams
        ///  The set of open multisig operations.
        /// </summary>
        public static string MultisigsParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8> key)
        {
            return RequestGenerator.GetStorage("Multisig", "Multisigs", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat, Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, key.Value);
        }

        /// <summary>
        /// >> MultisigsDefault
        /// Default value as hex string
        /// </summary>
        public static string MultisigsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Multisigs
        ///  The set of open multisig operations.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_multisig.Multisig> Multisigs(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8> key, CancellationToken token)
        {
            string parameters = MultisigsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_multisig.Multisig>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CallsParams
        /// </summary>
        public static string CallsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8 key)
        {
            return RequestGenerator.GetStorage("Multisig", "Calls", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> CallsDefault
        /// Default value as hex string
        /// </summary>
        public static string CallsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Calls
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.frame_support.traits.misc.WrapperKeepOpaque, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>> Calls(Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8 key, CancellationToken token)
        {
            string parameters = CallsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.frame_support.traits.misc.WrapperKeepOpaque, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(parameters, blockHash, token);
            return result;
        }

        public MultisigStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class MultisigConstants
    {
        /// <summary>
        /// >> DepositBase
        ///  The base amount of currency needed to reserve for creating a multisig execution or to
        ///  store a dispatch call for later.
        /// 
        ///  This is held for an additional storage item whose value size is
        ///  `4 + sizeof((BlockNumber, Balance, AccountId))` bytes and whose key size is
        ///  `32 + sizeof(AccountId)` bytes.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 DepositBase()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x008C61C52E0000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> DepositFactor
        ///  The amount of currency needed per unit threshold when creating a multisig execution.
        /// 
        ///  This is held for adding 32 bytes more into a pre-existing storage value.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 DepositFactor()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00D01213000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> MaxSignatories
        ///  The maximum amount of signatories allowed in the multisig.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U16 MaxSignatories()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U16();
            result.Create("0x6400");
            return result;
        }
    }

    public enum MultisigErrors
    {
        /// <summary>
        /// >> MinimumThreshold
        /// Threshold must be 2 or greater.
        /// </summary>
        MinimumThreshold,
        /// <summary>
        /// >> AlreadyApproved
        /// Call is already approved by this signatory.
        /// </summary>
        AlreadyApproved,
        /// <summary>
        /// >> NoApprovalsNeeded
        /// Call doesn't need any (more) approvals.
        /// </summary>
        NoApprovalsNeeded,
        /// <summary>
        /// >> TooFewSignatories
        /// There are too few signatories in the list.
        /// </summary>
        TooFewSignatories,
        /// <summary>
        /// >> TooManySignatories
        /// There are too many signatories in the list.
        /// </summary>
        TooManySignatories,
        /// <summary>
        /// >> SignatoriesOutOfOrder
        /// The signatories were provided out of order; they should be ordered.
        /// </summary>
        SignatoriesOutOfOrder,
        /// <summary>
        /// >> SenderInSignatories
        /// The sender was contained in the other signatories; it shouldn't be.
        /// </summary>
        SenderInSignatories,
        /// <summary>
        /// >> NotFound
        /// Multisig operation not found when attempting to cancel.
        /// </summary>
        NotFound,
        /// <summary>
        /// >> NotOwner
        /// Only the account that originally created the multisig is able to cancel it.
        /// </summary>
        NotOwner,
        /// <summary>
        /// >> NoTimepoint
        /// No timepoint was given, yet the multisig operation is already underway.
        /// </summary>
        NoTimepoint,
        /// <summary>
        /// >> WrongTimepoint
        /// A different timepoint was given to the multisig operation that is underway.
        /// </summary>
        WrongTimepoint,
        /// <summary>
        /// >> UnexpectedTimepoint
        /// A timepoint was given, yet no multisig operation is underway.
        /// </summary>
        UnexpectedTimepoint,
        /// <summary>
        /// >> MaxWeightTooLow
        /// The maximum weight information provided was too low.
        /// </summary>
        MaxWeightTooLow,
        /// <summary>
        /// >> AlreadyStored
        /// The data to be stored is already stored.
        /// </summary>
        AlreadyStored
    }
}