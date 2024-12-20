﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Auctions
{
    public class Winning : BaseType
    {
        public override int TypeSize { get; set; } = 36;
        public BaseOpt<BaseTuple<SubstrateAccount, Id, U128>>[] Value { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value) { result.AddRange(v.Encode()); };
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var array = new BaseOpt<BaseTuple<SubstrateAccount, Id, U128>>[TypeSize];
            for (var i = 0; i < array.Length; i++) { var t = new BaseOpt<BaseTuple<SubstrateAccount, Id, U128>>(); t.Decode(byteArray, ref p); array[i] = t; };
            var bytesLength = p - start;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
            Value = array;
        }

        public void Create(BaseOpt<BaseTuple<SubstrateAccount, Id, U128>>[] array)
        {
            Value = array;
            Bytes = Encode();
        }
    }
}
