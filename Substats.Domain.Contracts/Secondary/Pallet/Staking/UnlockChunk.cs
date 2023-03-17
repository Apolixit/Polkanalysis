﻿
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class UnlockChunk : BaseType
    {
        public BaseCom<U128> Value { get; set; }
        public BaseCom<U32> Era { get; set; }

        public UnlockChunk() { }

        public UnlockChunk(BaseCom<U128> value, BaseCom<U32> era)
        {
            Value = value;
            Era = era;
        }

        public void Create(BaseCom<U128> value, BaseCom<U32> era)
        {
            Value = value;
            Era = era;

            Bytes = Encode();
            TypeSize = Value.TypeSize + Era.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            result.AddRange(Era.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new BaseCom<U128>();
            Value.Decode(byteArray, ref p);
            Era = new BaseCom<U32>();
            Era.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
