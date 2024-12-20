﻿using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Signature
{
    public class SignatureSr25519 : Signature
    {

        public override KeyType Key => KeyType.Sr25519;

        //public SignatureSr25519() : this(new U8[] { }) { }
        public SignatureSr25519() : base() { }
        public SignatureSr25519(U8[] value) : base(value)
        {
        }

        public SignatureSr25519(string hex) : base(Utils.HexToByteArray(hex).Select(x => new U8(x)).ToArray())
        {
        }
    }
}
