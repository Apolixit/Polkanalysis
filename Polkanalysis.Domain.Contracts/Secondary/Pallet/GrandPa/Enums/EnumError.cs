using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.GrandPa.Enums
{
    public enum Error
    {

        PauseFailed = 0,

        ResumeFailed = 1,

        ChangePending = 2,

        TooSoon = 3,

        InvalidKeyOwnershipProof = 4,

        InvalidEquivocationProof = 5,

        DuplicateOffenceReport = 6,
    }

    /// <summary>
    /// >> 518 - Variant[pallet_grandpa.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
