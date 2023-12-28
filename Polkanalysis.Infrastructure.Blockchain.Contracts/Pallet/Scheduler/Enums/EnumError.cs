using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Scheduler.Enums
{
    [DomainMapping("pallet_scheduler/pallet")]
    public enum Error
    {

        FailedToSchedule = 0,

        NotFound = 1,

        TargetBlockNumberInPast = 2,

        RescheduleNoChange = 3,

        Named = 4,
    }

    /// <summary>
    /// >> 450 - Variant[pallet_scheduler.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
