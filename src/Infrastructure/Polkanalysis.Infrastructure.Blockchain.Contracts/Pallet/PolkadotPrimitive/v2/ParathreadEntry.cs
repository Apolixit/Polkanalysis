﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v2
{
    public class ParathreadEntry : BaseType
    {
        public ParathreadClaim Claim { get; set; }
        public U32 Retries { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Claim.Encode());
            result.AddRange(Retries.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Claim = new ParathreadClaim();
            Claim.Decode(byteArray, ref p);
            Retries = new U32();
            Retries.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
