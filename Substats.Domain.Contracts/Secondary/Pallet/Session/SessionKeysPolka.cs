using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Session
{
    public class SessionKeysPolka : SessionKeys
    {
        public Public Grandpa { get; set; }
        public Public Babe { get; set; }
        public Public ImOnline { get; set; }
        public Public ParaValidator { get; set; }
        public Public ParaAssignment { get; set; }
        public Public AuthorityDiscovery { get; set; }

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
            Grandpa = new Substats.Polkadot.NetApiExt.Generated.Model.sp_finality_grandpa.app.Public();
            Grandpa.Decode(byteArray, ref p);
            Babe = new Substats.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.app.Public();
            Babe.Decode(byteArray, ref p);
            ImOnline = new Substats.Polkadot.NetApiExt.Generated.Model.pallet_im_online.sr25519.app_sr25519.Public();
            ImOnline.Decode(byteArray, ref p);
            ParaValidator = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public();
            ParaValidator.Decode(byteArray, ref p);
            ParaAssignment = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public();
            ParaAssignment.Decode(byteArray, ref p);
            AuthorityDiscovery = new Substats.Polkadot.NetApiExt.Generated.Model.sp_authority_discovery.app.Public();
            AuthorityDiscovery.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
