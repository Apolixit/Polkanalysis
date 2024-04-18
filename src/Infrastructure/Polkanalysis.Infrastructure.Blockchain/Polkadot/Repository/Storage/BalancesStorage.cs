using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    /// <summary>
    /// Balances storage mapping from Polkadot blockchain to Domain
    /// Mapping is define from <see cref="PolkadotMapping.BalancesStorageProfile"/>
    /// </summary>
    public class BalancesStorage : MainStorage, IBalancesStorage
    {

        public BalancesStorage(SubstrateClientExt client, IBlockchainMapping mapper, ILogger logger) : base(client, mapper, logger)
        {
        }

        public async Task<AccountData> AccountAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);

            return Map<IType, AccountData>(await _client.BalancesStorage.AccountAsync(accountId32, token));

            //if(res is Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.AccountDataBase acc1)
            //    return Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.AccountDataBase, AccountData>(acc1);
            //else if(res is Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.types.AccountDataBase acc2)
            //    return PolkadotMapping.Instance.Map<
            //        Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.types.AccountDataBase, AccountData>(acc2);

            //throw new MissingMappingException($"{nameof(AccountAsync)} call does not have mapping");
            //return await GetStorageWithParamsAsync<
            //    AccountId32,
            //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.AccountData,
            //    AccountData>
            //    (accountId32, BalancesStorageExt.AccountParams, token);
        }

        public async Task<IdAmount> FreezesAsync(SubstrateAccount key, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(key, token);
            return Map<IType, IdAmount>(await _client.BalancesStorage.FreezesAsync(accountId32, token));
        }

        public async Task<IdAmount> HoldsAsync(SubstrateAccount key, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(key, token);
            return Map<IType, IdAmount>(await _client.BalancesStorage.HoldsAsync(accountId32, token));
        }

        public async Task<U128> InactiveIssuanceAsync(CancellationToken token)
        {
            return await _client.BalancesStorage.InactiveIssuanceAsync(token);
        }

        public async Task<BaseVec<BalanceLock>> LocksAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            var res = await _client.BalancesStorage.LocksAsync(accountId32, token);

            return await MapWithVersionAsync<IType, BaseVec<BalanceLock>>(res, token);
        }

        public async Task<BaseVec<ReserveData>> ReservesAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);
            return Map<IType, BaseVec<ReserveData>>(await _client.BalancesStorage.ReservesAsync(accountId32, token));
        }

        public async Task<EnumReleases> StorageVersionAsync(CancellationToken token)
        {
            return Map<IType, EnumReleases>(await _client.BalancesStorage.StorageVersionAsync(token));
        }

        public async Task<U128> TotalIssuanceAsync(CancellationToken token)
        {
            return await _client.BalancesStorage.TotalIssuanceAsync(token);
        }
    }
}
