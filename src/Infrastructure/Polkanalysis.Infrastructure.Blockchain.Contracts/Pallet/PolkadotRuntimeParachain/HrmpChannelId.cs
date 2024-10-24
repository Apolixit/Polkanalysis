using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain
{
    public class HrmpChannelId : BaseType
    {
        public Id Sender { get; set; }
        public Id Recipient { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Sender.Encode());
            result.AddRange(Recipient.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Sender = new Id();
            Sender.Decode(byteArray, ref p);
            Recipient = new Id();
            Recipient.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
