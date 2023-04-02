using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Bounties.Enums
{
    public enum Error
    {

        InsufficientProposersBalance = 0,

        InvalidIndex = 1,

        ReasonTooBig = 2,

        UnexpectedStatus = 3,

        RequireCurator = 4,

        InvalidValue = 5,

        InvalidFee = 6,

        PendingPayout = 7,

        Premature = 8,

        HasActiveChildBounty = 9,

        TooManyQueued = 10,
    }

    /// <summary>
    /// >> 594 - Variant[pallet_bounties.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
