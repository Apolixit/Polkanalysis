﻿using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.ElectionProviderMultiPhase.Enums
{
    public enum Phase
    {

        Off = 0,

        Signed = 1,

        Unsigned = 2,

        Emergency = 3,
    }

    /// <summary>
    /// >> 600 - Variant[pallet_election_provider_multi_phase.Phase]
    /// </summary>
    public sealed class EnumPhase : BaseEnumExt<Phase, BaseVoid, BaseVoid, Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.Bool, Ajuna.NetApi.Model.Types.Primitive.U32>, BaseVoid>
    {
    }
}
