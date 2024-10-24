using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Substrate.NetApi;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Storage
{
    public class NominationPoolsStorage : PolkadotAbstractStorage, INominationPoolsStorage
    {
        public NominationPoolsStorage(SubstrateClientExt client, PolkadotMapping mapper, ILogger logger) : base(client, mapper, logger) { }

        public async Task<BondedPoolInner> BondedPoolsAsync(U32 poolId, CancellationToken token)
        {
            return Map<BondedPoolInnerBase, BondedPoolInner>(
                await _client.NominationPoolsStorage.BondedPoolsAsync(poolId, token));
        }

        public async Task<IQueryStorage<U32, BondedPoolInner>> BondedPoolsQueryAsync(CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var sourceKeyType = _client.NominationPoolsStorage.BondedPoolsInputType(version);
            var storageKeyType = BondedPoolInnerBase.TypeByVersion(version);
            var storageFunction = new QueryStorageFunction("NominationPools", "BondedPools", sourceKeyType, storageKeyType);

            return new QueryStorage<U32, BondedPoolInner>(GetAllStorageAsync<U32, BondedPoolInner>, storageFunction);
        }

        public async Task<U32> CounterForBondedPoolsAsync(CancellationToken token)
        {
            return await _client.NominationPoolsStorage.CounterForBondedPoolsAsync(token);
        }

        public async Task<U32> CounterForMetadataAsync(CancellationToken token)
        {
            return await _client.NominationPoolsStorage.CounterForMetadataAsync(token);
        }

        public async Task<U32> CounterForPoolMembersAsync(CancellationToken token)
        {
            return await _client.NominationPoolsStorage.CounterForPoolMembersAsync(token);
        }

        public async Task<U32> CounterForReversePoolIdLookupAsync(CancellationToken token)
        {
            return await _client.NominationPoolsStorage.CounterForReversePoolIdLookupAsync(token);
        }

        public async Task<U32> CounterForRewardPoolsAsync(CancellationToken token)
        {
            return await _client.NominationPoolsStorage.CounterForRewardPoolsAsync(token);
        }

        public async Task<U32> CounterForSubPoolsStorageAsync(CancellationToken token)
        {
            return await _client.NominationPoolsStorage.CounterForSubPoolsStorageAsync(token);
        }

        public async Task<U32> LastPoolIdAsync(CancellationToken token)
        {
            return await _client.NominationPoolsStorage.LastPoolIdAsync(token);
        }

        public async Task<U32> MaxPoolMembersAsync(CancellationToken token)
        {
            return await _client.NominationPoolsStorage.MaxPoolMembersAsync(token);
        }

        public async Task<U32> MaxPoolMembersPerPoolAsync(CancellationToken token)
        {
            return await _client.NominationPoolsStorage.MaxPoolMembersPerPoolAsync(token);
        }

        public async Task<U32> MaxPoolsAsync(CancellationToken token)
        {
            return await _client.NominationPoolsStorage.MaxPoolsAsync(token);
        }

        public async Task<FlexibleNameable> MetadataAsync(U32 key, CancellationToken token)
        {
            return Map<IType, FlexibleNameable>(await _client.NominationPoolsStorage.MetadataAsync(key, token));
        }

        public async Task<U128> MinCreateBondAsync(CancellationToken token)
        {
            return await _client.NominationPoolsStorage.MinCreateBondAsync(token);
        }

        public async Task<U128> MinJoinBondAsync(CancellationToken token)
        {
            return await _client.NominationPoolsStorage.MinJoinBondAsync(token);
        }

        public async Task<PoolMember> PoolMembersAsync(SubstrateAccount account, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            if (!_client.NominationPoolsStorage.PoolMembersAvailableVersions(version)) return null;

            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<PoolMemberBase, PoolMember>(
                await _client.NominationPoolsStorage.PoolMembersAsync(accountId32, token));
        }

        public async Task<IQueryStorage<SubstrateAccount, PoolMember>> PoolMembersQueryAsync(CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            var sourceKeyType = _client.NominationPoolsStorage.PoolMembersInputType(version);
            var storageKeyType = PoolMemberBase.TypeByVersion(version);
            var storageFunction = new QueryStorageFunction("NominationPools", "PoolMembers", sourceKeyType, storageKeyType, 32);

            return new QueryStorage<SubstrateAccount, PoolMember>(GetAllStorageAsync<SubstrateAccount, PoolMember>, storageFunction);
        }

        public async Task<U32> ReversePoolIdLookupAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return await _client.NominationPoolsStorage.ReversePoolIdLookupAsync(accountId32, token);
        }

        public async Task<RewardPool> RewardPoolsAsync(U32 poolId, CancellationToken token)
        {
            return Map<RewardPoolBase, RewardPool>(
                await _client.NominationPoolsStorage.RewardPoolsAsync(poolId, token));
        }

        public async Task<SubPools> SubPoolsStorageAsync(U32 key, CancellationToken token)
        {
            return Map<SubPoolsBase, SubPools>(
                await _client.NominationPoolsStorage.SubPoolsStorageAsync(key, token));
        }

        protected static string palletVersionStorage() => RequestGenerator.GetStorage("NominationPools", "PalletVersion", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        public async Task<U16> PalletVersionAsync(CancellationToken token)
        {
            return await GetStorageAsync<U16>(palletVersionStorage, token);
        }

        public async Task<EnumClaimPermission> ClaimPermissionsAsync(SubstrateAccount key, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(key, token);
            return Map<IType, EnumClaimPermission>(
                await _client.NominationPoolsStorage.ClaimPermissionsAsync(accountId32, token));
        }

        public async Task<Perbill> GlobalMaxCommissionAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase, Perbill>(
                await _client.NominationPoolsStorage.GlobalMaxCommissionAsync(token));
        }
    }
}
