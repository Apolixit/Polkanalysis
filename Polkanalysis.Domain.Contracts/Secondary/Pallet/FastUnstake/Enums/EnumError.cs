using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.FastUnstake.Enums
{
    public enum Error
    {

        NotController = 0,

        AlreadyQueued = 1,

        NotFullyBonded = 2,

        NotQueued = 3,

        AlreadyHead = 4,

        CallNotAllowed = 5,
    }

    /// <summary>
    /// >> 637 - Variant[pallet_fast_unstake.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
