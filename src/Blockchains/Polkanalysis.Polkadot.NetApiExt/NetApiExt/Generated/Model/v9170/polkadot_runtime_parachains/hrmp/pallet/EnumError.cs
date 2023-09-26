//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_parachains.hrmp.pallet
{
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
        WrongWitness = 18
    }

    /// <summary>
    /// >> 3131 - Variant[polkadot_runtime_parachains.hrmp.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/v3/runtime/events-and-errors)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}