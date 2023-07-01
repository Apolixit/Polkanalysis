using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore
{
    public class Weight : BaseType
    {
        public Weight() { }

        public Weight(U64 refTime, U64 proofSize)
        {
            Create(new BaseCom<U64>(new CompactInteger(refTime)), new BaseCom<U64>(new CompactInteger(proofSize)));
        }

        public BaseCom<U64> RefTime { get; set; }
        public BaseCom<U64> ProofSize { get; set; }

        public void Create(BaseCom<U64> refTime, BaseCom<U64> proofSize)
        {
            RefTime = refTime;
            ProofSize = proofSize;

            Bytes = Encode();
            
            TypeSize = RefTime.TypeSize + ProofSize.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(RefTime.Encode());
            result.AddRange(ProofSize.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            RefTime = new BaseCom<U64>();
            RefTime.Decode(byteArray, ref p);
            ProofSize = new BaseCom<U64>();
            ProofSize.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
