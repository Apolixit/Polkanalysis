﻿using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class IndividualExposure : BaseType
    {
        public SubstrateAccount Who { get; set; }
        public BaseCom<U128> Value { get; set; }

        public IndividualExposure() { }

        public IndividualExposure(SubstrateAccount who, BaseCom<U128> value)
        {
            Create(who, value);
        }

        public void Create(SubstrateAccount who, BaseCom<U128> value)
        {
            Who = who;
            Value = value;

            Bytes = Encode();
            TypeSize = Who.TypeSize + Value.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Who.Encode());
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Who = new SubstrateAccount();
            Who.Decode(byteArray, ref p);
            Value = new BaseCom<U128>();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
