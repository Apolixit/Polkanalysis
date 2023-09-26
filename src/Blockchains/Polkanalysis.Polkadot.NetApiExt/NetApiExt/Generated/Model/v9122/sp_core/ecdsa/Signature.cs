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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.ecdsa;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.ecdsa
{
    /// <summary>
    /// >> 943 - Composite[sp_core.ecdsa.Signature]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Signature : SignatureBase
    {
        public override System.String TypeName()
        {
            return "Signature";
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
            Value = new Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr65U8();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}