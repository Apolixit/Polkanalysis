using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums
{
    public enum Error
    {

        TooManySubAccounts = 0,

        NotFound = 1,

        NotNamed = 2,

        EmptyIndex = 3,

        FeeChanged = 4,

        NoIdentity = 5,

        StickyJudgement = 6,

        JudgementGiven = 7,

        InvalidJudgement = 8,

        InvalidIndex = 9,

        InvalidTarget = 10,

        TooManyFields = 11,

        TooManyRegistrars = 12,

        AlreadyClaimed = 13,

        NotSub = 14,

        NotOwned = 15,

        JudgementForDifferentIdentity = 16,

        JudgementPaymentFailed = 17,
    }

    /// <summary>
    /// >> 577 - Variant[pallet_identity.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
