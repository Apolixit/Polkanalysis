using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System
{
    public interface ISystemStorage : IPalletStorage
    {
        /// <summary>
        /// The full account information for a particular account ID.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<AccountInfo> AccountAsync(SubstrateAccount account, CancellationToken token);

        /// <summary>
        /// Full information from each account
        /// </summary>
        /// <returns></returns>
        public Task<IQueryStorage<SubstrateAccount, AccountInfo>> AccountsQueryAsync(CancellationToken token);

        /// <summary>
        /// Total extrinsics count for the current block.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> ExtrinsicCountAsync(CancellationToken token);

        /// <summary>
        /// The current weight for the block.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<FrameSupportDispatchPerDispatchClassWeight> BlockWeightAsync(CancellationToken token);

        /// <summary>
        /// Total length (in bytes) for all extrinsics put together, for the current block.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> AllExtrinsicsLenAsync(CancellationToken token);

        /// <summary>
        /// Map of block numbers to block hashes.
        /// </summary>
        /// <param name="blockId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Hash> BlockHashAsync(U32 blockId, CancellationToken token);

        /// <summary>
        /// Extrinsics data for the current block (maps an extrinsic's index to its data).
        /// </summary>
        /// <param name="extrinsicId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<U8>> ExtrinsicDataAsync(U32 extrinsicId, CancellationToken token);

        /// <summary>
        /// The current block number being processed. Set by `execute_block`.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> NumberAsync(CancellationToken token);

        /// <summary>
        /// Hash of the previous block.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Hash> ParentHashAsync(CancellationToken token);

        /// <summary>
        /// Digest of the current block, also part of the block header.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Digest> DigestAsync(CancellationToken token);

        /// <summary>
        ///  Events deposited for the current block.
        /// 
        ///  NOTE: The item is unbound and should therefore never be read on chain.
        ///  It could otherwise inflate the PoV size of a block.
        /// 
        ///  Events have a large in-memory size. Box the events to not go out-of-memory
        ///  just in case someone still reads them from within the runtime.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<EventRecord>> EventsAsync(CancellationToken token);

        /// <summary>
        /// The number of events in the `Events<T>` list.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> EventCountAsync(CancellationToken token);

        /// <summary>
        ///  Mapping between a topic (represented by T::Hash) and a vector of indexes
        ///  of events in the `<Events<T>>` list.
        /// 
        ///  All topic vectors have deterministic storage locations depending on the topic. This
        ///  allows light-clients to leverage the changes trie storage tracking mechanism and
        ///  in case of changes fetch the list of events of interest.
        /// 
        ///  The value has the type `(T::BlockNumber, EventIndex)` because if we used only just
        ///  the `EventIndex` then in case if the topic has the same contents on the next block
        ///  no notification will be triggered thus the event might be lost.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<BaseTuple<U32, U32>>> EventTopicsAsync(Hash key, CancellationToken token);

        /// <summary>
        /// Stores the `spec_version` and `spec_name` of when the last runtime upgrade happened.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<LastRuntimeUpgradeInfo> LastRuntimeUpgradeAsync(CancellationToken token);

        /// <summary>
        /// Subscribe for each new runtime upgrade
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task SubscribeNewLastRuntimeUpgradeAsync(Action<LastRuntimeUpgradeInfo> callback, CancellationToken token);

        /// <summary>
        /// True if we have upgraded so that `type RefCount` is `u32`. False (default) if not.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Bool> UpgradedToU32RefCountAsync(CancellationToken token);

        /// <summary>
        ///  True if we have upgraded so that AccountInfo contains three types of `RefCount`. False
        ///  (default) if not.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Bool> UpgradedToTripleRefCountAsync(CancellationToken token);

        /// <summary>
        /// The execution phase of the block.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<EnumPhase> ExecutionPhaseAsync(CancellationToken token);
    }
}
