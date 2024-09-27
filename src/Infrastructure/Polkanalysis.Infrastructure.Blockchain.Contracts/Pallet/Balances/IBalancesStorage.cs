using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances
{
    public interface IBalancesStorage : IPalletStorage
    {
        /// <summary>
        ///  The total units issued in the system.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U128> TotalIssuanceAsync(CancellationToken token);

        /// <summary>
        /// The total units of outstanding deactivated balance in the system.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U128> InactiveIssuanceAsync(CancellationToken token);

        /// <summary>
        ///  The Balances pallet example of storing the balance of an account.
        /// 
        ///  # Example
        /// 
        ///  ```nocompile
        ///   impl pallet_balances::Config for Runtime {
        ///     type AccountStore = StorageMapShim<Self::Account<Runtime>, frame_system::Provider<Runtime>, AccountId, Self::AccountData<Balance>>
        ///   }
        ///  ```
        /// 
        ///  You can also store the balance of an account in the `System` pallet.
        /// 
        ///  # Example
        /// 
        ///  ```nocompile
        ///   impl pallet_balances::Config for Runtime {
        ///    type AccountStore = System
        ///   }
        ///  ```
        /// 
        ///  But this comes with tradeoffs, storing account balances in the system pallet stores
        ///  `frame_system` data alongside the account data contrary to storing account balances in the
        ///  `Balances` pallet, which uses a `StorageMap` to store balances data only.
        ///  NOTE: This is only used in the case that this pallet is used to store balances.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<AccountData> AccountAsync(SubstrateAccount account, CancellationToken token);


        /// <summary>
        /// >> Freezes
        ///  Freeze locks on account balances.
        /// </summary>
        public Task<BaseVec<IdAmount>> FreezesAsync(SubstrateAccount key, CancellationToken token);


        /// <summary>
        /// >> Holds
        ///  Holds on account balances.
        /// </summary>
        public Task<BaseVec<IdAmount>> HoldsAsync(SubstrateAccount key, CancellationToken token);

        /// <summary>
        ///  Any liquidity locks on some account balances.
        ///  NOTE: Should only be accessed when setting, changing and freeing a lock.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<BalanceLock>> LocksAsync(SubstrateAccount account, CancellationToken token);

        /// <summary>
        /// Named reserves on some account balances.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<ReserveData>> ReservesAsync(SubstrateAccount account, CancellationToken token);

        /// <summary>
        /// >> StorageVersion
        ///  Storage version of the pallet.
        /// 
        ///  This is set to v2.0.0 for new networks.
        /// </summary>
        public Task<EnumReleases> StorageVersionAsync(CancellationToken token);
    };
}
