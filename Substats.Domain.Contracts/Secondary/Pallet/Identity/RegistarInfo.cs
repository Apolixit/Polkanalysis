﻿using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Identity
{
    public class RegistarInfo
    {
        public required SubstrateAccount Account { get; set; }
        public required U128 Fee { get; set; }

        public required U64 Fields { get; set; }

    }
}
