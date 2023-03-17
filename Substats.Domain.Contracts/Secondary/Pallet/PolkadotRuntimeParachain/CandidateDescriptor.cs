using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeParachain
{
    public class CandidateDescriptor : BaseType
    {
        public Id ParaId { get; set; }
        public Hash RelayParent { get; set; }
        public PublicSr25519 Collator { get; set; }
        public Hash PersistedValidationDataHash { get; set; }
        public Hash PovHash { get; set; }
        public Hash ErasureRoot { get; set; }
        public PublicSr25519 Signature { get; set; }
        public Hash ParaHead { get; set; }
        public Hash ValidationCodeHash { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ParaId.Encode());
            result.AddRange(RelayParent.Encode());
            result.AddRange(Collator.Encode());
            result.AddRange(PersistedValidationDataHash.Encode());
            result.AddRange(PovHash.Encode());
            result.AddRange(ErasureRoot.Encode());
            result.AddRange(Signature.Encode());
            result.AddRange(ParaHead.Encode());
            result.AddRange(ValidationCodeHash.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ParaId = new Id();
            ParaId.Decode(byteArray, ref p);
            RelayParent = new Hash();
            RelayParent.Decode(byteArray, ref p);
            Collator = new PublicSr25519();
            Collator.Decode(byteArray, ref p);
            PersistedValidationDataHash = new Hash();
            PersistedValidationDataHash.Decode(byteArray, ref p);
            PovHash = new Hash();
            PovHash.Decode(byteArray, ref p);
            ErasureRoot = new Hash();
            ErasureRoot.Decode(byteArray, ref p);
            Signature = new PublicSr25519();
            Signature.Decode(byteArray, ref p);
            ParaHead = new Hash();
            ParaHead.Decode(byteArray, ref p);
            ValidationCodeHash = new Hash();
            ValidationCodeHash.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
