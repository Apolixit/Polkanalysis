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
    
    
    public sealed class RegistrarStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public RegistrarStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Registrar", "PendingSwap"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id), typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Registrar", "Paras"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id), typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.paras_registrar.ParaInfo)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Registrar", "NextFreeParaId"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id)));
        }
        
        /// <summary>
        /// >> PendingSwapParams
        ///  Pending swap operations.
        /// </summary>
        public static string PendingSwapParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Registrar", "PendingSwap", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> PendingSwapDefault
        /// Default value as hex string
        /// </summary>
        public static string PendingSwapDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> PendingSwap
        ///  Pending swap operations.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id> PendingSwap(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = RegistrarStorage.PendingSwapParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> ParasParams
        ///  Amount held on deposit for each para and the original depositor.
        /// 
        ///  The given account ID is responsible for registering the code and initial head data, but may only do
        ///  so if it isn't yet registered. (After that, it's up to governance to do so.)
        /// </summary>
        public static string ParasParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Registrar", "Paras", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> ParasDefault
        /// Default value as hex string
        /// </summary>
        public static string ParasDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Paras
        ///  Amount held on deposit for each para and the original depositor.
        /// 
        ///  The given account ID is responsible for registering the code and initial head data, but may only do
        ///  so if it isn't yet registered. (After that, it's up to governance to do so.)
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.paras_registrar.ParaInfo> Paras(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = RegistrarStorage.ParasParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.paras_registrar.ParaInfo>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> NextFreeParaIdParams
        ///  The next free `ParaId`.
        /// </summary>
        public static string NextFreeParaIdParams()
        {
            return RequestGenerator.GetStorage("Registrar", "NextFreeParaId", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> NextFreeParaIdDefault
        /// Default value as hex string
        /// </summary>
        public static string NextFreeParaIdDefault()
        {
            return "0x00000000";
        }
        
        /// <summary>
        /// >> NextFreeParaId
        ///  The next free `ParaId`.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id> NextFreeParaId(CancellationToken token)
        {
            string parameters = RegistrarStorage.NextFreeParaIdParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(parameters, token);
            return result;
        }
    }
    
    public sealed class RegistrarCalls
    {
        
        /// <summary>
        /// >> register
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Register(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.HeadData genesis_head, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCode validation_code)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(id.Encode());
            byteArray.AddRange(genesis_head.Encode());
            byteArray.AddRange(validation_code.Encode());
            return new Method(70, "Registrar", 0, "register", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_register
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ForceRegister(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 who, Ajuna.NetApi.Model.Types.Primitive.U128 deposit, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.HeadData genesis_head, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCode validation_code)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(who.Encode());
            byteArray.AddRange(deposit.Encode());
            byteArray.AddRange(id.Encode());
            byteArray.AddRange(genesis_head.Encode());
            byteArray.AddRange(validation_code.Encode());
            return new Method(70, "Registrar", 1, "force_register", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> deregister
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Deregister(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(id.Encode());
            return new Method(70, "Registrar", 2, "deregister", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> swap
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Swap(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id other)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(id.Encode());
            byteArray.AddRange(other.Encode());
            return new Method(70, "Registrar", 3, "swap", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_lock
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method RemoveLock(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id para)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(para.Encode());
            return new Method(70, "Registrar", 4, "remove_lock", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> reserve
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Reserve()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(70, "Registrar", 5, "reserve", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> add_lock
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method AddLock(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id para)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(para.Encode());
            return new Method(70, "Registrar", 6, "add_lock", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> schedule_code_upgrade
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ScheduleCodeUpgrade(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id para, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCode new_code)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(para.Encode());
            byteArray.AddRange(new_code.Encode());
            return new Method(70, "Registrar", 7, "schedule_code_upgrade", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_current_head
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SetCurrentHead(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id para, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.HeadData new_head)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(para.Encode());
            byteArray.AddRange(new_head.Encode());
            return new Method(70, "Registrar", 8, "set_current_head", byteArray.ToArray());
        }
    }
    
    public sealed class RegistrarConstants
    {
        
        /// <summary>
        /// >> ParaDeposit
        ///  The deposit to be paid to run a parathread.
        ///  This should include the cost for storing the genesis head and validation code.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 ParaDeposit()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U128();
            result.Create("0x0010A5D4E80000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> DataDepositPerByte
        ///  The deposit to be paid per byte stored on chain.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 DataDepositPerByte()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U128();
            result.Create("0x80969800000000000000000000000000");
            return result;
        }
    }
    
    public enum RegistrarErrors
    {
        
        /// <summary>
        /// >> NotRegistered
        /// The ID is not registered.
        /// </summary>
        NotRegistered,
        
        /// <summary>
        /// >> AlreadyRegistered
        /// The ID is already registered.
        /// </summary>
        AlreadyRegistered,
        
        /// <summary>
        /// >> NotOwner
        /// The caller is not the owner of this Id.
        /// </summary>
        NotOwner,
        
        /// <summary>
        /// >> CodeTooLarge
        /// Invalid para code size.
        /// </summary>
        CodeTooLarge,
        
        /// <summary>
        /// >> HeadDataTooLarge
        /// Invalid para head data size.
        /// </summary>
        HeadDataTooLarge,
        
        /// <summary>
        /// >> NotParachain
        /// Para is not a Parachain.
        /// </summary>
        NotParachain,
        
        /// <summary>
        /// >> NotParathread
        /// Para is not a Parathread.
        /// </summary>
        NotParathread,
        
        /// <summary>
        /// >> CannotDeregister
        /// Cannot deregister para
        /// </summary>
        CannotDeregister,
        
        /// <summary>
        /// >> CannotDowngrade
        /// Cannot schedule downgrade of parachain to parathread
        /// </summary>
        CannotDowngrade,
        
        /// <summary>
        /// >> CannotUpgrade
        /// Cannot schedule upgrade of parathread to parachain
        /// </summary>
        CannotUpgrade,
        
        /// <summary>
        /// >> ParaLocked
        /// Para is locked from manipulation by the manager. Must use parachain or relay chain governance.
        /// </summary>
        ParaLocked,
        
        /// <summary>
        /// >> NotReserved
        /// The ID given for registration has not been reserved.
        /// </summary>
        NotReserved,
        
        /// <summary>
        /// >> EmptyCode
        /// Registering parachain with empty code is not allowed.
        /// </summary>
        EmptyCode,
        
        /// <summary>
        /// >> CannotSwap
        /// Cannot perform a parachain slot / lifecycle swap. Check that the state of both paras are
        /// correct for the swap to work.
        /// </summary>
        CannotSwap,
    }
}
