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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_conviction_voting.types;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_conviction_voting.types
{
    /// <summary>
    /// >> 15157 - Composite[pallet_conviction_voting.types.Tally]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Tally : TallyBase
    {
        public override System.String TypeName()
        {
            return "Tally";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Ayes.Encode());
            result.AddRange(Nays.Encode());
            result.AddRange(Support.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Ayes = new Substrate.NetApi.Model.Types.Primitive.U128();
            Ayes.Decode(byteArray, ref p);
            Nays = new Substrate.NetApi.Model.Types.Primitive.U128();
            Nays.Decode(byteArray, ref p);
            Support = new Substrate.NetApi.Model.Types.Primitive.U128();
            Support.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}