using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Authorship.Enums
{
    public enum Error
    {

        InvalidUncleParent = 0,

        UnclesAlreadySet = 1,

        TooManyUncles = 2,

        GenesisUncle = 3,

        TooHighUncle = 4,

        UncleAlreadyIncluded = 5,

        OldUncle = 6,
    }

    /// <summary>
    /// >> 483 - Variant[pallet_authorship.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
