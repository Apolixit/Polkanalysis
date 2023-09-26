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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.primitive_types;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.primitive_types
{
    /// <summary>
    /// >> 12996 - Composite[primitive_types.U256]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class U256 : U256Base
    {
        public override System.String TypeName()
        {
            return "U256";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr4U64();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}