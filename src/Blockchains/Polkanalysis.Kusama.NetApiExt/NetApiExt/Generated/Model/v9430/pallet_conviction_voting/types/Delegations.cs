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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_conviction_voting.types;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_conviction_voting.types
{
    /// <summary>
    /// >> 605 - Composite[pallet_conviction_voting.types.Delegations]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Delegations : DelegationsBase
    {
        public override System.String TypeName()
        {
            return "Delegations";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Votes.Encode());
            result.AddRange(Capital.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Votes = new Substrate.NetApi.Model.Types.Primitive.U128();
            Votes.Decode(byteArray, ref p);
            Capital = new Substrate.NetApi.Model.Types.Primitive.U128();
            Capital.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}