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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.bitvec.order;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.bitvec.order
{
    /// <summary>
    /// >> 18006 - Composite[bitvec.order.Lsb0]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Lsb0 : Lsb0Base
    {
        public override System.String TypeName()
        {
            return "Lsb0";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}