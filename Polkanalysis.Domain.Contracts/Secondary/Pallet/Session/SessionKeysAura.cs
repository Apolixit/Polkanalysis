using Ajuna.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Session
{
    public class SessionKeysAura : SessionKeys
    {
        public Public Aura { get; set; }

        public override IEnumerable<Public> Publics => new List<Public>()
        {
            Aura
        };

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Aura.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Aura = new PublicSr25519();
            Aura.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
