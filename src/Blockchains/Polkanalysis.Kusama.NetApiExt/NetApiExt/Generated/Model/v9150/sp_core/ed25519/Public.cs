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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_core.ed25519;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.ed25519
{
    /// <summary>
    /// >> 17568 - Composite[sp_core.ed25519.Public]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Public : PublicBase
    {
        public override System.String TypeName()
        {
            return "Public";
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
            Value = new Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}