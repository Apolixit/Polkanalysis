using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.MessageQueue.Enums
{
    [DomainMapping("pallet_message_queue/pallet")]
    public enum Error
    {
        NotReapable = 0,
        NoPage = 1,
        NoMessage = 2,
        AlreadyProcessed = 3,
        Queued = 4,
        InsufficientWeight = 5,
        TemporarilyUnprocessable = 6
    }

    /// <summary>
    /// >> 15544 - Variant[pallet_message_queue.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
