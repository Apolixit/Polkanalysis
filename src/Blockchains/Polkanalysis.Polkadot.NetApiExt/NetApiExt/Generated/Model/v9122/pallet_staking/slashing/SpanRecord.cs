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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.slashing;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_staking.slashing
{
    /// <summary>
    /// >> 993 - Composite[pallet_staking.slashing.SpanRecord]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SpanRecord : SpanRecordBase
    {
        public override System.String TypeName()
        {
            return "SpanRecord";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Slashed.Encode());
            result.AddRange(PaidOut.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Slashed = new Substrate.NetApi.Model.Types.Primitive.U128();
            Slashed.Decode(byteArray, ref p);
            PaidOut = new Substrate.NetApi.Model.Types.Primitive.U128();
            PaidOut.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}