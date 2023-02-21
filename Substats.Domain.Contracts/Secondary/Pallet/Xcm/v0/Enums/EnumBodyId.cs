﻿using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Xcm.v0.Enums
{
    public enum BodyId
    {

        Unit = 0,

        Named = 1,

        Index = 2,

        Executive = 3,

        Technical = 4,

        Legislative = 5,

        Judicial = 6,
    }

    /// <summary>
    /// >> 128 - Variant[xcm.v0.junction.BodyId]
    /// </summary>
    public sealed class EnumBodyId : BaseEnumExt<BodyId, BaseVoid, Nameable, BaseCom<U32>, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
    }
}