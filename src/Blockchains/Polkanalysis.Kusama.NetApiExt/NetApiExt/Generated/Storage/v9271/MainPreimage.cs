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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9271
{
    public sealed class PreimageStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> StatusForParams
        ///  The request status of a given hash.
        /// </summary>
        public static string StatusForParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Preimage", "StatusFor", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> StatusForDefault
        /// Default value as hex string
        /// </summary>
        public static string StatusForDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> StatusFor
        ///  The request status of a given hash.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.pallet_preimage.EnumRequestStatus> StatusFor(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = StatusForParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.pallet_preimage.EnumRequestStatus>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PreimageForParams
        ///  The preimages stored by this pallet.
        /// </summary>
        public static string PreimageForParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Preimage", "PreimageFor", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> PreimageForDefault
        /// Default value as hex string
        /// </summary>
        public static string PreimageForDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> PreimageFor
        ///  The preimages stored by this pallet.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> PreimageFor(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = PreimageForParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(parameters, blockHash, token);
            return result;
        }

        public PreimageStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class PreimageConstants
    {
    }

    public enum PreimageErrors
    {
        /// <summary>
        /// >> TooLarge
        /// Preimage is too large to store on-chain.
        /// </summary>
        TooLarge,
        /// <summary>
        /// >> AlreadyNoted
        /// Preimage has already been noted on-chain.
        /// </summary>
        AlreadyNoted,
        /// <summary>
        /// >> NotAuthorized
        /// The user is not authorized to perform this action.
        /// </summary>
        NotAuthorized,
        /// <summary>
        /// >> NotNoted
        /// The preimage cannot be removed since it has not yet been noted.
        /// </summary>
        NotNoted,
        /// <summary>
        /// >> Requested
        /// A preimage may not be removed when there are outstanding requests.
        /// </summary>
        Requested,
        /// <summary>
        /// >> NotRequested
        /// The preimage request cannot be removed since no outstanding requests exist.
        /// </summary>
        NotRequested
    }
}