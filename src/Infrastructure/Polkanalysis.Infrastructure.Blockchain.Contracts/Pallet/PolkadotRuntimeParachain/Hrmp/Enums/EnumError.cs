using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Hrmp.Enums
{
    [DomainMapping("polkadot_runtime_parachains/hrmp/pallet")]
    public enum Error
    {

        OpenHrmpChannelToSelf = 0,

        OpenHrmpChannelInvalidRecipient = 1,

        OpenHrmpChannelZeroCapacity = 2,

        OpenHrmpChannelCapacityExceedsLimit = 3,

        OpenHrmpChannelZeroMessageSize = 4,

        OpenHrmpChannelMessageSizeExceedsLimit = 5,

        OpenHrmpChannelAlreadyExists = 6,

        OpenHrmpChannelAlreadyRequested = 7,

        OpenHrmpChannelLimitExceeded = 8,

        AcceptHrmpChannelDoesntExist = 9,

        AcceptHrmpChannelAlreadyConfirmed = 10,

        AcceptHrmpChannelLimitExceeded = 11,

        CloseHrmpChannelUnauthorized = 12,

        CloseHrmpChannelDoesntExist = 13,

        CloseHrmpChannelAlreadyUnderway = 14,

        CancelHrmpOpenChannelUnauthorized = 15,

        OpenHrmpChannelDoesntExist = 16,

        OpenHrmpChannelAlreadyConfirmed = 17,

        WrongWitness = 18,
    }

    /// <summary>
    /// >> 694 - Variant[polkadot_runtime_parachains.hrmp.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
