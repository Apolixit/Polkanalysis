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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage
{
    
    
    public sealed class MultisigStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public MultisigStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Multisig", "Multisigs"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8>), typeof(Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_multisig.Multisig)));
        }
        
        /// <summary>
        /// >> MultisigsParams
        ///  The set of open multisig operations.
        /// </summary>
        public static string MultisigsParams(Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8> key)
        {
            return RequestGenerator.GetStorage("Multisig", "Multisigs", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, key.Value);
        }
        
        /// <summary>
        /// >> Multisigs
        ///  The set of open multisig operations.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_multisig.Multisig> Multisigs(Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8> key, CancellationToken token)
        {
            string parameters = MultisigStorage.MultisigsParams(key);
            return await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_multisig.Multisig>(parameters, token);
        }
    }
    
    public sealed class MultisigCalls
    {
        
        /// <summary>
        /// >> as_multi_threshold_1
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method AsMultiThreshold1(Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> other_signatories, Polkanalysis.Kusama.NetApiExt.Generated.Model.kusama_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(other_signatories.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(31, "Multisig", 0, "as_multi_threshold_1", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> as_multi
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method AsMulti(Ajuna.NetApi.Model.Types.Primitive.U16 threshold, Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> other_signatories, Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_multisig.Timepoint> maybe_timepoint, Polkanalysis.Kusama.NetApiExt.Generated.Model.kusama_runtime.EnumRuntimeCall call, Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight max_weight)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(threshold.Encode());
            byteArray.AddRange(other_signatories.Encode());
            byteArray.AddRange(maybe_timepoint.Encode());
            byteArray.AddRange(call.Encode());
            byteArray.AddRange(max_weight.Encode());
            return new Method(31, "Multisig", 1, "as_multi", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> approve_as_multi
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ApproveAsMulti(Ajuna.NetApi.Model.Types.Primitive.U16 threshold, Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> other_signatories, Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_multisig.Timepoint> maybe_timepoint, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8 call_hash, Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight max_weight)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(threshold.Encode());
            byteArray.AddRange(other_signatories.Encode());
            byteArray.AddRange(maybe_timepoint.Encode());
            byteArray.AddRange(call_hash.Encode());
            byteArray.AddRange(max_weight.Encode());
            return new Method(31, "Multisig", 2, "approve_as_multi", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> cancel_as_multi
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method CancelAsMulti(Ajuna.NetApi.Model.Types.Primitive.U16 threshold, Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> other_signatories, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_multisig.Timepoint timepoint, Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8 call_hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(threshold.Encode());
            byteArray.AddRange(other_signatories.Encode());
            byteArray.AddRange(timepoint.Encode());
            byteArray.AddRange(call_hash.Encode());
            return new Method(31, "Multisig", 3, "cancel_as_multi", byteArray.ToArray());
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
        AlreadyStored,
    }
}
