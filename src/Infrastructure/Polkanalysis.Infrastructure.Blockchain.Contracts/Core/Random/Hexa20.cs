﻿using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Random
{
    public class Hexa20 : FlexibleNameable
    {
        public Hexa20()
        {
            IntegerSize = 20;
        }

        public Hexa20(string hex) : this()
        {
            Create(Utils.HexToByteArray(hex));
        }
        public Hexa20(BaseType value) : base(value) { }
        public override string Display()
        {
            return Utils.Bytes2HexString(Value.ToBytes());
        }
    }
}