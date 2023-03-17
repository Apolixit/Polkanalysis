﻿using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Xcm.Enums
{
    public enum VersionedResponse
    {

        V0 = 0,

        V1 = 1,

        V2 = 2,
    }

    /// <summary>
    /// >> 718 - Variant[xcm.VersionedResponse]
    /// </summary>
    public sealed class EnumVersionedResponse : BaseEnumExt<VersionedResponse, 
        v0.Enums.EnumResponse, 
        v1.Enums.EnumResponse, 
        v2.Enums.EnumResponse>
    {
    }
}
