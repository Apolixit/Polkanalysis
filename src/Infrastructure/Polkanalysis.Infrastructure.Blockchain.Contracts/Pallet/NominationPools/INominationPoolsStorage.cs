﻿using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools
{
    /// <summary>
    /// https://docs.rs/pallet-nomination-pools/latest/pallet_nomination_pools/
    /// </summary>
    public interface INominationPoolsStorage : IPalletStorage
    {
        /// <summary>
        /// >> ClaimPermissions
        ///  Map from a pool member account to their opted claim permission.
        /// </summary>
        Task<EnumClaimPermission> ClaimPermissionsAsync(SubstrateAccount key, CancellationToken token);
        /// <summary>
        /// Minimum amount to bond to join a pool.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U128> MinJoinBondAsync(CancellationToken token);

        /// <summary>
        ///  Minimum bond required to create a pool.
        /// 
        ///  This is the amount that the depositor must put as their initial stake in the pool, as an
        ///  indication of "skin in the game".
        /// 
        ///  This is the value that will always exist in the staking ledger of the pool bonded account
        ///  while all other accounts leave.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U128> MinCreateBondAsync(CancellationToken token);

        /// <summary>
        ///  Maximum number of nomination pools that can exist. If `None`, then an unbounded number of
        ///  pools can exist.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> MaxPoolsAsync(CancellationToken token);

        /// <summary>
        ///  Maximum number of members that can exist in the system. If `None`, then the count
        ///  members are not bound on a system wide basis.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> MaxPoolMembersAsync(CancellationToken token);

        /// <summary>
        ///  Maximum number of members that may belong to pool. If `None`, then the count of
        ///  members is not bound on a per pool basis.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> MaxPoolMembersPerPoolAsync(CancellationToken token);

        /// <summary>
        /// Counter for the related counted storage map
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> CounterForPoolMembersAsync(CancellationToken token);

        /// <summary>
        /// Counter for the related counted storage map
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> CounterForBondedPoolsAsync(CancellationToken token);

        /// <summary>
        ///  Active members.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<PoolMember> PoolMembersAsync(SubstrateAccount account, CancellationToken token);

        /// <summary>
        /// All active members in pool
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IQueryStorage<SubstrateAccount, PoolMember>> PoolMembersQueryAsync(CancellationToken token);

        /// <summary>
        ///  Storage for bonded pools.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BondedPoolInner> BondedPoolsAsync(U32 poolId, CancellationToken token);


        /// <summary>
        /// Get all bounded pools
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IQueryStorage<U32, BondedPoolInner>> BondedPoolsQueryAsync(CancellationToken token);

        /// <summary>
        ///  Reward pools. This is where there rewards for each pool accumulate. When a members payout
        ///  is claimed, the balance comes out fo the reward pool. Keyed by the bonded pools account.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<RewardPool> RewardPoolsAsync(U32 poolId, CancellationToken token);

        /// <summary>
        /// Counter for the related counted storage map
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> CounterForRewardPoolsAsync(CancellationToken token);

        /// <summary>
        ///  Groups of unbonding pools. Each group of unbonding pools belongs to a bonded pool,
        ///  hence the name sub-pools. Keyed by the bonded pools account.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<SubPools> SubPoolsStorageAsync(U32 key, CancellationToken token);

        /// <summary>
        /// Counter for the related counted storage map
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> CounterForSubPoolsStorageAsync(CancellationToken token);

        /// <summary>
        /// >> GlobalMaxCommission
        ///  The maximum commission that can be charged by a pool. Used on commission payouts to bound
        ///  pool commissions that are > `GlobalMaxCommission`, necessary if a future
        ///  `GlobalMaxCommission` is lower than some current pool commissions.
        /// </summary>
        public Task<Perbill> GlobalMaxCommissionAsync(CancellationToken token);

        /// <summary>
        /// Metadata for the pool.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<FlexibleNameable> MetadataAsync(U32 key, CancellationToken token);

        /// <summary>
        /// Counter for the related counted storage map
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> CounterForMetadataAsync(CancellationToken token);

        /// <summary>
        /// Ever increasing number of all pools created so far.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> LastPoolIdAsync(CancellationToken token);

        /// <summary>
        ///  A reverse lookup from the pool's account id to its id.
        /// 
        ///  This is only used for slashing. In all other instances, the pool id is used, and the
        ///  accounts are deterministically derived from it.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> ReversePoolIdLookupAsync(SubstrateAccount account, CancellationToken token);

        /// <summary>
        /// Counter for the related counted storage map
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> CounterForReversePoolIdLookupAsync(CancellationToken token);

        public Task<U16> PalletVersionAsync(CancellationToken token);
    }
}
