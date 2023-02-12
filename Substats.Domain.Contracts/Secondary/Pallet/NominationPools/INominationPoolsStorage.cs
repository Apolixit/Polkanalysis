using Ajuna.NetApi.Model.Types.Primitive;
using Org.BouncyCastle.Math;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.NominationPools
{
    /// <summary>
    /// https://docs.rs/pallet-nomination-pools/latest/pallet_nomination_pools/
    /// </summary>
    public interface INominationPoolsStorage : IPalletStorage
    {
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
        ///  Storage for bonded pools.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BondedPoolInner> BondedPoolsAsync(U32 poolId, CancellationToken token);

        /// <summary>
        ///  Reward pools. This is where there rewards for each pool accumulate. When a members payout
        ///  is claimed, the balance comes out fo the reward pool. Keyed by the bonded pools account.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<RewardPool> RewardPoolsAsync(U32 poolId, CancellationToken token);
    }
}
