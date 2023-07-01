using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking.Enums
{
    public enum Forcing
    {

        NotForcing = 0,

        ForceNew = 1,

        ForceNone = 2,

        ForceAlways = 3,
    }

    /// <summary>
    /// >> 498 - Variant[pallet_staking.Forcing]
    /// </summary>
    public sealed class EnumForcing : BaseEnum<Forcing>
    {
    }
}
