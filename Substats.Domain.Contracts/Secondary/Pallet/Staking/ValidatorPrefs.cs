﻿using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class ValidatorPrefs : BaseType
    {
        public Perbill Commission { get; set; }
        public Bool Blocked { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Commission.Encode());
            result.AddRange(Blocked.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Commission = new Perbill();
            Commission.Decode(byteArray, ref p);
            Blocked = new Ajuna.NetApi.Model.Types.Primitive.Bool();
            Blocked.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
