using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Public;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session
{
    public class SessionKeysAura : SessionKeys
    {
        public Public Aura { get; set; }

        public override IEnumerable<(string name, Public key)> Publics => new List<(string, Public)>()
        {
            ("Aura", Aura)
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
