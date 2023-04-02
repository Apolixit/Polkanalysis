//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage
{
    
    
    public sealed class IndicesStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public IndicesStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Indices", "Accounts"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Substrate.NetApi.Model.Types.Primitive.U32), typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.Bool>)));
        }
        
        /// <summary>
        /// >> AccountsParams
        ///  The lookup from index to account.
        /// </summary>
        public static string AccountsParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Indices", "Accounts", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> Accounts
        ///  The lookup from index to account.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.Bool>> Accounts(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = IndicesStorage.AccountsParams(key);
            return await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.Bool>>(parameters, token);
        }
    }
    
    public sealed class IndicesCalls
    {
        
        /// <summary>
        /// >> claim
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Claim(Substrate.NetApi.Model.Types.Primitive.U32 index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            return new Method(3, "Indices", 0, "claim", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> transfer
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Transfer(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress @new, Substrate.NetApi.Model.Types.Primitive.U32 index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            byteArray.AddRange(index.Encode());
            return new Method(3, "Indices", 1, "transfer", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> free
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Free(Substrate.NetApi.Model.Types.Primitive.U32 index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            return new Method(3, "Indices", 2, "free", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_transfer
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ForceTransfer(Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress @new, Substrate.NetApi.Model.Types.Primitive.U32 index, Substrate.NetApi.Model.Types.Primitive.Bool freeze)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(freeze.Encode());
            return new Method(3, "Indices", 3, "force_transfer", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> freeze
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Freeze(Substrate.NetApi.Model.Types.Primitive.U32 index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            return new Method(3, "Indices", 4, "freeze", byteArray.ToArray());
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
        Permanent,
    }
}
