﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy
{
    public class PriorLock : BaseType
    {
        public PriorLock() { }

        public PriorLock(U32 blockNumber, U128 balance)
        {
            Create(blockNumber, balance);
        }

        public void Create(U32 blockNumber, U128 balance)
        {
            BlockNumber = blockNumber;
            Balance = balance;

            Bytes = Encode();
            TypeSize = BlockNumber.TypeSize + Balance.TypeSize;
        }

        public U32 BlockNumber { get; set; }
        public U128 Balance { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(BlockNumber.Encode());
            result.AddRange(Balance.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            BlockNumber = new Substrate.NetApi.Model.Types.Primitive.U32();
            BlockNumber.Decode(byteArray, ref p);
            Balance = new Substrate.NetApi.Model.Types.Primitive.U128();
            Balance.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
