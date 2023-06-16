using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using BalancesStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.BalancesStorage;
using Polkanalysis.Infrastructure.Blockchain.Mapper;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    /// <summary>
    /// Balances storage mapping from Polkadot blockchain to Domain
    /// Mapping is define from <see cref="PolkadotMapping.BalancesStorageProfile"/>
    /// </summary>
    public class BalancesStorage : MainStorage, IBalancesStorage
    {
        public BalancesStorage(SubstrateClientExt client, ILogger logger) : base(client, logger)
        {
        }

        public async Task<AccountData> AccountAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = PolkadotMapping.Instance.Map<SubstrateAccount, AccountId32>(account);

            return await GetStorageWithParamsAsync<
                AccountId32,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.AccountData,
                AccountData>
                (accountId32, BalancesStorageExt.AccountParams, token);
        }

        public async Task<U128> InactiveIssuanceAsync(CancellationToken token)
        {
            return await GetStorageAsync<U128>(BalancesStorageExt.InactiveIssuanceParams, token);
        }

        public async Task<BaseVec<BalanceLock>> LocksAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = PolkadotMapping.Instance.Map<SubstrateAccount, AccountId32>(account);

            return await GetStorageWithParamsAsync<
                AccountId32,
                WeakBoundedVecT3,
                BaseVec<BalanceLock>>
                (accountId32, BalancesStorageExt.LocksParams, token);
        }

        public async Task<BaseVec<ReserveData>> ReservesAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = PolkadotMapping.Instance.Map<SubstrateAccount, AccountId32>(account);

            return await GetStorageWithParamsAsync<
                AccountId32,
                BoundedVecT6,
                BaseVec<ReserveData>>
                (accountId32, BalancesStorageExt.ReservesParams, token);

            //var res = await GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT6>(BalancesStorageExt.ReservesParams(accountId32), token);

            //return SubstrateMapper.Instance.Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT6, BaseVec<ReserveData>>(res);
        }

        public async Task<U128> TotalIssuanceAsync(CancellationToken token)
        {
            return await GetStorageAsync<U128>(BalancesStorageExt.TotalIssuanceParams, token);
        }
    }
}
