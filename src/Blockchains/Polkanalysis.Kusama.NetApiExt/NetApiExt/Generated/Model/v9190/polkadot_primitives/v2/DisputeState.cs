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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.polkadot_primitives.v2
{
    /// <summary>
    /// >> 14564 - Composite[polkadot_primitives.v2.DisputeState]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class DisputeState : DisputeStateBase
    {
        public override System.String TypeName()
        {
            return "DisputeState";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ValidatorsFor.Encode());
            result.AddRange(ValidatorsAgainst.Encode());
            result.AddRange(Start.Encode());
            result.AddRange(ConcludedAt.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ValidatorsFor = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.bitvec.order.Lsb0>();
            ValidatorsFor.Decode(byteArray, ref p);
            ValidatorsAgainst = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.bitvec.order.Lsb0>();
            ValidatorsAgainst.Decode(byteArray, ref p);
            Start = new Substrate.NetApi.Model.Types.Primitive.U32();
            Start.Decode(byteArray, ref p);
            ConcludedAt = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
            ConcludedAt.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}