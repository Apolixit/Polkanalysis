﻿using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core.Hash
{
    public class Hash
    {
        public required string Value { get; set; }

        public Ajuna.NetApi.Model.Types.Base.Hash AjunaHash { get; set; }
    }
}