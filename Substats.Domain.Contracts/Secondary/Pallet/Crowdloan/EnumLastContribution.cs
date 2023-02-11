﻿using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Crowdloan
{
    public enum LastContribution
    {

        Never = 0,

        PreEnding = 1,

        Ending = 2,
    }

    public sealed class EnumLastContribution : BaseEnumExt<LastContribution, BaseVoid, Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>
    {
    }
}