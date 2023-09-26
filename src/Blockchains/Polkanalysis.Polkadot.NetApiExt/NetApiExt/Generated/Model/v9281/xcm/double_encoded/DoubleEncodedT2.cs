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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.xcm.double_encoded;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.xcm.double_encoded
{
    /// <summary>
    /// >> 9923 - Composite[xcm.double_encoded.DoubleEncodedT2]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class DoubleEncodedT2 : DoubleEncodedT2Base
    {
        public override System.String TypeName()
        {
            return "DoubleEncodedT2";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Encoded.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Encoded = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>();
            Encoded.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}