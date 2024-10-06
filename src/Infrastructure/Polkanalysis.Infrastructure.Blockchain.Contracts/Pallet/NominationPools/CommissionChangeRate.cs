using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools
{
    public class CommissionChangeRate : BaseType
    {
        public CommissionChangeRate() { }

        public CommissionChangeRate(Perbill maxIncrease, U32 minDelay)
        {
            Create(maxIncrease, minDelay);
        }

        public void Create(Perbill maxIncrease, U32 minDelay)
        {
            MaxIncrease = maxIncrease;
            MinDelay = minDelay;

            Bytes = Encode();
            TypeSize = MaxIncrease.TypeSize + MinDelay.TypeSize;
        }

        public Perbill MaxIncrease { get; set; }
        public U32 MinDelay { get; set; }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            MaxIncrease = new Perbill();
            MaxIncrease.Decode(byteArray, ref p);
            MinDelay = new U32();
            MinDelay.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(MaxIncrease.Encode());
            result.AddRange(MinDelay.Encode());
            return result.ToArray();
        }
    }
}
