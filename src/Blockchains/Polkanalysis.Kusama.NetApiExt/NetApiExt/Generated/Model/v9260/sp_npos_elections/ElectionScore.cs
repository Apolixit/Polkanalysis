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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_npos_elections;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.sp_npos_elections
{
    /// <summary>
    /// >> 10472 - Composite[sp_npos_elections.ElectionScore]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ElectionScore : ElectionScoreBase
    {
        public override System.String TypeName()
        {
            return "ElectionScore";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(MinimalStake.Encode());
            result.AddRange(SumStake.Encode());
            result.AddRange(SumStakeSquared.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            MinimalStake = new Substrate.NetApi.Model.Types.Primitive.U128();
            MinimalStake.Decode(byteArray, ref p);
            SumStake = new Substrate.NetApi.Model.Types.Primitive.U128();
            SumStake.Decode(byteArray, ref p);
            SumStakeSquared = new Substrate.NetApi.Model.Types.Primitive.U128();
            SumStakeSquared.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}