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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9300
{
    public sealed class RegistrarStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> PendingSwapParams
        ///  Pending swap operations.
        /// </summary>
        public static string PendingSwapParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Registrar", "PendingSwap", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
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
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_parachain.primitives.Id> PendingSwap(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = PendingSwapParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_parachain.primitives.Id>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ParasParams
        ///  Amount held on deposit for each para and the original depositor.
        /// 
        ///  The given account ID is responsible for registering the code and initial head data, but may only do
        ///  so if it isn't yet registered. (After that, it's up to governance to do so.)
        /// </summary>
        public static string ParasParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Registrar", "Paras", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
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
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_runtime_common.paras_registrar.ParaInfo> Paras(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = ParasParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_runtime_common.paras_registrar.ParaInfo>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> NextFreeParaIdParams
        ///  The next free `ParaId`.
        /// </summary>
        public static string NextFreeParaIdParams()
        {
            return RequestGenerator.GetStorage("Registrar", "NextFreeParaId", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
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
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_parachain.primitives.Id> NextFreeParaId(CancellationToken token)
        {
            string parameters = NextFreeParaIdParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_parachain.primitives.Id>(parameters, blockHash, token);
            return result;
        }

        public RegistrarStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class RegistrarConstants
    {
        /// <summary>
        /// >> ParaDeposit
        ///  The deposit to be paid to run a parathread.
        ///  This should include the cost for storing the genesis head and validation code.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 ParaDeposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x0010A5D4E80000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> DataDepositPerByte
        ///  The deposit to be paid per byte stored on chain.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 DataDepositPerByte()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
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
        CannotSwap
    }
}