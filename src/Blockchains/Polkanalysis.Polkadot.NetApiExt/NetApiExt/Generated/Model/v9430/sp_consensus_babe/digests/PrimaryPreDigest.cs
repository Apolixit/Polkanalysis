//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Attributes;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_babe.digests;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_consensus_babe.digests
{
    /// <summary>
    /// >> 15229 - Composite[sp_consensus_babe.digests.PrimaryPreDigest]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PrimaryPreDigest : PrimaryPreDigestBase
    {
        public override System.String TypeName()
        {
            return "PrimaryPreDigest";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(AuthorityIndex.Encode());
            result.AddRange(Slot.Encode());
            result.AddRange(VrfSignature.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            AuthorityIndex = new Substrate.NetApi.Model.Types.Primitive.U32();
            AuthorityIndex.Decode(byteArray, ref p);
            Slot = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_consensus_slots.Slot();
            Slot.Decode(byteArray, ref p);
            VrfSignature = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_core.sr25519.vrf.VrfSignature();
            VrfSignature.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}