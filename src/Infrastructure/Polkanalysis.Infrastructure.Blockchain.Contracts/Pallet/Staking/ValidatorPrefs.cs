﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking
{
    public class ValidatorPrefs : BaseType
    {
        public BaseCom<Perbill> Commission { get; set; }
        public Bool Blocked { get; set; }

        public ValidatorPrefs() { }

        public ValidatorPrefs(BaseCom<Perbill> commission, Bool blocked)
        {
            Create(commission, blocked);
        }

        public void Create(BaseCom<Perbill> commission, Bool blocked)
        {
            Commission = commission;
            Blocked = blocked;

            Bytes = Encode();
            TypeSize = Commission.TypeSize + Blocked.TypeSize;
        }

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
            Commission = new BaseCom<Perbill>();
            Commission.Decode(byteArray, ref p);
            Blocked = new Bool();
            Blocked.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
