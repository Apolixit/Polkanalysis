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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9130
{
    public sealed class InitializerStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> HasInitializedParams
        ///  Whether the parachains modules have been initialized within this block.
        /// 
        ///  Semantically a `bool`, but this guarantees it should never hit the trie,
        ///  as this is cleared in `on_finalize` and Frame optimizes `None` values to be empty values.
        /// 
        ///  As a `bool`, `set(false)` and `remove()` both lead to the next `get()` being false, but one of
        ///  them writes to the trie and one does not. This confusion makes `Option<()>` more suitable for
        ///  the semantics of this variable.
        /// </summary>
        public static string HasInitializedParams()
        {
            return RequestGenerator.GetStorage("Initializer", "HasInitialized", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> HasInitializedDefault
        /// Default value as hex string
        /// </summary>
        public static string HasInitializedDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> HasInitialized
        ///  Whether the parachains modules have been initialized within this block.
        /// 
        ///  Semantically a `bool`, but this guarantees it should never hit the trie,
        ///  as this is cleared in `on_finalize` and Frame optimizes `None` values to be empty values.
        /// 
        ///  As a `bool`, `set(false)` and `remove()` both lead to the next `get()` being false, but one of
        ///  them writes to the trie and one does not. This confusion makes `Option<()>` more suitable for
        ///  the semantics of this variable.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple> HasInitialized(CancellationToken token)
        {
            string parameters = HasInitializedParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> BufferedSessionChangesParams
        ///  Buffered session changes along with the block number at which they should be applied.
        /// 
        ///  Typically this will be empty or one element long. Apart from that this item never hits
        ///  the storage.
        /// 
        ///  However this is a `Vec` regardless to handle various edge cases that may occur at runtime
        ///  upgrade boundaries or if governance intervenes.
        /// </summary>
        public static string BufferedSessionChangesParams()
        {
            return RequestGenerator.GetStorage("Initializer", "BufferedSessionChanges", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> BufferedSessionChangesDefault
        /// Default value as hex string
        /// </summary>
        public static string BufferedSessionChangesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> BufferedSessionChanges
        ///  Buffered session changes along with the block number at which they should be applied.
        /// 
        ///  Typically this will be empty or one element long. Apart from that this item never hits
        ///  the storage.
        /// 
        ///  However this is a `Vec` regardless to handle various edge cases that may occur at runtime
        ///  upgrade boundaries or if governance intervenes.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.polkadot_runtime_parachains.initializer.BufferedSessionChange>> BufferedSessionChanges(CancellationToken token)
        {
            string parameters = BufferedSessionChangesParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.polkadot_runtime_parachains.initializer.BufferedSessionChange>>(parameters, blockHash, token);
            return result;
        }

        public InitializerStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class InitializerConstants
    {
    }
}