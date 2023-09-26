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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_primitives.v1
{
    /// <summary>
    /// >> 323 - Composite[polkadot_primitives.v1.BackedCandidate]
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
            Candidate = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_primitives.v1.CommittedCandidateReceipt();
            Candidate.Decode(byteArray, ref p);
            ValidityVotes = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_primitives.v0.EnumValidityAttestation>();
            ValidityVotes.Decode(byteArray, ref p);
            ValidatorIndices = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.bitvec.order.Lsb0>();
            ValidatorIndices.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}