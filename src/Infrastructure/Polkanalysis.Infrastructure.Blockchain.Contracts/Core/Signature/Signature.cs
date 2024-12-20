﻿using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Signature
{
    public abstract class Signature : BaseType
    {
        // Check length = 64
        public override int TypeSize
        {
            get
            {
                return 64;
            }
        }
        public U8[] Value { get; set; }
        public abstract KeyType Key { get; }

        protected Signature() { }

        protected Signature(U8[] value)
        {
            if (value.Length != TypeSize)
                throw new InvalidOperationException($"Signature should be {TypeSize} bytes but is {value.Length}");

            Value = value;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var array = new U8[TypeSize];
            for (var i = 0; i < array.Length; i++) { var t = new U8(); t.Decode(byteArray, ref p); array[i] = t; };
            var bytesLength = p - start;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
            Value = array;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value) { result.AddRange(v.Encode()); };
            return result.ToArray();
        }
    }
}
