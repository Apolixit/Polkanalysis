﻿using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.AwesomeAvatars
{
    public class MintFees
    {
        public U128 One { get; set; }
        public U128 Three { get; set; }
        public U128 Six { get; set; }
    }
}
