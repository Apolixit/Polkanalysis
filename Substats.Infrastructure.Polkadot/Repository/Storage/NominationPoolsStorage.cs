﻿using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.Display;
using Substats.Domain.Contracts.Secondary.Pallet.NominationPools;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Polkadot.NetApiExt.Generated;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using NominationStorageExt = Substats.Polkadot.NetApiExt.Generated.Storage.NominationPoolsStorage;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class NominationPoolsStorage : MainStorage, INominationPoolsStorage
    {
        public NominationPoolsStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<BondedPoolInner> BondedPoolsAsync(U32 poolId, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.BondedPoolInner,
                BondedPoolInner>
                (poolId, NominationStorageExt.BondedPoolsParams, token);
        }

        public async Task<U32> CounterForBondedPoolsAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(NominationStorageExt.CounterForBondedPoolsParams, token);
        }

        public async Task<U32> CounterForMetadataAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(NominationStorageExt.CounterForMetadataParams, token);
        }

        public async Task<U32> CounterForPoolMembersAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(NominationStorageExt.CounterForPoolMembersParams, token);
        }

        public async Task<U32> CounterForReversePoolIdLookupAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(NominationStorageExt.CounterForReversePoolIdLookupParams, token);
        }

        public async Task<U32> CounterForRewardPoolsAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(NominationStorageExt.CounterForRewardPoolsParams, token);
        }

        public async Task<U32> CounterForSubPoolsStorageAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(NominationStorageExt.CounterForSubPoolsStorageParams, token);
        }

        public async Task<U32> LastPoolIdAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(NominationStorageExt.LastPoolIdParams, token);
        }

        public async Task<U32> MaxPoolMembersAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(NominationStorageExt.MaxPoolMembersParams, token);
        }

        public async Task<U32> MaxPoolMembersPerPoolAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(NominationStorageExt.MaxPoolMembersPerPoolParams, token);
        }

        public async Task<U32> MaxPoolsAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(NominationStorageExt.MaxPoolsParams, token);
        }

        public async Task<Nameable> MetadataAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                BoundedVecT28,
                Nameable>
                (key, NominationStorageExt.MetadataParams, token);
        }

        public async Task<U128> MinCreateBondAsync(CancellationToken token)
        {
            return await GetStorageAsync<U128>(NominationStorageExt.MinCreateBondParams, token);
        }

        public async Task<U128> MinJoinBondAsync(CancellationToken token)
        {
            return await GetStorageAsync<U128>(NominationStorageExt.MinJoinBondParams, token);
        }

        public async Task<PoolMember> PoolMembersAsync(SubstrateAccount account, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                AccountId32,
                Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.PoolMember,
                PoolMember>
                (SubstrateMapper.Instance.Map<SubstrateAccount, AccountId32>(account),
                NominationStorageExt.PoolMembersParams, token);
        }

        public async Task<U32> ReversePoolIdLookupAsync(SubstrateAccount account, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<AccountId32, U32>
                (SubstrateMapper.Instance.Map<SubstrateAccount, AccountId32>(account), 
                NominationStorageExt.ReversePoolIdLookupParams, token);
        }

        public async Task<RewardPool> RewardPoolsAsync(U32 poolId, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.RewardPool,
                RewardPool>
                (poolId, NominationStorageExt.RewardPoolsParams, token);
        }

        public async Task<SubPools> SubPoolsStorageAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.SubPools,
                SubPools>
                (key, NominationStorageExt.SubPoolsStorageParams, token);
        }
    }
}
