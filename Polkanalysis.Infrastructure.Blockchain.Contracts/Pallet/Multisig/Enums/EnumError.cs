using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Multisig.Enums
{
    public enum Error
    {

        MinimumThreshold = 0,

        AlreadyApproved = 1,

        NoApprovalsNeeded = 2,

        TooFewSignatories = 3,

        TooManySignatories = 4,

        SignatoriesOutOfOrder = 5,

        SenderInSignatories = 6,

        NotFound = 7,

        NotOwner = 8,

        NoTimepoint = 9,

        WrongTimepoint = 10,

        UnexpectedTimepoint = 11,

        MaxWeightTooLow = 12,

        AlreadyStored = 13,
    }

    /// <summary>
    /// >> 590 - Variant[pallet_multisig.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
