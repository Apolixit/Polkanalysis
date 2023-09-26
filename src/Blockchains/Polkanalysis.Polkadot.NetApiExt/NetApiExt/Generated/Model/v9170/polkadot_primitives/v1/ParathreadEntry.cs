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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_primitives.v1
{
    /// <summary>
    /// >> 3094 - Composite[polkadot_primitives.v1.ParathreadEntry]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ParathreadEntry : ParathreadEntryBase
    {
        public override System.String TypeName()
        {
            return "ParathreadEntry";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Claim.Encode());
            result.AddRange(Retries.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Claim = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_primitives.v1.ParathreadClaim();
            Claim.Decode(byteArray, ref p);
            Retries = new Substrate.NetApi.Model.Types.Primitive.U32();
            Retries.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}