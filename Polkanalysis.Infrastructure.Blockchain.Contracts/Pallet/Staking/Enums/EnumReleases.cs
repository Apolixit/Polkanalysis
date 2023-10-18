using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums
{
    public enum Releases
    {

        V1_0_0Ancient = 0,

        V2_0_0 = 1,

        V3_0_0 = 2,

        V4_0_0 = 3,

        V5_0_0 = 4,

        V6_0_0 = 5,

        V7_0_0 = 6,

        V8_0_0 = 7,

        V9_0_0 = 8,

        V10_0_0 = 9,

        V11_0_0 = 10,

        V12_0_0 = 11,
    }

    /// <summary>
    /// >> 506 - Variant[pallet_staking.Releases]
    /// </summary>
    public sealed class EnumReleases : BaseEnum<Releases>
    {
    }
}
