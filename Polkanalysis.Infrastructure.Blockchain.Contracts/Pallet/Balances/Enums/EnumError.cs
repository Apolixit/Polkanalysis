using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums
{
    public enum Error
    {

        VestingBalance = 0,

        LiquidityRestrictions = 1,

        InsufficientBalance = 2,

        ExistentialDeposit = 3,

        KeepAlive = 4,

        ExistingVestingSchedule = 5,

        DeadAccount = 6,

        TooManyReserves = 7,
    }

    /// <summary>
    /// >> 477 - Variant[pallet_balances.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
