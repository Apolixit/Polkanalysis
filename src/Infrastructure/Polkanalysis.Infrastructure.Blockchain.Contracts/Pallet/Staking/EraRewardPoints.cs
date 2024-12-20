﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking
{
    public class EraRewardPoints : BaseType
    {
        public U32 Total { get; set; }
        public BaseVec<BaseTuple<SubstrateAccount, U32>> Individual { get; set; }

        public EraRewardPoints() { }

        public EraRewardPoints(U32 total, BaseVec<BaseTuple<SubstrateAccount, U32>> individual)
        {
            Create(total, individual);
        }

        public void Create(U32 total, BaseVec<BaseTuple<SubstrateAccount, U32>> individual)
        {
            Total = total;
            Individual = individual;

            Bytes = Encode();
            TypeSize = Total.TypeSize + Individual.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Total.Encode());
            result.AddRange(Individual.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Total = new U32();
            Total.Decode(byteArray, ref p);
            Individual = new BaseVec<BaseTuple<SubstrateAccount, U32>>();
            Individual.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
