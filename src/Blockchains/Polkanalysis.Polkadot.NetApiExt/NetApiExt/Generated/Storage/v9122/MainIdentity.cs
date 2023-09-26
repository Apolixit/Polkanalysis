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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9122
{
    public sealed class IdentityStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> IdentityOfParams
        ///  Information that is pertinent to identify the entity behind an account.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public static string IdentityOfParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Identity", "IdentityOf", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> IdentityOfDefault
        /// Default value as hex string
        /// </summary>
        public static string IdentityOfDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> IdentityOf
        ///  Information that is pertinent to identify the entity behind an account.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_identity.types.Registration> IdentityOf(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = IdentityOfParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_identity.types.Registration>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SuperOfParams
        ///  The super-identity of an alternative "sub" identity together with its name, within that
        ///  context. If the account is not some other account's sub-identity, then just `None`.
        /// </summary>
        public static string SuperOfParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Identity", "SuperOf", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> SuperOfDefault
        /// Default value as hex string
        /// </summary>
        public static string SuperOfDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> SuperOf
        ///  The super-identity of an alternative "sub" identity together with its name, within that
        ///  context. If the account is not some other account's sub-identity, then just `None`.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_identity.types.EnumData>> SuperOf(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = SuperOfParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_identity.types.EnumData>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SubsOfParams
        ///  Alternative "sub" identities of this account.
        /// 
        ///  The first item is the deposit, the second is a vector of the accounts.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public static string SubsOfParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Identity", "SubsOf", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> SubsOfDefault
        /// Default value as hex string
        /// </summary>
        public static string SubsOfDefault()
        {
            return "0x0000000000000000000000000000000000";
        }

        /// <summary>
        /// >> SubsOf
        ///  Alternative "sub" identities of this account.
        /// 
        ///  The first item is the deposit, the second is a vector of the accounts.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32>>> SubsOf(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = SubsOfParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> RegistrarsParams
        ///  The set of registrars. Not expected to get very big as can only be added through a
        ///  special origin (likely a council motion).
        /// 
        ///  The index into this can be cast to `RegistrarIndex` to get a valid value.
        /// </summary>
        public static string RegistrarsParams()
        {
            return RequestGenerator.GetStorage("Identity", "Registrars", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> RegistrarsDefault
        /// Default value as hex string
        /// </summary>
        public static string RegistrarsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Registrars
        ///  The set of registrars. Not expected to get very big as can only be added through a
        ///  special origin (likely a council motion).
        /// 
        ///  The index into this can be cast to `RegistrarIndex` to get a valid value.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_identity.types.RegistrarInfo>>> Registrars(CancellationToken token)
        {
            string parameters = RegistrarsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_identity.types.RegistrarInfo>>>(parameters, blockHash, token);
            return result;
        }

        public IdentityStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class IdentityConstants
    {
        /// <summary>
        /// >> BasicDeposit
        ///  The amount held on deposit for a registered identity
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 BasicDeposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x007DB52A2F0000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> FieldDeposit
        ///  The amount held on deposit per additional field for a registered identity.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 FieldDeposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00CD5627000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> SubAccountDeposit
        ///  The amount held on deposit for a registered subaccount. This should account for the fact
        ///  that one storage item's value will increase by the size of an account ID, and there will
        ///  be another trie item whose value is the size of an account ID plus 32 bytes.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 SubAccountDeposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x80F884B02E0000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> MaxSubAccounts
        ///  The maximum number of sub-accounts allowed per identified account.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxSubAccounts()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x64000000");
            return result;
        }

        /// <summary>
        /// >> MaxAdditionalFields
        ///  Maximum number of additional fields that may be stored in an ID. Needed to bound the I/O
        ///  required to access an identity, but can be pretty high.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxAdditionalFields()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x64000000");
            return result;
        }

        /// <summary>
        /// >> MaxRegistrars
        ///  Maxmimum number of registrars allowed in the system. Needed to bound the complexity
        ///  of, e.g., updating judgements.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxRegistrars()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x14000000");
            return result;
        }
    }

    public enum IdentityErrors
    {
        /// <summary>
        /// >> TooManySubAccounts
        /// Too many subs-accounts.
        /// </summary>
        TooManySubAccounts,
        /// <summary>
        /// >> NotFound
        /// Account isn't found.
        /// </summary>
        NotFound,
        /// <summary>
        /// >> NotNamed
        /// Account isn't named.
        /// </summary>
        NotNamed,
        /// <summary>
        /// >> EmptyIndex
        /// Empty index.
        /// </summary>
        EmptyIndex,
        /// <summary>
        /// >> FeeChanged
        /// Fee is changed.
        /// </summary>
        FeeChanged,
        /// <summary>
        /// >> NoIdentity
        /// No identity found.
        /// </summary>
        NoIdentity,
        /// <summary>
        /// >> StickyJudgement
        /// Sticky judgement.
        /// </summary>
        StickyJudgement,
        /// <summary>
        /// >> JudgementGiven
        /// Judgement given.
        /// </summary>
        JudgementGiven,
        /// <summary>
        /// >> InvalidJudgement
        /// Invalid judgement.
        /// </summary>
        InvalidJudgement,
        /// <summary>
        /// >> InvalidIndex
        /// The index is invalid.
        /// </summary>
        InvalidIndex,
        /// <summary>
        /// >> InvalidTarget
        /// The target is invalid.
        /// </summary>
        InvalidTarget,
        /// <summary>
        /// >> TooManyFields
        /// Too many additional fields.
        /// </summary>
        TooManyFields,
        /// <summary>
        /// >> TooManyRegistrars
        /// Maximum amount of registrars reached. Cannot add any more.
        /// </summary>
        TooManyRegistrars,
        /// <summary>
        /// >> AlreadyClaimed
        /// Account ID is already named.
        /// </summary>
        AlreadyClaimed,
        /// <summary>
        /// >> NotSub
        /// Sender is not a sub-account.
        /// </summary>
        NotSub,
        /// <summary>
        /// >> NotOwned
        /// Sub-account isn't owned by sender.
        /// </summary>
        NotOwned
    }
}