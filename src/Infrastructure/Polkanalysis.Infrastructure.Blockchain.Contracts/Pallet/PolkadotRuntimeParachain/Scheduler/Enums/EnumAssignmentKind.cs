﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Public;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Scheduler.Enums
{
    [DomainMapping("polkadot_runtime_parachains/scheduler")]
    public enum AssignmentKind
    {

        Parachain = 0,

        Parathread = 1,
    }

    /// <summary>
    /// >> 665 - Variant[polkadot_runtime_parachains.scheduler.AssignmentKind]
    /// </summary>
    public sealed class EnumAssignmentKind : BaseEnumExt<AssignmentKind, BaseVoid, BaseTuple<PublicSr25519, U32>>
    {
    }
}
