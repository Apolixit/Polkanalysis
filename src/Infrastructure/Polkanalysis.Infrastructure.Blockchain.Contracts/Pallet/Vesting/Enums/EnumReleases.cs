﻿using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Vesting.Enums
{
    [DomainMapping("pallet_vesting")]
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
