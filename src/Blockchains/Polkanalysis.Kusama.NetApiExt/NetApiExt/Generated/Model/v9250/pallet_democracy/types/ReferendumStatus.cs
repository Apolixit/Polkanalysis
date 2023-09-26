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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_democracy.types;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.pallet_democracy.types
{
    /// <summary>
    /// >> 11078 - Composite[pallet_democracy.types.ReferendumStatus]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ReferendumStatus : ReferendumStatusBase
    {
        public override System.String TypeName()
        {
            return "ReferendumStatus";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(End.Encode());
            result.AddRange(ProposalHash.Encode());
            result.AddRange(Threshold.Encode());
            result.AddRange(Delay.Encode());
            result.AddRange(Tally.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            End = new Substrate.NetApi.Model.Types.Primitive.U32();
            End.Decode(byteArray, ref p);
            ProposalHash = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.primitive_types.H256();
            ProposalHash.Decode(byteArray, ref p);
            Threshold = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.pallet_democracy.vote_threshold.EnumVoteThreshold();
            Threshold.Decode(byteArray, ref p);
            Delay = new Substrate.NetApi.Model.Types.Primitive.U32();
            Delay.Decode(byteArray, ref p);
            Tally = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.pallet_democracy.types.Tally();
            Tally.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}