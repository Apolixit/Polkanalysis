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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_slots;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.sp_consensus_slots
{
    /// <summary>
    /// >> 1998 - Composite[sp_consensus_slots.EquivocationProof]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class EquivocationProof : EquivocationProofBase
    {
        public override System.String TypeName()
        {
            return "EquivocationProof";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Offender.Encode());
            result.AddRange(Slot.Encode());
            result.AddRange(FirstHeader.Encode());
            result.AddRange(SecondHeader.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Offender = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.sp_consensus_babe.app.Public();
            Offender.Decode(byteArray, ref p);
            Slot = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.sp_consensus_slots.Slot();
            Slot.Decode(byteArray, ref p);
            FirstHeader = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.sp_runtime.generic.header.Header();
            FirstHeader.Decode(byteArray, ref p);
            SecondHeader = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.sp_runtime.generic.header.Header();
            SecondHeader.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}