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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.polkadot_primitives.v1
{
    /// <summary>
    /// >> 1113 - Composite[polkadot_primitives.v1.ParathreadClaim]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ParathreadClaim : ParathreadClaimBase
    {
        public override System.String TypeName()
        {
            return "ParathreadClaim";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(CollatorId.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.polkadot_parachain.primitives.Id();
            Id.Decode(byteArray, ref p);
            CollatorId = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.polkadot_primitives.v0.collator_app.Public();
            CollatorId.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}