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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9180
{
    public sealed class AuthorshipStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> UnclesParams
        ///  Uncles
        /// </summary>
        public static string UnclesParams()
        {
            return RequestGenerator.GetStorage("Authorship", "Uncles", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> UnclesDefault
        /// Default value as hex string
        /// </summary>
        public static string UnclesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Uncles
        ///  Uncles
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.pallet_authorship.EnumUncleEntryItem>> Uncles(CancellationToken token)
        {
            string parameters = UnclesParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.pallet_authorship.EnumUncleEntryItem>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> AuthorParams
        ///  Author of current block.
        /// </summary>
        public static string AuthorParams()
        {
            return RequestGenerator.GetStorage("Authorship", "Author", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> AuthorDefault
        /// Default value as hex string
        /// </summary>
        public static string AuthorDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Author
        ///  Author of current block.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32> Author(CancellationToken token)
        {
            string parameters = AuthorParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> DidSetUnclesParams
        ///  Whether uncles were already set in this block.
        /// </summary>
        public static string DidSetUnclesParams()
        {
            return RequestGenerator.GetStorage("Authorship", "DidSetUncles", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> DidSetUnclesDefault
        /// Default value as hex string
        /// </summary>
        public static string DidSetUnclesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> DidSetUncles
        ///  Whether uncles were already set in this block.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> DidSetUncles(CancellationToken token)
        {
            string parameters = DidSetUnclesParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockHash, token);
            return result;
        }

        public AuthorshipStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class AuthorshipConstants
    {
        /// <summary>
        /// >> UncleGenerations
        ///  The number of blocks back we should accept uncles.
        ///  This means that we will deal with uncle-parents that are
        ///  `UncleGenerations + 1` before `now`.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 UncleGenerations()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00000000");
            return result;
        }
    }

    public enum AuthorshipErrors
    {
        /// <summary>
        /// >> InvalidUncleParent
        /// The uncle parent not in the chain.
        /// </summary>
        InvalidUncleParent,
        /// <summary>
        /// >> UnclesAlreadySet
        /// Uncles already set in the block.
        /// </summary>
        UnclesAlreadySet,
        /// <summary>
        /// >> TooManyUncles
        /// Too many uncles.
        /// </summary>
        TooManyUncles,
        /// <summary>
        /// >> GenesisUncle
        /// The uncle is genesis.
        /// </summary>
        GenesisUncle,
        /// <summary>
        /// >> TooHighUncle
        /// The uncle is too high in chain.
        /// </summary>
        TooHighUncle,
        /// <summary>
        /// >> UncleAlreadyIncluded
        /// The uncle is already included.
        /// </summary>
        UncleAlreadyIncluded,
        /// <summary>
        /// >> OldUncle
        /// The uncle isn't recent enough to be included.
        /// </summary>
        OldUncle
    }
}