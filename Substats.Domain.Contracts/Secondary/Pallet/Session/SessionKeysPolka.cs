using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Session
{
    public class SessionKeysPolka : SessionKeys
    {
        public PublicEd25519 Grandpa { get; set; }
        public PublicSr25519 Babe { get; set; }
        public PublicSr25519 ImOnline { get; set; }
        public PublicSr25519 ParaValidator { get; set; }
        public PublicSr25519 ParaAssignment { get; set; }
        public PublicSr25519 AuthorityDiscovery { get; set; }

        public SessionKeysPolka() { }

        public SessionKeysPolka(PublicEd25519 grandpa, PublicSr25519 babe, PublicSr25519 imOnline, PublicSr25519 paraValidator, PublicSr25519 paraAssignment, PublicSr25519 authorityDiscovery)
        {
            Grandpa = grandpa;
            Babe = babe;
            ImOnline = imOnline;
            ParaValidator = paraValidator;
            ParaAssignment = paraAssignment;
            AuthorityDiscovery = authorityDiscovery;
        }

        public void Create(PublicEd25519 grandpa, PublicSr25519 babe, PublicSr25519 imOnline, PublicSr25519 paraValidator, PublicSr25519 paraAssignment, PublicSr25519 authorityDiscovery)
        {
            Grandpa = grandpa;
            Babe = babe;
            ImOnline = imOnline;
            ParaValidator = paraValidator;
            ParaAssignment = paraAssignment;
            AuthorityDiscovery = authorityDiscovery;

            Bytes = Encode();
            TypeSize = Grandpa.TypeSize + Babe.TypeSize + ImOnline.TypeSize + ParaValidator.TypeSize + ParaAssignment.TypeSize + AuthorityDiscovery.TypeSize;
        }

        public override IEnumerable<Public> Publics => new List<Public>()
        {
            Grandpa, Babe, ImOnline, ParaValidator, ParaAssignment, AuthorityDiscovery
        };

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Grandpa.Encode());
            result.AddRange(Babe.Encode());
            result.AddRange(ImOnline.Encode());
            result.AddRange(ParaValidator.Encode());
            result.AddRange(ParaAssignment.Encode());
            result.AddRange(AuthorityDiscovery.Encode());
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
