using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Babe.Enums
{
    public enum Error
    {

        InvalidEquivocationProof = 0,

        InvalidKeyOwnershipProof = 1,

        DuplicateOffenceReport = 2,

        InvalidConfiguration = 3,
    }

    /// <summary>
    /// >> 467 - Variant[pallet_babe.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
