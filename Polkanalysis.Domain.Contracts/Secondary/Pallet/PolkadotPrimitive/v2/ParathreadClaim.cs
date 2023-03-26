using Ajuna.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotPrimitive.v2
{
    public class ParathreadClaim : BaseType
    {
        public Id Id { get; set; }
        public PublicSr25519 CollatorId { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(CollatorId.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new Id();
            Id.Decode(byteArray, ref p);
            CollatorId = new PublicSr25519();
            CollatorId.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
