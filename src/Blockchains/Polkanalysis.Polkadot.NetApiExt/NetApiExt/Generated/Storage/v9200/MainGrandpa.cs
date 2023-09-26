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
    public sealed class GrandpaStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> StateParams
        ///  State of the current authority set.
        /// </summary>
        public static string StateParams()
        {
            return RequestGenerator.GetStorage("Grandpa", "State", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> StateDefault
        /// Default value as hex string
        /// </summary>
        public static string StateDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> State
        ///  State of the current authority set.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_grandpa.EnumStoredState> State(CancellationToken token)
        {
            string parameters = StateParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_grandpa.EnumStoredState>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PendingChangeParams
        ///  Pending change: (signaled at, scheduled change).
        /// </summary>
        public static string PendingChangeParams()
        {
            return RequestGenerator.GetStorage("Grandpa", "PendingChange", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> PendingChangeDefault
        /// Default value as hex string
        /// </summary>
        public static string PendingChangeDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> PendingChange
        ///  Pending change: (signaled at, scheduled change).
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_grandpa.StoredPendingChange> PendingChange(CancellationToken token)
        {
            string parameters = PendingChangeParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_grandpa.StoredPendingChange>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> NextForcedParams
        ///  next block number where we can force a change.
        /// </summary>
        public static string NextForcedParams()
        {
            return RequestGenerator.GetStorage("Grandpa", "NextForced", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> NextForcedDefault
        /// Default value as hex string
        /// </summary>
        public static string NextForcedDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> NextForced
        ///  next block number where we can force a change.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> NextForced(CancellationToken token)
        {
            string parameters = NextForcedParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> StalledParams
        ///  `true` if we are currently stalled.
        /// </summary>
        public static string StalledParams()
        {
            return RequestGenerator.GetStorage("Grandpa", "Stalled", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> StalledDefault
        /// Default value as hex string
        /// </summary>
        public static string StalledDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Stalled
        ///  `true` if we are currently stalled.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> Stalled(CancellationToken token)
        {
            string parameters = StalledParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CurrentSetIdParams
        ///  The number of changes (both in terms of keys and underlying economic responsibilities)
        ///  in the "set" of Grandpa validators from genesis.
        /// </summary>
        public static string CurrentSetIdParams()
        {
            return RequestGenerator.GetStorage("Grandpa", "CurrentSetId", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CurrentSetIdDefault
        /// Default value as hex string
        /// </summary>
        public static string CurrentSetIdDefault()
        {
            return "0x0000000000000000";
        }

        /// <summary>
        /// >> CurrentSetId
        ///  The number of changes (both in terms of keys and underlying economic responsibilities)
        ///  in the "set" of Grandpa validators from genesis.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U64> CurrentSetId(CancellationToken token)
        {
            string parameters = CurrentSetIdParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U64>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SetIdSessionParams
        ///  A mapping from grandpa set ID to the index of the *most recent* session for which its
        ///  members were responsible.
        /// 
        ///  TWOX-NOTE: `SetId` is not under user control.
        /// </summary>
        public static string SetIdSessionParams(Substrate.NetApi.Model.Types.Primitive.U64 key)
        {
            return RequestGenerator.GetStorage("Grandpa", "SetIdSession", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> SetIdSessionDefault
        /// Default value as hex string
        /// </summary>
        public static string SetIdSessionDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> SetIdSession
        ///  A mapping from grandpa set ID to the index of the *most recent* session for which its
        ///  members were responsible.
        /// 
        ///  TWOX-NOTE: `SetId` is not under user control.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> SetIdSession(Substrate.NetApi.Model.Types.Primitive.U64 key, CancellationToken token)
        {
            string parameters = SetIdSessionParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        public GrandpaStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class GrandpaConstants
    {
        /// <summary>
        /// >> MaxAuthorities
        ///  Max Authorities in use
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxAuthorities()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xA0860100");
            return result;
        }
    }

    public enum GrandpaErrors
    {
        /// <summary>
        /// >> PauseFailed
        /// Attempt to signal GRANDPA pause when the authority set isn't live
        /// (either paused or already pending pause).
        /// </summary>
        PauseFailed,
        /// <summary>
        /// >> ResumeFailed
        /// Attempt to signal GRANDPA resume when the authority set isn't paused
        /// (either live or already pending resume).
        /// </summary>
        ResumeFailed,
        /// <summary>
        /// >> ChangePending
        /// Attempt to signal GRANDPA change with one already pending.
        /// </summary>
        ChangePending,
        /// <summary>
        /// >> TooSoon
        /// Cannot signal forced change so soon after last.
        /// </summary>
        TooSoon,
        /// <summary>
        /// >> InvalidKeyOwnershipProof
        /// A key ownership proof provided as part of an equivocation report is invalid.
        /// </summary>
        InvalidKeyOwnershipProof,
        /// <summary>
        /// >> InvalidEquivocationProof
        /// An equivocation proof provided as part of an equivocation report is invalid.
        /// </summary>
        InvalidEquivocationProof,
        /// <summary>
        /// >> DuplicateOffenceReport
        /// A given equivocation report is valid but already previously reported.
        /// </summary>
        DuplicateOffenceReport
    }
}