using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Vesting.Enums
{
    public enum Error
    {

        NotVesting = 0,

        AtMaxVestingSchedules = 1,

        AmountLow = 2,

        ScheduleIndexOutOfBounds = 3,

        InvalidScheduleParams = 4,
    }

    /// <summary>
    /// >> 565 - Variant[pallet_vesting.pallet.Error]
    /// Error for the vesting pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
