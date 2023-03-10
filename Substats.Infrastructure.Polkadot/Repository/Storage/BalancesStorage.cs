using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.Display;
using Substats.Domain.Contracts.Secondary.Pallet.Balances;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Polkadot.NetApiExt.Generated;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using BalancesStorageExt = Substats.Polkadot.NetApiExt.Generated.Storage.BalancesStorage;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    /// <summary>
    /// Balances storage mapping from Polkadot blockchain to Domain
    /// Mapping is define from <see cref="SubstrateMapper.BalancesStorageProfile"/>
    /// </summary>
    public class BalancesStorage : MainStorage, IBalancesStorage
    {
        public BalancesStorage(SubstrateClientExt client, ILogger logger) : base(client, logger)
        {
        }

        public async Task<AccountData> AccountAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = SubstrateMapper.Instance.Map<SubstrateAccount, AccountId32>(account);

            return await GetStorageWithParamsAsync<
                AccountId32, 
                Substats.Polkadot.NetApiExt.Generated.Model.pallet_balances.AccountData,
                AccountData>
                (accountId32, BalancesStorageExt.AccountParams, token);

            
            //var res = await GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.pallet_balances.AccountData>(BalancesStorageExt.AccountParams(accountId32), token);

            //return SubstrateMapper.Instance.Map<
            //    Substats.Polkadot.NetApiExt.Generated.Model.pallet_balances.AccountData, 
            //    AccountData>(res);
        }

        public async Task<U128> InactiveIssuanceAsync(CancellationToken token)
        {
            return await GetStorageAsync<U128>(BalancesStorageExt.InactiveIssuanceParams, token);
        }

        public async Task<BaseVec<BalanceLock>> LocksAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = SubstrateMapper.Instance.Map<SubstrateAccount, AccountId32>(account);

            return await GetStorageWithParamsAsync<
                AccountId32,
                WeakBoundedVecT3,
                BaseVec<BalanceLock>>
                (accountId32, BalancesStorageExt.LocksParams, token);

            //var res = await GetStorageAsync<WeakBoundedVecT3>(
            //    BalancesStorageExt.LocksParams(accountId32), token);

            ////if (res == null || res.Value == null)
            ////    return new BaseVec<BalanceLock>();
            
            //return SubstrateMapper.Instance.Map<WeakBoundedVecT3, BaseVec<BalanceLock>>(res);
        }

        public async Task<BaseVec<ReserveData>> ReservesAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = SubstrateMapper.Instance.Map<SubstrateAccount, AccountId32>(account);

            return await GetStorageWithParamsAsync<
                AccountId32,
                BoundedVecT6,
                BaseVec<ReserveData>>
                (accountId32, BalancesStorageExt.ReservesParams, token);

            //var res = await GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT6>(BalancesStorageExt.ReservesParams(accountId32), token);

            //return SubstrateMapper.Instance.Map<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT6, BaseVec<ReserveData>>(res);
        }

        public async Task<U128> TotalIssuanceAsync(CancellationToken token)
        {
            return await GetStorageAsync<U128>(BalancesStorageExt.TotalIssuanceParams, token);
        }
    }
}
