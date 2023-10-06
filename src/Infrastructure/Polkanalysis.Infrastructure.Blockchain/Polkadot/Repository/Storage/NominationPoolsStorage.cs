using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using NominationStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.NominationPoolsStorage;
using Polkanalysis.Domain.Contracts.Secondary.Common;
using Substrate.NetApi;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Substrate.NetApi.Model.Types.Base.Abstraction;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools.Enums;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    public class NominationPoolsStorage : MainStorage, INominationPoolsStorage
    {
        public NominationPoolsStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<BondedPoolInner> BondedPoolsAsync(U32 poolId, CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.BondedPoolInnerBase, BondedPoolInner>(
                await _client.NominationPoolsStorage.BondedPoolsAsync(poolId, token));
        }

        public QueryStorage<U32, BondedPoolInner> BondedPoolsQuery()
        {
            //return new QueryStorage<U32, BondedPoolInner>(
            //    GetAllStorageAsync<U32, U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.BondedPoolInner, BondedPoolInner>, "NominationPools", "BondedPools");
            throw new NotImplementedException();
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

        public async Task<BaseVec<U8>> MetadataAsync(U32 key, CancellationToken token)
        {
            return Map<IBaseEnumerable, BaseVec<U8>>(await _client.NominationPoolsStorage.MetadataAsync(key, token));
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
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.PoolMemberBase, PoolMember>(
                await _client.NominationPoolsStorage.PoolMembersAsync(accountId32, token));
        }

        public QueryStorage<SubstrateAccount, PoolMember> PoolMembersQuery()
        {
            //return new QueryStorage<SubstrateAccount, PoolMember>(
            //    GetAllStorageAsync<AccountId32,
            //    SubstrateAccount,
            //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.PoolMember,
            //    PoolMember>, "NominationPools", "PoolMembers");
            throw new NotImplementedException();
        }

        public async Task<U32> ReversePoolIdLookupAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return await _client.NominationPoolsStorage.ReversePoolIdLookupAsync(accountId32, token);
        }

        public async Task<RewardPool> RewardPoolsAsync(U32 poolId, CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.RewardPoolBase, RewardPool>(
                await _client.NominationPoolsStorage.RewardPoolsAsync(poolId, token));
        }

        public async Task<SubPools> SubPoolsStorageAsync(U32 key, CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.SubPoolsBase, SubPools>(
                await _client.NominationPoolsStorage.SubPoolsStorageAsync(key, token));
        }

        protected static string palletVersionStorage() => RequestGenerator.GetStorage("NominationPools", "PalletVersion", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        public async Task<U16> PalletVersionAsync(CancellationToken token)
        {
            return await GetStorageAsync<U16>(palletVersionStorage, token);
        }

        public async Task<EnumClaimPermission> ClaimPermissionsAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<IBaseEnum, EnumClaimPermission>(
                await _client.NominationPoolsStorage.ClaimPermissionsAsync(accountId32, token));
        }

        public async Task<Perbill> GlobalMaxCommissionAsync(CancellationToken token)
        {
            return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase, Perbill>(
                await _client.NominationPoolsStorage.GlobalMaxCommissionAsync(token));
        }
    }
}
