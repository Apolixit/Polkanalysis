﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Paras.Enums
{
    [DomainMapping("polkadot_runtime_parachains/paras/pallet")]
    public enum Event
    {

        CurrentCodeUpdated = 0,

        CurrentHeadUpdated = 1,

        CodeUpgradeScheduled = 2,

        NewHeadNoted = 3,

        ActionQueued = 4,

        PvfCheckStarted = 5,

        PvfCheckAccepted = 6,

        PvfCheckRejected = 7,
    }

    /// <summary>
    /// >> 107 - Variant[polkadot_runtime_parachains.paras.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Id, Id, Id, Id, BaseTuple<Id, U32>, BaseTuple<Hash, Id>, BaseTuple<Hash, Id>, BaseTuple<Hash, Id>>
    {
    }
}
