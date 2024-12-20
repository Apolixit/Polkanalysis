﻿using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums
{
    [DomainMapping("pallet_nomination_pools")]
    public enum PoolState
    {

        Open = 0,

        Blocked = 1,

        Destroying = 2,
    }

    /// <summary>
    /// >> 91 - Variant[pallet_nomination_pools.PoolState]
    /// </summary>
    public sealed class EnumPoolState : BaseEnum<PoolState>
    {
        public EnumPoolState() { }

        public EnumPoolState(PoolState value)
        {
            Create(value);
        }
    }
}
