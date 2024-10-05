using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.PeopleChain.NetApiExt.Generated;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain.Storage
{
    public class BalancesStorage : PeopleChainAbstractStorage, IBalancesStorage
    {
        public BalancesStorage(SubstrateClientExt client, PeopleChainMapping mapper, ILogger logger) : base(client, mapper, logger)
        {
        }

        public async Task<AccountData> AccountAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(account, token);

            return Map<IType, AccountData>(await _client.BalancesStorage.AccountAsync(accountId32, token));
        }

        public async Task<BaseVec<IdAmount>> FreezesAsync(SubstrateAccount key, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(key, token);
            return Map<IType, BaseVec<IdAmount>>(await _client.BalancesStorage.FreezesAsync(accountId32, token));
        }

        public async Task<BaseVec<IdAmount>> HoldsAsync(SubstrateAccount key, CancellationToken token)
        {
            var accountId32 = await MapAccoundId32Async(key, token);
            return Map<IType, BaseVec<IdAmount>>(await _client.BalancesStorage.HoldsAsync(accountId32, token));
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
            throw new InvalidOperationException($"{nameof(StorageVersionAsync)} does not exists in the Balances pallet of PeopleChain");
        }

        public async Task<U128> TotalIssuanceAsync(CancellationToken token)
        {
            return await _client.BalancesStorage.TotalIssuanceAsync(token);
        }
    }
}
