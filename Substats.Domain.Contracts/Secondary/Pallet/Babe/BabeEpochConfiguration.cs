﻿using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Babe
{
    public class BabeEpochConfiguration : BaseType
    {
        public BaseTuple<U64, U64> C { get; set; }
        public EnumAllowedSlots AllowedSlots { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(C.Encode());
            result.AddRange(AllowedSlots.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            C = new BaseTuple<U64, U64>();
            C.Decode(byteArray, ref p);
            AllowedSlots = new EnumAllowedSlots();
            AllowedSlots.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
