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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.xcm.v2.multilocation;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.xcm.v2.multilocation
{
    /// <summary>
    /// >> 385 - Composite[xcm.v2.multilocation.MultiLocation]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class MultiLocation : MultiLocationBase
    {
        public override System.String TypeName()
        {
            return "MultiLocation";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Parents.Encode());
            result.AddRange(Interior.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Parents = new Substrate.NetApi.Model.Types.Primitive.U8();
            Parents.Decode(byteArray, ref p);
            Interior = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.xcm.v2.multilocation.EnumJunctions();
            Interior.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}