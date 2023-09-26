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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2
{
    /// <summary>
    /// >> 2073 - Composite[polkadot_primitives.v2.CommittedCandidateReceipt]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CommittedCandidateReceipt : CommittedCandidateReceiptBase
    {
        public override System.String TypeName()
        {
            return "CommittedCandidateReceipt";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Descriptor.Encode());
            result.AddRange(Commitments.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Descriptor = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2.CandidateDescriptor();
            Descriptor.Decode(byteArray, ref p);
            Commitments = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2.CandidateCommitments();
            Commitments.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}