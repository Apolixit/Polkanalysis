﻿using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Origin.Enums
{
    [DomainMapping("polkadot_runtime_parachains/origin/pallet")]
    public enum Origin
    {

        Parachain = 0,
    }

    /// <summary>
    /// >> 260 - Variant[polkadot_runtime_parachains.origin.pallet.Origin]
    /// </summary>
    public sealed class EnumOrigin : BaseEnumExt<Origin, Id>
    {
    }
}
