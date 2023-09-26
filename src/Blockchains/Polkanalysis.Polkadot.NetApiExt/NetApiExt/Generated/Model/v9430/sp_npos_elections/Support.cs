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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_npos_elections;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_npos_elections
{
    /// <summary>
    /// >> 15011 - Composite[sp_npos_elections.Support]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Support : SupportBase
    {
        public override System.String TypeName()
        {
            return "Support";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Total.Encode());
            result.AddRange(Voters.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Total = new Substrate.NetApi.Model.Types.Primitive.U128();
            Total.Decode(byteArray, ref p);
            Voters = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>();
            Voters.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}