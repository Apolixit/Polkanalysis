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


namespace Substats.Polkadot.NetApiExt.Generated.Storage
{
    
    
    public sealed class IdentityStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public IdentityStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Identity", "IdentityOf"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Substats.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.Registration)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Identity", "SuperOf"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.EnumData>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Identity", "SubsOf"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U128, Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT20>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Identity", "Registrars"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT21)));
        }
        
        /// <summary>
        /// >> IdentityOfParams
        ///  Information that is pertinent to identify the entity behind an account.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public static string IdentityOfParams(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Identity", "IdentityOf", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
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
        public async Task<Substats.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.Registration> IdentityOf(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = IdentityStorage.IdentityOfParams(key);
            var result = await _client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.Registration>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> SuperOfParams
        ///  The super-identity of an alternative "sub" identity together with its name, within that
        ///  context. If the account is not some other account's sub-identity, then just `None`.
        /// </summary>
        public static string SuperOfParams(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Identity", "SuperOf", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
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
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.EnumData>> SuperOf(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = IdentityStorage.SuperOfParams(key);
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.EnumData>>(parameters, token);
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
        public static string SubsOfParams(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Identity", "SubsOf", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
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
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U128, Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT20>> SubsOf(Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = IdentityStorage.SubsOfParams(key);
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U128, Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT20>>(parameters, token);
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
            return RequestGenerator.GetStorage("Identity", "Registrars", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT21> Registrars(CancellationToken token)
        {
            string parameters = IdentityStorage.RegistrarsParams();
            var result = await _client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT21>(parameters, token);
            return result;
        }
    }
    
    public sealed class IdentityCalls
    {
        
        /// <summary>
        /// >> add_registrar
        /// Identity pallet declaration.
        /// </summary>
        public static Method AddRegistrar(Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress account)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(account.Encode());
            return new Method(28, "Identity", 0, "add_registrar", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_identity
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetIdentity(Substats.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.IdentityInfo info)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(info.Encode());
            return new Method(28, "Identity", 1, "set_identity", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_subs
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetSubs(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.EnumData>> subs)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(subs.Encode());
            return new Method(28, "Identity", 2, "set_subs", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> clear_identity
        /// Identity pallet declaration.
        /// </summary>
        public static Method ClearIdentity()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(28, "Identity", 3, "clear_identity", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> request_judgement
        /// Identity pallet declaration.
        /// </summary>
        public static Method RequestJudgement(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> reg_index, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128> max_fee)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(reg_index.Encode());
            byteArray.AddRange(max_fee.Encode());
            return new Method(28, "Identity", 4, "request_judgement", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> cancel_request
        /// Identity pallet declaration.
        /// </summary>
        public static Method CancelRequest(Ajuna.NetApi.Model.Types.Primitive.U32 reg_index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(reg_index.Encode());
            return new Method(28, "Identity", 5, "cancel_request", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_fee
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetFee(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> index, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128> fee)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(fee.Encode());
            return new Method(28, "Identity", 6, "set_fee", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_account_id
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetAccountId(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> index, Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(@new.Encode());
            return new Method(28, "Identity", 7, "set_account_id", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_fields
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetFields(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> index, Substats.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.BitFlags fields)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(fields.Encode());
            return new Method(28, "Identity", 8, "set_fields", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> provide_judgement
        /// Identity pallet declaration.
        /// </summary>
        public static Method ProvideJudgement(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> reg_index, Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress target, Substats.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.EnumJudgement judgement, Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 identity)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(reg_index.Encode());
            byteArray.AddRange(target.Encode());
            byteArray.AddRange(judgement.Encode());
            byteArray.AddRange(identity.Encode());
            return new Method(28, "Identity", 9, "provide_judgement", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> kill_identity
        /// Identity pallet declaration.
        /// </summary>
        public static Method KillIdentity(Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress target)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(target.Encode());
            return new Method(28, "Identity", 10, "kill_identity", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> add_sub
        /// Identity pallet declaration.
        /// </summary>
        public static Method AddSub(Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress sub, Substats.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.EnumData data)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(sub.Encode());
            byteArray.AddRange(data.Encode());
            return new Method(28, "Identity", 11, "add_sub", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> rename_sub
        /// Identity pallet declaration.
        /// </summary>
        public static Method RenameSub(Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress sub, Substats.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.EnumData data)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(sub.Encode());
            byteArray.AddRange(data.Encode());
            return new Method(28, "Identity", 12, "rename_sub", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_sub
        /// Identity pallet declaration.
        /// </summary>
        public static Method RemoveSub(Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress sub)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(sub.Encode());
            return new Method(28, "Identity", 13, "remove_sub", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> quit_sub
        /// Identity pallet declaration.
        /// </summary>
        public static Method QuitSub()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(28, "Identity", 14, "quit_sub", byteArray.ToArray());
        }
    }
    
    public sealed class IdentityConstants
    {
        
        /// <summary>
        /// >> BasicDeposit
        ///  The amount held on deposit for a registered identity
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 BasicDeposit()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U128();
            result.Create("0x007DB52A2F0000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> FieldDeposit
        ///  The amount held on deposit per additional field for a registered identity.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 FieldDeposit()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00CD5627000000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> SubAccountDeposit
        ///  The amount held on deposit for a registered subaccount. This should account for the fact
        ///  that one storage item's value will increase by the size of an account ID, and there will
        ///  be another trie item whose value is the size of an account ID plus 32 bytes.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 SubAccountDeposit()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U128();
            result.Create("0x80F884B02E0000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxSubAccounts
        ///  The maximum number of sub-accounts allowed per identified account.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaxSubAccounts()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0x64000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxAdditionalFields
        ///  Maximum number of additional fields that may be stored in an ID. Needed to bound the I/O
        ///  required to access an identity, but can be pretty high.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaxAdditionalFields()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0x64000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxRegistrars
        ///  Maxmimum number of registrars allowed in the system. Needed to bound the complexity
        ///  of, e.g., updating judgements.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaxRegistrars()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
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
        NotOwned,
        
        /// <summary>
        /// >> JudgementForDifferentIdentity
        /// The provided judgement was for a different identity.
        /// </summary>
        JudgementForDifferentIdentity,
        
        /// <summary>
        /// >> JudgementPaymentFailed
        /// Error that occurs when there is an issue paying for judgement.
        /// </summary>
        JudgementPaymentFailed,
    }
}
