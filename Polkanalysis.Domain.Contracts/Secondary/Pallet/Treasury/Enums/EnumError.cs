using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Treasury.Enums
{
    public enum Error
    {

        InsufficientProposersBalance = 0,

        InvalidIndex = 1,

        TooManyApprovals = 2,

        InsufficientPermission = 3,

        ProposalNotApproved = 4,
    }

    /// <summary>
    /// >> 560 - Variant[pallet_treasury.pallet.Error]
    /// Error for the treasury pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
