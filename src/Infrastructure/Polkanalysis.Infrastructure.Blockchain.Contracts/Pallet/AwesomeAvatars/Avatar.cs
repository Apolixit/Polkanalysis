﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.AwesomeAvatars
{
    public class Avatar
    {
        public U16 SeasonId { get; set; } = new U16();
        public Hash Dna { get; set; } = new Hash();
        public U32 Souls { get; set; } = new U32();
    }
}
