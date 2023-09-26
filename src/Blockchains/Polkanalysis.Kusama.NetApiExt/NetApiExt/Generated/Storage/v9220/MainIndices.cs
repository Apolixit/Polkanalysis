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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9220
{
    public sealed class IndicesStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> AccountsParams
        ///  The lookup from index to account.
        /// </summary>
        public static string AccountsParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Indices", "Accounts", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> AccountsDefault
        /// Default value as hex string
        /// </summary>
        public static string AccountsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Accounts
        ///  The lookup from index to account.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.Bool>> Accounts(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = AccountsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.Bool>>(parameters, blockHash, token);
            return result;
        }

        public IndicesStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class IndicesConstants
    {
        /// <summary>
        /// >> Deposit
        ///  The deposit needed for reserving an index.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Deposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x34A1AEC6000000000000000000000000");
            return result;
        }
    }

    public enum IndicesErrors
    {
        /// <summary>
        /// >> NotAssigned
        /// The index was not already assigned.
        /// </summary>
        NotAssigned,
        /// <summary>
        /// >> NotOwner
        /// The index is assigned to another account.
        /// </summary>
        NotOwner,
        /// <summary>
        /// >> InUse
        /// The index was not available.
        /// </summary>
        InUse,
        /// <summary>
        /// >> NotTransfer
        /// The source and destination accounts are identical.
        /// </summary>
        NotTransfer,
        /// <summary>
        /// >> Permanent
        /// The index is permanent and may not be freed/changed.
        /// </summary>
        Permanent
    }
}