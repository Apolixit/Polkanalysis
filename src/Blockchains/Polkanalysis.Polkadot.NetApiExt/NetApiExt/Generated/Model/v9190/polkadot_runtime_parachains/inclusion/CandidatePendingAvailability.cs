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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.inclusion;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_runtime_parachains.inclusion
{
    /// <summary>
    /// >> 4465 - Composite[polkadot_runtime_parachains.inclusion.CandidatePendingAvailability]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CandidatePendingAvailability : CandidatePendingAvailabilityBase
    {
        public override System.String TypeName()
        {
            return "CandidatePendingAvailability";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Core1.Encode());
            result.AddRange(Hash.Encode());
            result.AddRange(Descriptor1.Encode());
            result.AddRange(AvailabilityVotes.Encode());
            result.AddRange(Backers.Encode());
            result.AddRange(RelayParentNumber.Encode());
            result.AddRange(BackedInNumber.Encode());
            result.AddRange(BackingGroup1.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Core1 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_primitives.v2.CoreIndex();
            Core1.Decode(byteArray, ref p);
            Hash = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_core_primitives.CandidateHash();
            Hash.Decode(byteArray, ref p);
            Descriptor1 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_primitives.v2.CandidateDescriptor();
            Descriptor1.Decode(byteArray, ref p);
            AvailabilityVotes = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.bitvec.order.Lsb0>();
            AvailabilityVotes.Decode(byteArray, ref p);
            Backers = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.bitvec.order.Lsb0>();
            Backers.Decode(byteArray, ref p);
            RelayParentNumber = new Substrate.NetApi.Model.Types.Primitive.U32();
            RelayParentNumber.Decode(byteArray, ref p);
            BackedInNumber = new Substrate.NetApi.Model.Types.Primitive.U32();
            BackedInNumber.Decode(byteArray, ref p);
            BackingGroup1 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_primitives.v2.GroupIndex();
            BackingGroup1.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}