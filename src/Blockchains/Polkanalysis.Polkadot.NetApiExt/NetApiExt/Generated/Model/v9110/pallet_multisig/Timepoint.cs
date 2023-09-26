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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_multisig;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.pallet_multisig
{
    /// <summary>
    /// >> 75 - Composite[pallet_multisig.Timepoint]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Timepoint : TimepointBase
    {
        public override System.String TypeName()
        {
            return "Timepoint";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Height.Encode());
            result.AddRange(Index.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Height = new Substrate.NetApi.Model.Types.Primitive.U32();
            Height.Decode(byteArray, ref p);
            Index = new Substrate.NetApi.Model.Types.Primitive.U32();
            Index.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}