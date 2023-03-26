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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage
{
    
    
    public sealed class ClaimsStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public ClaimsStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Claims", "Claims"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress), typeof(Ajuna.NetApi.Model.Types.Primitive.U128)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Claims", "Total"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U128)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Claims", "Vesting"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress), typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U32>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Claims", "Signing"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress), typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EnumStatementKind)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Claims", "Preclaims"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress)));
        }
        
        /// <summary>
        /// >> ClaimsParams
        /// </summary>
        public static string ClaimsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress key)
        {
            return RequestGenerator.GetStorage("Claims", "Claims", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
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
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U128> Claims(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress key, CancellationToken token)
        {
            string parameters = ClaimsStorage.ClaimsParams(key);
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U128>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> TotalParams
        /// </summary>
        public static string TotalParams()
        {
            return RequestGenerator.GetStorage("Claims", "Total", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U128> Total(CancellationToken token)
        {
            string parameters = ClaimsStorage.TotalParams();
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U128>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> VestingParams
        ///  Vesting schedule for a claim.
        ///  First balance is the total amount that should be held for vesting.
        ///  Second balance is how much should be unlocked per block.
        ///  The block number is when the vesting should start.
        /// </summary>
        public static string VestingParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress key)
        {
            return RequestGenerator.GetStorage("Claims", "Vesting", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
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
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U32>> Vesting(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress key, CancellationToken token)
        {
            string parameters = ClaimsStorage.VestingParams(key);
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U32>>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> SigningParams
        ///  The statement kind that must be signed, if any.
        /// </summary>
        public static string SigningParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress key)
        {
            return RequestGenerator.GetStorage("Claims", "Signing", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
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
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EnumStatementKind> Signing(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress key, CancellationToken token)
        {
            string parameters = ClaimsStorage.SigningParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EnumStatementKind>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> PreclaimsParams
        ///  Pre-claimed Ethereum accounts, by the Account ID that they are claimed to.
        /// </summary>
        public static string PreclaimsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Claims", "Preclaims", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
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
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress> Preclaims(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = ClaimsStorage.PreclaimsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress>(parameters, token);
            return result;
        }
    }
    
    public sealed class ClaimsCalls
    {
        
        /// <summary>
        /// >> claim
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Claim(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 dest, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EcdsaSignature ethereum_signature)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(ethereum_signature.Encode());
            return new Method(24, "Claims", 0, "claim", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> mint_claim
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method MintClaim(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress who, Ajuna.NetApi.Model.Types.Primitive.U128 value, Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U32>> vesting_schedule, Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EnumStatementKind> statement)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(who.Encode());
            byteArray.AddRange(value.Encode());
            byteArray.AddRange(vesting_schedule.Encode());
            byteArray.AddRange(statement.Encode());
            return new Method(24, "Claims", 1, "mint_claim", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> claim_attest
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ClaimAttest(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 dest, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EcdsaSignature ethereum_signature, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> statement)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(ethereum_signature.Encode());
            byteArray.AddRange(statement.Encode());
            return new Method(24, "Claims", 2, "claim_attest", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> attest
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Attest(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> statement)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(statement.Encode());
            return new Method(24, "Claims", 3, "attest", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> move_claim
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method MoveClaim(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress old, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.EthereumAddress @new, Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> maybe_preclaim)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(old.Encode());
            byteArray.AddRange(@new.Encode());
            byteArray.AddRange(maybe_preclaim.Encode());
            return new Method(24, "Claims", 4, "move_claim", byteArray.ToArray());
        }
    }
    
    public sealed class ClaimsConstants
    {
        
        /// <summary>
        /// >> Prefix
        /// </summary>
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> Prefix()
        {
            var result = new Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>();
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
        VestedBalanceExists,
    }
}
