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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.polkadot_primitives.v2
{
    /// <summary>
    /// >> 13612 - Composite[polkadot_primitives.v2.PvfCheckStatement]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PvfCheckStatement : PvfCheckStatementBase
    {
        public override System.String TypeName()
        {
            return "PvfCheckStatement";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Accept.Encode());
            result.AddRange(Subject.Encode());
            result.AddRange(SessionIndex.Encode());
            result.AddRange(ValidatorIndex.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Accept = new Substrate.NetApi.Model.Types.Primitive.Bool();
            Accept.Decode(byteArray, ref p);
            Subject = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.polkadot_parachain.primitives.ValidationCodeHash();
            Subject.Decode(byteArray, ref p);
            SessionIndex = new Substrate.NetApi.Model.Types.Primitive.U32();
            SessionIndex.Decode(byteArray, ref p);
            ValidatorIndex = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.polkadot_primitives.v2.ValidatorIndex();
            ValidatorIndex.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}