﻿using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts
{
    public interface ITimeQueryable
    {
        public IStorage Storage { get; }
    }
}
