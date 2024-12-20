﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe
{
    public class PrimaryPreDigest : BaseType
    {
        public U32 AuthorityIndex { get; set; }
        public U64 Slot { get; set; }
        public Hash VrfOutput { get; set; }
        public Hash VrfProof { get; set; }

        public PrimaryPreDigest() { }
        public PrimaryPreDigest(U32 authorityIndex, U64 slot, Hash vrfOutput, Hash vrfProof)
        {
            Create(authorityIndex, slot, vrfOutput, vrfProof);
        }

        public void Create(U32 authorityIndex, U64 slot, Hash vrfOutput, Hash vrfProof)
        {
            AuthorityIndex = authorityIndex;
            Slot = slot;
            VrfOutput = vrfOutput;
            VrfProof = vrfProof;

            Bytes = Encode();
            TypeSize = AuthorityIndex.TypeSize + Slot.TypeSize + VrfOutput.TypeSize + VrfProof.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(AuthorityIndex.Encode());
            result.AddRange(Slot.Encode());
            result.AddRange(VrfOutput.Encode());
            result.AddRange(VrfProof.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            AuthorityIndex = new U32();
            AuthorityIndex.Decode(byteArray, ref p);
            Slot = new U64();
            Slot.Decode(byteArray, ref p);
            VrfOutput = new Hash();
            VrfOutput.Decode(byteArray, ref p);
            VrfProof = new Hash();
            VrfProof.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
