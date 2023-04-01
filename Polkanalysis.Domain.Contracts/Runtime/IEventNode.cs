﻿using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Runtime
{
    public interface IEventNode : INode
    {
        public RuntimeEvent Module { get; }
        public Enum Method { get; }
    }
}
