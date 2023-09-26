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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.finality_grandpa;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.finality_grandpa
{
    /// <summary>
    /// >> 761 - Composite[finality_grandpa.Precommit]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Precommit : PrecommitBase
    {
        public override System.String TypeName()
        {
            return "Precommit";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(TargetHash.Encode());
            result.AddRange(TargetNumber.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            TargetHash = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.primitive_types.H256();
            TargetHash.Decode(byteArray, ref p);
            TargetNumber = new Substrate.NetApi.Model.Types.Primitive.U32();
            TargetNumber.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}