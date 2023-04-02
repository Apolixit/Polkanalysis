using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeParachain
{
    public class CandidateReceipt : BaseType
    {
        public CandidateDescriptor Descriptor { get; set; }
        public Hash CommitmentsHash { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Descriptor.Encode());
            result.AddRange(CommitmentsHash.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Descriptor = new CandidateDescriptor();
            Descriptor.Decode(byteArray, ref p);
            CommitmentsHash = new Hash();
            CommitmentsHash.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
