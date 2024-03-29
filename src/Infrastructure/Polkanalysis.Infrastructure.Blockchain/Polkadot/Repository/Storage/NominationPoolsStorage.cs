﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using NominationStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.NominationPoolsStorage;
using Polkanalysis.Domain.Contracts.Secondary.Common;
using Polkanalysis.Infrastructure.Blockchain.Mapper;
using Substrate.NetApi;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class NominationPoolsStorage : MainStorage, INominationPoolsStorage
    {
        public NominationPoolsStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<BondedPoolInner> BondedPoolsAsync(U32 poolId, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.BondedPoolInner,
                BondedPoolInner>
                (poolId, NominationStorageExt.BondedPoolsParams, token);
        }

        public QueryStorage<U32, BondedPoolInner> BondedPoolsQuery()
        {
            return new QueryStorage<U32, BondedPoolInner>(
                GetAllStorageAsync<U32, U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.BondedPoolInner, BondedPoolInner>, "NominationPools", "BondedPools");
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

        public async Task<BaseVec<U8>> MetadataAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                BoundedVecT28,
                BaseVec<U8>>
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
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.PoolMember,
                PoolMember>
                (PolkadotMapping.Instance.Map<SubstrateAccount, AccountId32>(account),
                NominationStorageExt.PoolMembersParams, token);
        }

        public QueryStorage<SubstrateAccount, PoolMember> PoolMembersQuery()
        {
            return new QueryStorage<SubstrateAccount, PoolMember>(
                GetAllStorageAsync<AccountId32,
                SubstrateAccount,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.PoolMember,
                PoolMember>, "NominationPools", "PoolMembers");
        }

        public async Task<U32> ReversePoolIdLookupAsync(SubstrateAccount account, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<AccountId32, U32>
                (PolkadotMapping.Instance.Map<SubstrateAccount, AccountId32>(account),
                NominationStorageExt.ReversePoolIdLookupParams, token);
        }

        public async Task<RewardPool> RewardPoolsAsync(U32 poolId, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.RewardPool,
                RewardPool>
                (poolId, NominationStorageExt.RewardPoolsParams, token);
        }

        public async Task<SubPools> SubPoolsStorageAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<
                U32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.SubPools,
                SubPools>
                (key, NominationStorageExt.SubPoolsStorageParams, token);
        }

        protected static string palletVersionStorage() => RequestGenerator.GetStorage("NominationPools", "PalletVersion", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        public async Task<U16> PalletVersionAsync(CancellationToken token)
        {
            return await GetStorageAsync<U16>(palletVersionStorage, token);
        }
    }
}
