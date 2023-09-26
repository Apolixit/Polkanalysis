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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9420
{
    public sealed class ClaimsStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> ClaimsParams
        /// </summary>
        public static string ClaimsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EthereumAddress key)
        {
            return RequestGenerator.GetStorage("Claims", "Claims", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ClaimsDefault
        /// Default value as hex string
        /// </summary>
        public static string ClaimsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Claims
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U128> Claims(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EthereumAddress key, CancellationToken token)
        {
            string parameters = ClaimsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U128>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> TotalParams
        /// </summary>
        public static string TotalParams()
        {
            return RequestGenerator.GetStorage("Claims", "Total", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> TotalDefault
        /// Default value as hex string
        /// </summary>
        public static string TotalDefault()
        {
            return "0x00000000000000000000000000000000";
        }

        /// <summary>
        /// >> Total
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U128> Total(CancellationToken token)
        {
            string parameters = TotalParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U128>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> VestingParams
        ///  Vesting schedule for a claim.
        ///  First balance is the total amount that should be held for vesting.
        ///  Second balance is how much should be unlocked per block.
        ///  The block number is when the vesting should start.
        /// </summary>
        public static string VestingParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EthereumAddress key)
        {
            return RequestGenerator.GetStorage("Claims", "Vesting", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> VestingDefault
        /// Default value as hex string
        /// </summary>
        public static string VestingDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Vesting
        ///  Vesting schedule for a claim.
        ///  First balance is the total amount that should be held for vesting.
        ///  Second balance is how much should be unlocked per block.
        ///  The block number is when the vesting should start.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U32>> Vesting(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EthereumAddress key, CancellationToken token)
        {
            string parameters = VestingParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SigningParams
        ///  The statement kind that must be signed, if any.
        /// </summary>
        public static string SigningParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EthereumAddress key)
        {
            return RequestGenerator.GetStorage("Claims", "Signing", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> SigningDefault
        /// Default value as hex string
        /// </summary>
        public static string SigningDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Signing
        ///  The statement kind that must be signed, if any.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EnumStatementKind> Signing(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EthereumAddress key, CancellationToken token)
        {
            string parameters = SigningParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EnumStatementKind>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PreclaimsParams
        ///  Pre-claimed Ethereum accounts, by the Account ID that they are claimed to.
        /// </summary>
        public static string PreclaimsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Claims", "Preclaims", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> PreclaimsDefault
        /// Default value as hex string
        /// </summary>
        public static string PreclaimsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Preclaims
        ///  Pre-claimed Ethereum accounts, by the Account ID that they are claimed to.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EthereumAddress> Preclaims(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = PreclaimsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.EthereumAddress>(parameters, blockHash, token);
            return result;
        }

        public ClaimsStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class ClaimsConstants
    {
        /// <summary>
        /// >> Prefix
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> Prefix()
        {
            var result = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>();
            result.Create("0x8450617920444F547320746F2074686520506F6C6B61646F74206163636F756E743A");
            return result;
        }
    }

    public enum ClaimsErrors
    {
        /// <summary>
        /// >> InvalidEthereumSignature
        /// Invalid Ethereum signature.
        /// </summary>
        InvalidEthereumSignature,
        /// <summary>
        /// >> SignerHasNoClaim
        /// Ethereum address has no claim.
        /// </summary>
        SignerHasNoClaim,
        /// <summary>
        /// >> SenderHasNoClaim
        /// Account ID sending transaction has no claim.
        /// </summary>
        SenderHasNoClaim,
        /// <summary>
        /// >> PotUnderflow
        /// There's not enough in the pot to pay out some unvested amount. Generally implies a logic
        /// error.
        /// </summary>
        PotUnderflow,
        /// <summary>
        /// >> InvalidStatement
        /// A needed statement was not included.
        /// </summary>
        InvalidStatement,
        /// <summary>
        /// >> VestedBalanceExists
        /// The account already has a vested balance.
        /// </summary>
        VestedBalanceExists
    }
}