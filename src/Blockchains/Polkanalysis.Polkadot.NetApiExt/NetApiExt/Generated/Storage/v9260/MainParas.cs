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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9260
{
    public sealed class ParasStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> PvfActiveVoteMapParams
        ///  All currently active PVF pre-checking votes.
        /// 
        ///  Invariant:
        ///  - There are no PVF pre-checking votes that exists in list but not in the set and vice versa.
        /// </summary>
        public static string PvfActiveVoteMapParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash key)
        {
            return RequestGenerator.GetStorage("Paras", "PvfActiveVoteMap", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> PvfActiveVoteMapDefault
        /// Default value as hex string
        /// </summary>
        public static string PvfActiveVoteMapDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> PvfActiveVoteMap
        ///  All currently active PVF pre-checking votes.
        /// 
        ///  Invariant:
        ///  - There are no PVF pre-checking votes that exists in list but not in the set and vice versa.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_runtime_parachains.paras.PvfCheckActiveVoteState> PvfActiveVoteMap(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash key, CancellationToken token)
        {
            string parameters = PvfActiveVoteMapParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_runtime_parachains.paras.PvfCheckActiveVoteState>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PvfActiveVoteListParams
        ///  The list of all currently active PVF votes. Auxiliary to `PvfActiveVoteMap`.
        /// </summary>
        public static string PvfActiveVoteListParams()
        {
            return RequestGenerator.GetStorage("Paras", "PvfActiveVoteList", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> PvfActiveVoteListDefault
        /// Default value as hex string
        /// </summary>
        public static string PvfActiveVoteListDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> PvfActiveVoteList
        ///  The list of all currently active PVF votes. Auxiliary to `PvfActiveVoteMap`.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash>> PvfActiveVoteList(CancellationToken token)
        {
            string parameters = PvfActiveVoteListParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ParachainsParams
        ///  All parachains. Ordered ascending by `ParaId`. Parathreads are not included.
        /// 
        ///  Consider using the [`ParachainsCache`] type of modifying.
        /// </summary>
        public static string ParachainsParams()
        {
            return RequestGenerator.GetStorage("Paras", "Parachains", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ParachainsDefault
        /// Default value as hex string
        /// </summary>
        public static string ParachainsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Parachains
        ///  All parachains. Ordered ascending by `ParaId`. Parathreads are not included.
        /// 
        ///  Consider using the [`ParachainsCache`] type of modifying.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id>> Parachains(CancellationToken token)
        {
            string parameters = ParachainsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ParaLifecyclesParams
        ///  The current lifecycle of a all known Para IDs.
        /// </summary>
        public static string ParaLifecyclesParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Paras", "ParaLifecycles", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ParaLifecyclesDefault
        /// Default value as hex string
        /// </summary>
        public static string ParaLifecyclesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ParaLifecycles
        ///  The current lifecycle of a all known Para IDs.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_runtime_parachains.paras.EnumParaLifecycle> ParaLifecycles(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = ParaLifecyclesParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_runtime_parachains.paras.EnumParaLifecycle>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> HeadsParams
        ///  The head-data of every registered para.
        /// </summary>
        public static string HeadsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Paras", "Heads", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> HeadsDefault
        /// Default value as hex string
        /// </summary>
        public static string HeadsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Heads
        ///  The head-data of every registered para.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.HeadData> Heads(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = HeadsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.HeadData>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CurrentCodeHashParams
        ///  The validation code hash of every live para.
        /// 
        ///  Corresponding code can be retrieved with [`CodeByHash`].
        /// </summary>
        public static string CurrentCodeHashParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Paras", "CurrentCodeHash", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> CurrentCodeHashDefault
        /// Default value as hex string
        /// </summary>
        public static string CurrentCodeHashDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> CurrentCodeHash
        ///  The validation code hash of every live para.
        /// 
        ///  Corresponding code can be retrieved with [`CodeByHash`].
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash> CurrentCodeHash(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = CurrentCodeHashParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PastCodeHashParams
        ///  Actual past code hash, indicated by the para id as well as the block number at which it
        ///  became outdated.
        /// 
        ///  Corresponding code can be retrieved with [`CodeByHash`].
        /// </summary>
        public static string PastCodeHashParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U32> key)
        {
            return RequestGenerator.GetStorage("Paras", "PastCodeHash", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> PastCodeHashDefault
        /// Default value as hex string
        /// </summary>
        public static string PastCodeHashDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> PastCodeHash
        ///  Actual past code hash, indicated by the para id as well as the block number at which it
        ///  became outdated.
        /// 
        ///  Corresponding code can be retrieved with [`CodeByHash`].
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash> PastCodeHash(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U32> key, CancellationToken token)
        {
            string parameters = PastCodeHashParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PastCodeMetaParams
        ///  Past code of parachains. The parachains themselves may not be registered anymore,
        ///  but we also keep their code on-chain for the same amount of time as outdated code
        ///  to keep it available for secondary checkers.
        /// </summary>
        public static string PastCodeMetaParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Paras", "PastCodeMeta", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> PastCodeMetaDefault
        /// Default value as hex string
        /// </summary>
        public static string PastCodeMetaDefault()
        {
            return "0x0000";
        }

        /// <summary>
        /// >> PastCodeMeta
        ///  Past code of parachains. The parachains themselves may not be registered anymore,
        ///  but we also keep their code on-chain for the same amount of time as outdated code
        ///  to keep it available for secondary checkers.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_runtime_parachains.paras.ParaPastCodeMeta> PastCodeMeta(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = PastCodeMetaParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_runtime_parachains.paras.ParaPastCodeMeta>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PastCodePruningParams
        ///  Which paras have past code that needs pruning and the relay-chain block at which the code was replaced.
        ///  Note that this is the actual height of the included block, not the expected height at which the
        ///  code upgrade would be applied, although they may be equal.
        ///  This is to ensure the entire acceptance period is covered, not an offset acceptance period starting
        ///  from the time at which the parachain perceives a code upgrade as having occurred.
        ///  Multiple entries for a single para are permitted. Ordered ascending by block number.
        /// </summary>
        public static string PastCodePruningParams()
        {
            return RequestGenerator.GetStorage("Paras", "PastCodePruning", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> PastCodePruningDefault
        /// Default value as hex string
        /// </summary>
        public static string PastCodePruningDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> PastCodePruning
        ///  Which paras have past code that needs pruning and the relay-chain block at which the code was replaced.
        ///  Note that this is the actual height of the included block, not the expected height at which the
        ///  code upgrade would be applied, although they may be equal.
        ///  This is to ensure the entire acceptance period is covered, not an offset acceptance period starting
        ///  from the time at which the parachain perceives a code upgrade as having occurred.
        ///  Multiple entries for a single para are permitted. Ordered ascending by block number.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U32>>> PastCodePruning(CancellationToken token)
        {
            string parameters = PastCodePruningParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U32>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> FutureCodeUpgradesParams
        ///  The block number at which the planned code change is expected for a para.
        ///  The change will be applied after the first parablock for this ID included which executes
        ///  in the context of a relay chain block with a number >= `expected_at`.
        /// </summary>
        public static string FutureCodeUpgradesParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Paras", "FutureCodeUpgrades", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> FutureCodeUpgradesDefault
        /// Default value as hex string
        /// </summary>
        public static string FutureCodeUpgradesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> FutureCodeUpgrades
        ///  The block number at which the planned code change is expected for a para.
        ///  The change will be applied after the first parablock for this ID included which executes
        ///  in the context of a relay chain block with a number >= `expected_at`.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> FutureCodeUpgrades(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = FutureCodeUpgradesParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> FutureCodeHashParams
        ///  The actual future code hash of a para.
        /// 
        ///  Corresponding code can be retrieved with [`CodeByHash`].
        /// </summary>
        public static string FutureCodeHashParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Paras", "FutureCodeHash", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> FutureCodeHashDefault
        /// Default value as hex string
        /// </summary>
        public static string FutureCodeHashDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> FutureCodeHash
        ///  The actual future code hash of a para.
        /// 
        ///  Corresponding code can be retrieved with [`CodeByHash`].
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash> FutureCodeHash(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = FutureCodeHashParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> UpgradeGoAheadSignalParams
        ///  This is used by the relay-chain to communicate to a parachain a go-ahead with in the upgrade procedure.
        /// 
        ///  This value is absent when there are no upgrades scheduled or during the time the relay chain
        ///  performs the checks. It is set at the first relay-chain block when the corresponding parachain
        ///  can switch its upgrade function. As soon as the parachain's block is included, the value
        ///  gets reset to `None`.
        /// 
        ///  NOTE that this field is used by parachains via merkle storage proofs, therefore changing
        ///  the format will require migration of parachains.
        /// </summary>
        public static string UpgradeGoAheadSignalParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Paras", "UpgradeGoAheadSignal", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> UpgradeGoAheadSignalDefault
        /// Default value as hex string
        /// </summary>
        public static string UpgradeGoAheadSignalDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> UpgradeGoAheadSignal
        ///  This is used by the relay-chain to communicate to a parachain a go-ahead with in the upgrade procedure.
        /// 
        ///  This value is absent when there are no upgrades scheduled or during the time the relay chain
        ///  performs the checks. It is set at the first relay-chain block when the corresponding parachain
        ///  can switch its upgrade function. As soon as the parachain's block is included, the value
        ///  gets reset to `None`.
        /// 
        ///  NOTE that this field is used by parachains via merkle storage proofs, therefore changing
        ///  the format will require migration of parachains.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_primitives.v2.EnumUpgradeGoAhead> UpgradeGoAheadSignal(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = UpgradeGoAheadSignalParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_primitives.v2.EnumUpgradeGoAhead>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> UpgradeRestrictionSignalParams
        ///  This is used by the relay-chain to communicate that there are restrictions for performing
        ///  an upgrade for this parachain.
        /// 
        ///  This may be a because the parachain waits for the upgrade cooldown to expire. Another
        ///  potential use case is when we want to perform some maintenance (such as storage migration)
        ///  we could restrict upgrades to make the process simpler.
        /// 
        ///  NOTE that this field is used by parachains via merkle storage proofs, therefore changing
        ///  the format will require migration of parachains.
        /// </summary>
        public static string UpgradeRestrictionSignalParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Paras", "UpgradeRestrictionSignal", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> UpgradeRestrictionSignalDefault
        /// Default value as hex string
        /// </summary>
        public static string UpgradeRestrictionSignalDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> UpgradeRestrictionSignal
        ///  This is used by the relay-chain to communicate that there are restrictions for performing
        ///  an upgrade for this parachain.
        /// 
        ///  This may be a because the parachain waits for the upgrade cooldown to expire. Another
        ///  potential use case is when we want to perform some maintenance (such as storage migration)
        ///  we could restrict upgrades to make the process simpler.
        /// 
        ///  NOTE that this field is used by parachains via merkle storage proofs, therefore changing
        ///  the format will require migration of parachains.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_primitives.v2.EnumUpgradeRestriction> UpgradeRestrictionSignal(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = UpgradeRestrictionSignalParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_primitives.v2.EnumUpgradeRestriction>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> UpgradeCooldownsParams
        ///  The list of parachains that are awaiting for their upgrade restriction to cooldown.
        /// 
        ///  Ordered ascending by block number.
        /// </summary>
        public static string UpgradeCooldownsParams()
        {
            return RequestGenerator.GetStorage("Paras", "UpgradeCooldowns", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> UpgradeCooldownsDefault
        /// Default value as hex string
        /// </summary>
        public static string UpgradeCooldownsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> UpgradeCooldowns
        ///  The list of parachains that are awaiting for their upgrade restriction to cooldown.
        /// 
        ///  Ordered ascending by block number.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U32>>> UpgradeCooldowns(CancellationToken token)
        {
            string parameters = UpgradeCooldownsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U32>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> UpcomingUpgradesParams
        ///  The list of upcoming code upgrades. Each item is a pair of which para performs a code
        ///  upgrade and at which relay-chain block it is expected at.
        /// 
        ///  Ordered ascending by block number.
        /// </summary>
        public static string UpcomingUpgradesParams()
        {
            return RequestGenerator.GetStorage("Paras", "UpcomingUpgrades", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> UpcomingUpgradesDefault
        /// Default value as hex string
        /// </summary>
        public static string UpcomingUpgradesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> UpcomingUpgrades
        ///  The list of upcoming code upgrades. Each item is a pair of which para performs a code
        ///  upgrade and at which relay-chain block it is expected at.
        /// 
        ///  Ordered ascending by block number.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U32>>> UpcomingUpgrades(CancellationToken token)
        {
            string parameters = UpcomingUpgradesParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U32>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ActionsQueueParams
        ///  The actions to perform during the start of a specific session index.
        /// </summary>
        public static string ActionsQueueParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Paras", "ActionsQueue", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ActionsQueueDefault
        /// Default value as hex string
        /// </summary>
        public static string ActionsQueueDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ActionsQueue
        ///  The actions to perform during the start of a specific session index.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id>> ActionsQueue(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ActionsQueueParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> UpcomingParasGenesisParams
        ///  Upcoming paras instantiation arguments.
        /// 
        ///  NOTE that after PVF pre-checking is enabled the para genesis arg will have it's code set
        ///  to empty. Instead, the code will be saved into the storage right away via `CodeByHash`.
        /// </summary>
        public static string UpcomingParasGenesisParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Paras", "UpcomingParasGenesis", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> UpcomingParasGenesisDefault
        /// Default value as hex string
        /// </summary>
        public static string UpcomingParasGenesisDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> UpcomingParasGenesis
        ///  Upcoming paras instantiation arguments.
        /// 
        ///  NOTE that after PVF pre-checking is enabled the para genesis arg will have it's code set
        ///  to empty. Instead, the code will be saved into the storage right away via `CodeByHash`.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_runtime_parachains.paras.ParaGenesisArgs> UpcomingParasGenesis(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = UpcomingParasGenesisParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_runtime_parachains.paras.ParaGenesisArgs>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CodeByHashRefsParams
        ///  The number of reference on the validation code in [`CodeByHash`] storage.
        /// </summary>
        public static string CodeByHashRefsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash key)
        {
            return RequestGenerator.GetStorage("Paras", "CodeByHashRefs", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> CodeByHashRefsDefault
        /// Default value as hex string
        /// </summary>
        public static string CodeByHashRefsDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> CodeByHashRefs
        ///  The number of reference on the validation code in [`CodeByHash`] storage.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> CodeByHashRefs(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash key, CancellationToken token)
        {
            string parameters = CodeByHashRefsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CodeByHashParams
        ///  Validation code stored by its hash.
        /// 
        ///  This storage is consistent with [`FutureCodeHash`], [`CurrentCodeHash`] and
        ///  [`PastCodeHash`].
        /// </summary>
        public static string CodeByHashParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash key)
        {
            return RequestGenerator.GetStorage("Paras", "CodeByHash", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> CodeByHashDefault
        /// Default value as hex string
        /// </summary>
        public static string CodeByHashDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> CodeByHash
        ///  Validation code stored by its hash.
        /// 
        ///  This storage is consistent with [`FutureCodeHash`], [`CurrentCodeHash`] and
        ///  [`PastCodeHash`].
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCode> CodeByHash(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCodeHash key, CancellationToken token)
        {
            string parameters = CodeByHashParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_parachain.primitives.ValidationCode>(parameters, blockHash, token);
            return result;
        }

        public ParasStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class ParasConstants
    {
        /// <summary>
        /// >> UnsignedPriority
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 UnsignedPriority()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0xFFFFFFFFFFFFFFFF");
            return result;
        }
    }

    public enum ParasErrors
    {
        /// <summary>
        /// >> NotRegistered
        /// Para is not registered in our system.
        /// </summary>
        NotRegistered,
        /// <summary>
        /// >> CannotOnboard
        /// Para cannot be onboarded because it is already tracked by our system.
        /// </summary>
        CannotOnboard,
        /// <summary>
        /// >> CannotOffboard
        /// Para cannot be offboarded at this time.
        /// </summary>
        CannotOffboard,
        /// <summary>
        /// >> CannotUpgrade
        /// Para cannot be upgraded to a parachain.
        /// </summary>
        CannotUpgrade,
        /// <summary>
        /// >> CannotDowngrade
        /// Para cannot be downgraded to a parathread.
        /// </summary>
        CannotDowngrade,
        /// <summary>
        /// >> PvfCheckStatementStale
        /// The statement for PVF pre-checking is stale.
        /// </summary>
        PvfCheckStatementStale,
        /// <summary>
        /// >> PvfCheckStatementFuture
        /// The statement for PVF pre-checking is for a future session.
        /// </summary>
        PvfCheckStatementFuture,
        /// <summary>
        /// >> PvfCheckValidatorIndexOutOfBounds
        /// Claimed validator index is out of bounds.
        /// </summary>
        PvfCheckValidatorIndexOutOfBounds,
        /// <summary>
        /// >> PvfCheckInvalidSignature
        /// The signature for the PVF pre-checking is invalid.
        /// </summary>
        PvfCheckInvalidSignature,
        /// <summary>
        /// >> PvfCheckDoubleVote
        /// The given validator already has cast a vote.
        /// </summary>
        PvfCheckDoubleVote,
        /// <summary>
        /// >> PvfCheckSubjectInvalid
        /// The given PVF does not exist at the moment of process a vote.
        /// </summary>
        PvfCheckSubjectInvalid,
        /// <summary>
        /// >> PvfCheckDisabled
        /// The PVF pre-checking statement cannot be included since the PVF pre-checking mechanism
        /// is disabled.
        /// </summary>
        PvfCheckDisabled
    }
}