using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Vesting.Enums
{
    public enum Releases
    {

        V0 = 0,

        V1 = 1,
    }

    /// <summary>
    /// >> 564 - Variant[pallet_vesting.Releases]
    /// </summary>
    public sealed class EnumReleases : BaseEnum<Releases>
    {
    }
}
