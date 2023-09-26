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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_primitives.v4
{
    /// <summary>
    /// >> 1206 - Composite[polkadot_primitives.v4.BackedCandidate]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BackedCandidate : BackedCandidateBase
    {
        public override System.String TypeName()
        {
            return "BackedCandidate";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Candidate.Encode());
            result.AddRange(ValidityVotes.Encode());
            result.AddRange(ValidatorIndices.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Candidate = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_primitives.v4.CommittedCandidateReceipt();
            Candidate.Decode(byteArray, ref p);
            ValidityVotes = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_primitives.v4.EnumValidityAttestation>();
            ValidityVotes.Decode(byteArray, ref p);
            ValidatorIndices = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.bitvec.order.Lsb0>();
            ValidatorIndices.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}