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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.finality_grandpa;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.finality_grandpa
{
    /// <summary>
    /// >> 1840 - Composite[finality_grandpa.EquivocationT1]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class EquivocationT1 : EquivocationT1Base
    {
        public override System.String TypeName()
        {
            return "EquivocationT1";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(RoundNumber.Encode());
            result.AddRange(Identity1.Encode());
            result.AddRange(First.Encode());
            result.AddRange(Second.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            RoundNumber = new Substrate.NetApi.Model.Types.Primitive.U64();
            RoundNumber.Decode(byteArray, ref p);
            Identity1 = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.sp_finality_grandpa.app.Public();
            Identity1.Decode(byteArray, ref p);
            First = new Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.finality_grandpa.Prevote, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.sp_finality_grandpa.app.Signature>();
            First.Decode(byteArray, ref p);
            Second = new Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.finality_grandpa.Prevote, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.sp_finality_grandpa.app.Signature>();
            Second.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}