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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9350
{
    public sealed class ParaSessionInfoStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> AssignmentKeysUnsafeParams
        ///  Assignment keys for the current session.
        ///  Note that this API is private due to it being prone to 'off-by-one' at session boundaries.
        ///  When in doubt, use `Sessions` API instead.
        /// </summary>
        public static string AssignmentKeysUnsafeParams()
        {
            return RequestGenerator.GetStorage("ParaSessionInfo", "AssignmentKeysUnsafe", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> AssignmentKeysUnsafeDefault
        /// Default value as hex string
        /// </summary>
        public static string AssignmentKeysUnsafeDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> AssignmentKeysUnsafe
        ///  Assignment keys for the current session.
        ///  Note that this API is private due to it being prone to 'off-by-one' at session boundaries.
        ///  When in doubt, use `Sessions` API instead.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.polkadot_primitives.v2.assignment_app.Public>> AssignmentKeysUnsafe(CancellationToken token)
        {
            string parameters = AssignmentKeysUnsafeParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.polkadot_primitives.v2.assignment_app.Public>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> EarliestStoredSessionParams
        ///  The earliest session for which previous session info is stored.
        /// </summary>
        public static string EarliestStoredSessionParams()
        {
            return RequestGenerator.GetStorage("ParaSessionInfo", "EarliestStoredSession", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> EarliestStoredSessionDefault
        /// Default value as hex string
        /// </summary>
        public static string EarliestStoredSessionDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> EarliestStoredSession
        ///  The earliest session for which previous session info is stored.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> EarliestStoredSession(CancellationToken token)
        {
            string parameters = EarliestStoredSessionParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SessionsParams
        ///  Session information in a rolling window.
        ///  Should have an entry in range `EarliestStoredSession..=CurrentSessionIndex`.
        ///  Does not have any entries before the session index in the first session change notification.
        /// </summary>
        public static string SessionsParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("ParaSessionInfo", "Sessions", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> SessionsDefault
        /// Default value as hex string
        /// </summary>
        public static string SessionsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Sessions
        ///  Session information in a rolling window.
        ///  Should have an entry in range `EarliestStoredSession..=CurrentSessionIndex`.
        ///  Does not have any entries before the session index in the first session change notification.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.polkadot_primitives.v2.SessionInfo> Sessions(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = SessionsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.polkadot_primitives.v2.SessionInfo>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> AccountKeysParams
        ///  The validator account keys of the validators actively participating in parachain consensus.
        /// </summary>
        public static string AccountKeysParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("ParaSessionInfo", "AccountKeys", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> AccountKeysDefault
        /// Default value as hex string
        /// </summary>
        public static string AccountKeysDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> AccountKeys
        ///  The validator account keys of the validators actively participating in parachain consensus.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.sp_core.crypto.AccountId32>> AccountKeys(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = AccountKeysParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.sp_core.crypto.AccountId32>>(parameters, blockHash, token);
            return result;
        }

        public ParaSessionInfoStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class ParaSessionInfoConstants
    {
    }
}