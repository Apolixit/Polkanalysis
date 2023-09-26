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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.signed;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.polkadot_primitives.v4.signed
{
    /// <summary>
    /// >> 15037 - Composite[polkadot_primitives.v4.signed.UncheckedSigned]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class UncheckedSigned : UncheckedSignedBase
    {
        public override System.String TypeName()
        {
            return "UncheckedSigned";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Payload.Encode());
            result.AddRange(ValidatorIndex.Encode());
            result.AddRange(Signature.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Payload = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.polkadot_primitives.v4.AvailabilityBitfield();
            Payload.Decode(byteArray, ref p);
            ValidatorIndex = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.polkadot_primitives.v4.ValidatorIndex();
            ValidatorIndex.Decode(byteArray, ref p);
            Signature = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.polkadot_primitives.v4.validator_app.Signature();
            Signature.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}