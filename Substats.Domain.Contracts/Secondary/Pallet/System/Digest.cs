﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;

namespace Substats.Domain.Contracts.Secondary.Pallet.SystemCore
{
    public class Digest : BaseType
    {
        public BaseVec<EnumDigestItem> Logs { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Logs.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Logs = new BaseVec<EnumDigestItem>();
            Logs.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
