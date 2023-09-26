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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_core.crypto;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.sp_core.crypto
{
    /// <summary>
    /// >> 17063 - Composite[sp_core.crypto.KeyTypeId]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class KeyTypeId : KeyTypeIdBase
    {
        public override System.String TypeName()
        {
            return "KeyTypeId";
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
            Value = new Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr4U8();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}