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


namespace Substats.Bajun.NetApiExt.Generated.Storage
{
    
    
    public sealed class IdentityStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public IdentityStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Identity", "IdentityOf"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Substats.Bajun.NetApiExt.Generated.Model.pallet_identity.types.Registration)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Identity", "SuperOf"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Model.pallet_identity.types.EnumData>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Identity", "SubsOf"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32), typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U128, Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT9>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Identity", "Registrars"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT10)));
        }
        
        /// <summary>
        /// >> IdentityOfParams
        ///  Information that is pertinent to identify the entity behind an account.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public static string IdentityOfParams(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Identity", "IdentityOf", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> IdentityOf
        ///  Information that is pertinent to identify the entity behind an account.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public async Task<Substats.Bajun.NetApiExt.Generated.Model.pallet_identity.types.Registration> IdentityOf(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = IdentityStorage.IdentityOfParams(key);
            return await _client.GetStorageAsync<Substats.Bajun.NetApiExt.Generated.Model.pallet_identity.types.Registration>(parameters, token);
        }
        
        /// <summary>
        /// >> SuperOfParams
        ///  The super-identity of an alternative "sub" identity together with its name, within that
        ///  context. If the account is not some other account's sub-identity, then just `None`.
        /// </summary>
        public static string SuperOfParams(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Identity", "SuperOf", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> SuperOf
        ///  The super-identity of an alternative "sub" identity together with its name, within that
        ///  context. If the account is not some other account's sub-identity, then just `None`.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Model.pallet_identity.types.EnumData>> SuperOf(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = IdentityStorage.SuperOfParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Model.pallet_identity.types.EnumData>>(parameters, token);
        }
        
        /// <summary>
        /// >> SubsOfParams
        ///  Alternative "sub" identities of this account.
        /// 
        ///  The first item is the deposit, the second is a vector of the accounts.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public static string SubsOfParams(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Identity", "SubsOf", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> SubsOf
        ///  Alternative "sub" identities of this account.
        /// 
        ///  The first item is the deposit, the second is a vector of the accounts.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U128, Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT9>> SubsOf(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = IdentityStorage.SubsOfParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U128, Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT9>>(parameters, token);
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
        /// >> Registrars
        ///  The set of registrars. Not expected to get very big as can only be added through a
        ///  special origin (likely a council motion).
        /// 
        ///  The index into this can be cast to `RegistrarIndex` to get a valid value.
        /// </summary>
        public async Task<Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT10> Registrars(CancellationToken token)
        {
            string parameters = IdentityStorage.RegistrarsParams();
            return await _client.GetStorageAsync<Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT10>(parameters, token);
        }
    }
    
    public sealed class IdentityCalls
    {
        
        /// <summary>
        /// >> add_registrar
        /// Identity pallet declaration.
        /// </summary>
        public static Method AddRegistrar(Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 account)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(account.Encode());
            return new Method(7, "Identity", 0, "add_registrar", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_identity
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetIdentity(Substats.Bajun.NetApiExt.Generated.Model.pallet_identity.types.IdentityInfo info)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(info.Encode());
            return new Method(7, "Identity", 1, "set_identity", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_subs
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetSubs(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Bajun.NetApiExt.Generated.Model.pallet_identity.types.EnumData>> subs)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(subs.Encode());
            return new Method(7, "Identity", 2, "set_subs", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> clear_identity
        /// Identity pallet declaration.
        /// </summary>
        public static Method ClearIdentity()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(7, "Identity", 3, "clear_identity", byteArray.ToArray());
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
            return new Method(7, "Identity", 4, "request_judgement", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> cancel_request
        /// Identity pallet declaration.
        /// </summary>
        public static Method CancelRequest(Ajuna.NetApi.Model.Types.Primitive.U32 reg_index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(reg_index.Encode());
            return new Method(7, "Identity", 5, "cancel_request", byteArray.ToArray());
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
            return new Method(7, "Identity", 6, "set_fee", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_account_id
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetAccountId(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> index, Substats.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(@new.Encode());
            return new Method(7, "Identity", 7, "set_account_id", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_fields
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetFields(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> index, Substats.Bajun.NetApiExt.Generated.Model.pallet_identity.types.BitFlags fields)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(fields.Encode());
            return new Method(7, "Identity", 8, "set_fields", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> provide_judgement
        /// Identity pallet declaration.
        /// </summary>
        public static Method ProvideJudgement(Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> reg_index, Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress target, Substats.Bajun.NetApiExt.Generated.Model.pallet_identity.types.EnumJudgement judgement)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(reg_index.Encode());
            byteArray.AddRange(target.Encode());
            byteArray.AddRange(judgement.Encode());
            return new Method(7, "Identity", 9, "provide_judgement", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> kill_identity
        /// Identity pallet declaration.
        /// </summary>
        public static Method KillIdentity(Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress target)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(target.Encode());
            return new Method(7, "Identity", 10, "kill_identity", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> add_sub
        /// Identity pallet declaration.
        /// </summary>
        public static Method AddSub(Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress sub, Substats.Bajun.NetApiExt.Generated.Model.pallet_identity.types.EnumData data)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(sub.Encode());
            byteArray.AddRange(data.Encode());
            return new Method(7, "Identity", 11, "add_sub", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> rename_sub
        /// Identity pallet declaration.
        /// </summary>
        public static Method RenameSub(Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress sub, Substats.Bajun.NetApiExt.Generated.Model.pallet_identity.types.EnumData data)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(sub.Encode());
            byteArray.AddRange(data.Encode());
            return new Method(7, "Identity", 12, "rename_sub", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_sub
        /// Identity pallet declaration.
        /// </summary>
        public static Method RemoveSub(Substats.Bajun.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress sub)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(sub.Encode());
            return new Method(7, "Identity", 13, "remove_sub", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> quit_sub
        /// Identity pallet declaration.
        /// </summary>
        public static Method QuitSub()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(7, "Identity", 14, "quit_sub", byteArray.ToArray());
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
    }
}