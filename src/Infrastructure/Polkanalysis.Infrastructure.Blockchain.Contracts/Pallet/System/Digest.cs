using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System
{
    public class Digest : BaseType
    {
        public Digest() { }

        public Digest(BaseVec<EnumDigestItem> logs)
        {
            Create(logs);
        }

        public BaseVec<EnumDigestItem> Logs { get; set; }

        public void Create(BaseVec<EnumDigestItem> logs)
        {
            Logs = logs;
            Bytes = Encode();

            TypeSize = Logs.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Logs.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Logs = new BaseVec<EnumDigestItem>();
            Logs.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
