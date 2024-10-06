using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Public;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session
{
    public class SessionKeysPolka : SessionKeys
    {
        public PublicEd25519 Grandpa { get; set; }
        public PublicSr25519 Babe { get; set; }
        public PublicSr25519? ImOnline { get; set; }
        public PublicSr25519 ParaValidator { get; set; }
        public PublicSr25519 ParaAssignment { get; set; }
        public PublicSr25519 AuthorityDiscovery { get; set; }
        public PublicEcdsa? Beefy { get; set; }

        public SessionKeysPolka() { }

        public SessionKeysPolka(PublicEd25519 grandpa, PublicSr25519 babe, PublicSr25519 imOnline, PublicSr25519 paraValidator, PublicSr25519 paraAssignment, PublicSr25519 authorityDiscovery)
        {
            Create(grandpa, babe, imOnline, paraValidator, paraAssignment, authorityDiscovery, null);
        }

        public SessionKeysPolka(PublicEd25519 grandpa, PublicSr25519 babe, PublicSr25519? imOnline, PublicSr25519 paraValidator, PublicSr25519 paraAssignment, PublicSr25519 authorityDiscovery, PublicEcdsa? beefy)
        {
            Create(grandpa, babe, imOnline, paraValidator, paraAssignment, authorityDiscovery, beefy);
        }

        public void Create(PublicEd25519 grandpa, PublicSr25519 babe, PublicSr25519? imOnline, PublicSr25519 paraValidator, PublicSr25519 paraAssignment, PublicSr25519 authorityDiscovery, PublicEcdsa? beefy)
        {
            Grandpa = grandpa;
            Babe = babe;
            ImOnline = imOnline;
            ParaValidator = paraValidator;
            ParaAssignment = paraAssignment;
            AuthorityDiscovery = authorityDiscovery;
            Beefy = beefy;

            Bytes = Encode();
            TypeSize = Grandpa.TypeSize + Babe.TypeSize + ImOnline?.TypeSize ?? 0 + ParaValidator.TypeSize + ParaAssignment.TypeSize + AuthorityDiscovery.TypeSize + Beefy?.TypeSize ?? 0;
        }

        public override IEnumerable<(string name, Public key)> Publics => new List<(string, Public)>()
        {
            ("Grandpa", Grandpa),
            ("Babe", Babe),
            ("ImOnline", ImOnline),
            ("ParaValidator", ParaValidator),
            ("ParaAssignment", ParaAssignment),
            ("AuthorityDiscovery", AuthorityDiscovery),
            ("Beefy", Beefy)
        };

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Grandpa.Encode());
            result.AddRange(Babe.Encode());

            if (ImOnline is not null)
                result.AddRange(ImOnline.Encode());

            result.AddRange(ParaValidator.Encode());
            result.AddRange(ParaAssignment.Encode());
            result.AddRange(AuthorityDiscovery.Encode());

            if (Beefy is not null)
                result.AddRange(Beefy.Encode());

            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Grandpa = new PublicEd25519();
            Grandpa.Decode(byteArray, ref p);
            Babe = new PublicSr25519();
            Babe.Decode(byteArray, ref p);
            ImOnline = new PublicSr25519();
            ImOnline.Decode(byteArray, ref p);
            ParaValidator = new PublicSr25519();
            ParaValidator.Decode(byteArray, ref p);
            ParaAssignment = new PublicSr25519();
            ParaAssignment.Decode(byteArray, ref p);
            AuthorityDiscovery = new PublicSr25519();
            AuthorityDiscovery.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
