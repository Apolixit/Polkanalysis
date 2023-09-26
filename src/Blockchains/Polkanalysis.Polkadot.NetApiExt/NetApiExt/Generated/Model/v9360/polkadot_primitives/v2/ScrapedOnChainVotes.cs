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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.polkadot_primitives.v2
{
    /// <summary>
    /// >> 13064 - Composite[polkadot_primitives.v2.ScrapedOnChainVotes]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ScrapedOnChainVotes : ScrapedOnChainVotesBase
    {
        public override System.String TypeName()
        {
            return "ScrapedOnChainVotes";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Session.Encode());
            result.AddRange(BackingValidatorsPerCandidate.Encode());
            result.AddRange(Disputes.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Session = new Substrate.NetApi.Model.Types.Primitive.U32();
            Session.Decode(byteArray, ref p);
            BackingValidatorsPerCandidate = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.polkadot_primitives.v2.CandidateReceipt, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.polkadot_primitives.v2.ValidatorIndex, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.polkadot_primitives.v2.EnumValidityAttestation>>>>();
            BackingValidatorsPerCandidate.Decode(byteArray, ref p);
            Disputes = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.polkadot_primitives.v2.DisputeStatementSet>();
            Disputes.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}