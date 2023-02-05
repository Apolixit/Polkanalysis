using Ajuna.NetApi.Model.Types;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Balances
{
    public interface IBalancesStorage
    {
        /// <summary>
        ///  The total units issued in the system.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BigInteger> TotalIssuanceAsync(CancellationToken token);

        /// <summary>
        /// The total units of outstanding deactivated balance in the system.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BigInteger> InactiveIssuanceAsync(CancellationToken token);

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
        ///  Any liquidity locks on some account balances.
        ///  NOTE: Should only be accessed when setting, changing and freeing a lock.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IEnumerable<BalanceLock>> LocksAsync(SubstrateAccount account, CancellationToken token);

        /// <summary>
        /// Named reserves on some account balances.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IEnumerable<ReserveData>> ReservesAsync(SubstrateAccount account, CancellationToken token);
    };
}
