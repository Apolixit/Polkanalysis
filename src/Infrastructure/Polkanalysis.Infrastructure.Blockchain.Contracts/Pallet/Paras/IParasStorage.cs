using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras
{
    public interface IParasStorage : IPalletStorage
    {
        /// <summary>
        ///  All currently active PVF pre-checking votes.
        /// 
        ///  Invariant:
        ///  - There are no PVF pre-checking votes that exists in list but not in the set and vice versa.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<PvfCheckActiveVoteState> PvfActiveVoteMapAsync(Hash key, CancellationToken token);

        /// <summary>
        /// The list of all currently active PVF votes. Auxiliary to `PvfActiveVoteMap`.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<Hash>> PvfActiveVoteListAsync(CancellationToken token);

        /// <summary>
        ///  All parachains. Ordered ascending by `ParaId`. Parathreads are not included.
        /// 
        ///  Consider using the [`ParachainsCache`] type of modifying.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<Id>> ParachainsAsync(CancellationToken token);

        /// <summary>
        /// The current lifecycle of a all known Para IDs.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<EnumParaLifecycle> ParaLifecyclesAsync(Id key, CancellationToken token);

        /// <summary>
        /// The head-data of every registered para.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<DataCode> HeadsAsync(Id key, CancellationToken token);

        /// <summary>
        ///  The validation code hash of every live para.
        /// 
        ///  Corresponding code can be retrieved with [`CodeByHash`].
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Hash> CurrentCodeHashAsync(Id key, CancellationToken token);

        /// <summary>
        ///  Actual past code hash, indicated by the para id as well as the block number at which it
        ///  became outdated.
        /// 
        ///  Corresponding code can be retrieved with [`CodeByHash`].
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Hash> PastCodeHashAsync(BaseTuple<Id, U32> key, CancellationToken token);

        /// <summary>
        ///  Past code of parachains. The parachains themselves may not be registered anymore,
        ///  but we also keep their code on-chain for the same amount of time as outdated code
        ///  to keep it available for approval checkers.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<ParaPastCodeMeta> PastCodeMetaAsync(Id key, CancellationToken token);

        /// <summary>
        ///  Which paras have past code that needs pruning and the relay-chain block at which the code was replaced.
        ///  Note that this is the actual height of the included block, not the expected height at which the
        ///  code upgrade would be applied, although they may be equal.
        ///  This is to ensure the entire acceptance period is covered, not an offset acceptance period starting
        ///  from the time at which the parachain perceives a code upgrade as having occurred.
        ///  Multiple entries for a single para are permitted. Ordered ascending by block number.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<BaseTuple<Id, U32>>> PastCodePruningAsync(CancellationToken token);

        /// <summary>
        ///  The block number at which the planned code change is expected for a para.
        ///  The change will be applied after the first parablock for this ID included which executes
        ///  in the context of a relay chain block with a number >= `expected_at`.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> FutureCodeUpgradesAsync(Id key, CancellationToken token);

        /// <summary>
        ///  The actual future code hash of a para.
        /// 
        ///  Corresponding code can be retrieved with [`CodeByHash`].
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Hash> FutureCodeHashAsync(Id key, CancellationToken token);

        /// <summary>
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
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<EnumUpgradeGoAhead> UpgradeGoAheadSignalAsync(Id key, CancellationToken token);

        /// <summary>
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
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<EnumUpgradeRestriction> UpgradeRestrictionSignalAsync(Id key, CancellationToken token);

        /// <summary>
        ///  The list of parachains that are awaiting for their upgrade restriction to cooldown.
        /// 
        ///  Ordered ascending by block number.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<BaseTuple<Id, U32>>> UpgradeCooldownsAsync(CancellationToken token);

        /// <summary>
        ///  The list of upcoming code upgrades. Each item is a pair of which para performs a code
        ///  upgrade and at which relay-chain block it is expected at.
        /// 
        ///  Ordered ascending by block number.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<BaseTuple<Id, U32>>> UpcomingUpgradesAsync(CancellationToken token);

        /// <summary>
        /// The actions to perform during the start of a specific session index.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<Id>> ActionsQueueAsync(U32 key, CancellationToken token);

        /// <summary>
        ///  Upcoming paras instantiation arguments.
        /// 
        ///  NOTE that after PVF pre-checking is enabled the para genesis arg will have it's code set
        ///  to empty. Instead, the code will be saved into the storage right away via `CodeByHash`.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<ParaGenesisArgs> UpcomingParasGenesisAsync(Id key, CancellationToken token);

        /// <summary>
        /// The number of reference on the validation code in [`CodeByHash`] storage.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> CodeByHashRefsAsync(Hash key, CancellationToken token);

        /// <summary>
        ///  Validation code stored by its hash.
        /// 
        ///  This storage is consistent with [`FutureCodeHash`], [`CurrentCodeHash`] and
        ///  [`PastCodeHash`].
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<DataCode> CodeByHashAsync(Hash key, CancellationToken token);
    }
}
