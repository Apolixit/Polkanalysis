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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.disputes.slashing;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_runtime_parachains.disputes.slashing
{
    /// <summary>
    /// >> 1238 - Composite[polkadot_runtime_parachains.disputes.slashing.DisputeProof]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class DisputeProof : DisputeProofBase
    {
        public override System.String TypeName()
        {
            return "DisputeProof";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(TimeSlot.Encode());
            result.AddRange(Kind.Encode());
            result.AddRange(ValidatorIndex.Encode());
            result.AddRange(ValidatorId.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            TimeSlot = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_runtime_parachains.disputes.slashing.DisputesTimeSlot();
            TimeSlot.Decode(byteArray, ref p);
            Kind = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_runtime_parachains.disputes.slashing.EnumSlashingOffenceKind();
            Kind.Decode(byteArray, ref p);
            ValidatorIndex = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_primitives.v4.ValidatorIndex();
            ValidatorIndex.Decode(byteArray, ref p);
            ValidatorId = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_primitives.v4.validator_app.Public();
            ValidatorId.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}