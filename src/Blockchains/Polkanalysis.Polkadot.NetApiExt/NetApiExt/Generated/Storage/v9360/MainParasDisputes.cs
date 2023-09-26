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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9360
{
    public sealed class ParasDisputesStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> LastPrunedSessionParams
        ///  The last pruned session, if any. All data stored by this module
        ///  references sessions.
        /// </summary>
        public static string LastPrunedSessionParams()
        {
            return RequestGenerator.GetStorage("ParasDisputes", "LastPrunedSession", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> LastPrunedSessionDefault
        /// Default value as hex string
        /// </summary>
        public static string LastPrunedSessionDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> LastPrunedSession
        ///  The last pruned session, if any. All data stored by this module
        ///  references sessions.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> LastPrunedSession(CancellationToken token)
        {
            string parameters = LastPrunedSessionParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> DisputesParams
        ///  All ongoing or concluded disputes for the last several sessions.
        /// </summary>
        public static string DisputesParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.polkadot_core_primitives.CandidateHash> key)
        {
            return RequestGenerator.GetStorage("ParasDisputes", "Disputes", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat, Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, key.Value);
        }

        /// <summary>
        /// >> DisputesDefault
        /// Default value as hex string
        /// </summary>
        public static string DisputesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Disputes
        ///  All ongoing or concluded disputes for the last several sessions.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.polkadot_primitives.v2.DisputeState> Disputes(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.polkadot_core_primitives.CandidateHash> key, CancellationToken token)
        {
            string parameters = DisputesParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.polkadot_primitives.v2.DisputeState>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> IncludedParams
        ///  All included blocks on the chain, as well as the block number in this chain that
        ///  should be reverted back to if the candidate is disputed and determined to be invalid.
        /// </summary>
        public static string IncludedParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.polkadot_core_primitives.CandidateHash> key)
        {
            return RequestGenerator.GetStorage("ParasDisputes", "Included", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat, Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, key.Value);
        }

        /// <summary>
        /// >> IncludedDefault
        /// Default value as hex string
        /// </summary>
        public static string IncludedDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Included
        ///  All included blocks on the chain, as well as the block number in this chain that
        ///  should be reverted back to if the candidate is disputed and determined to be invalid.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> Included(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.polkadot_core_primitives.CandidateHash> key, CancellationToken token)
        {
            string parameters = IncludedParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SpamSlotsParams
        ///  Maps session indices to a vector indicating the number of potentially-spam disputes
        ///  each validator is participating in. Potentially-spam disputes are remote disputes which have
        ///  fewer than `byzantine_threshold + 1` validators.
        /// 
        ///  The i'th entry of the vector corresponds to the i'th validator in the session.
        /// </summary>
        public static string SpamSlotsParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("ParasDisputes", "SpamSlots", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> SpamSlotsDefault
        /// Default value as hex string
        /// </summary>
        public static string SpamSlotsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> SpamSlots
        ///  Maps session indices to a vector indicating the number of potentially-spam disputes
        ///  each validator is participating in. Potentially-spam disputes are remote disputes which have
        ///  fewer than `byzantine_threshold + 1` validators.
        /// 
        ///  The i'th entry of the vector corresponds to the i'th validator in the session.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>> SpamSlots(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = SpamSlotsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> FrozenParams
        ///  Whether the chain is frozen. Starts as `None`. When this is `Some`,
        ///  the chain will not accept any new parachain blocks for backing or inclusion,
        ///  and its value indicates the last valid block number in the chain.
        ///  It can only be set back to `None` by governance intervention.
        /// </summary>
        public static string FrozenParams()
        {
            return RequestGenerator.GetStorage("ParasDisputes", "Frozen", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> FrozenDefault
        /// Default value as hex string
        /// </summary>
        public static string FrozenDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Frozen
        ///  Whether the chain is frozen. Starts as `None`. When this is `Some`,
        ///  the chain will not accept any new parachain blocks for backing or inclusion,
        ///  and its value indicates the last valid block number in the chain.
        ///  It can only be set back to `None` by governance intervention.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>> Frozen(CancellationToken token)
        {
            string parameters = FrozenParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockHash, token);
            return result;
        }

        public ParasDisputesStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class ParasDisputesConstants
    {
    }

    public enum ParasDisputesErrors
    {
        /// <summary>
        /// >> DuplicateDisputeStatementSets
        /// Duplicate dispute statement sets provided.
        /// </summary>
        DuplicateDisputeStatementSets,
        /// <summary>
        /// >> AncientDisputeStatement
        /// Ancient dispute statement provided.
        /// </summary>
        AncientDisputeStatement,
        /// <summary>
        /// >> ValidatorIndexOutOfBounds
        /// Validator index on statement is out of bounds for session.
        /// </summary>
        ValidatorIndexOutOfBounds,
        /// <summary>
        /// >> InvalidSignature
        /// Invalid signature on statement.
        /// </summary>
        InvalidSignature,
        /// <summary>
        /// >> DuplicateStatement
        /// Validator vote submitted more than once to dispute.
        /// </summary>
        DuplicateStatement,
        /// <summary>
        /// >> PotentialSpam
        /// Too many spam slots used by some specific validator.
        /// </summary>
        PotentialSpam,
        /// <summary>
        /// >> SingleSidedDispute
        /// A dispute where there are only votes on one side.
        /// </summary>
        SingleSidedDispute
    }
}