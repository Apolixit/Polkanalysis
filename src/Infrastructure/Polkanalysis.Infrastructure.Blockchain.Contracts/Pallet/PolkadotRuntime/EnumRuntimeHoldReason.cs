﻿using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime
{
    [DomainMapping("polkadot_runtime")]
    public enum RuntimeHoldReason
    {

    }

    public sealed class EnumRuntimeHoldReason : BaseEnum<RuntimeHoldReason>
    {
    }
}
