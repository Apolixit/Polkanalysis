﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1
{
    public class MultiLocation : BaseType
    {
        public U8 Parents { get; set; }
        public EnumJunctions Interior { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Parents.Encode());
            result.AddRange(Interior.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Parents = new U8();
            Parents.Decode(byteArray, ref p);
            Interior = new EnumJunctions();
            Interior.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
