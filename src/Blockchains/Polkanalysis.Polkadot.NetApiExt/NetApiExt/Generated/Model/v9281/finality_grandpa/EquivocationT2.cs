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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.finality_grandpa;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.finality_grandpa
{
    /// <summary>
    /// >> 9708 - Composite[finality_grandpa.EquivocationT2]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class EquivocationT2 : EquivocationT2Base
    {
        public override System.String TypeName()
        {
            return "EquivocationT2";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(RoundNumber.Encode());
            result.AddRange(Identity.Encode());
            result.AddRange(First.Encode());
            result.AddRange(Second.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            RoundNumber = new Substrate.NetApi.Model.Types.Primitive.U64();
            RoundNumber.Decode(byteArray, ref p);
            Identity = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_finality_grandpa.app.Public();
            Identity.Decode(byteArray, ref p);
            First = new Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.finality_grandpa.Precommit, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_finality_grandpa.app.Signature>();
            First.Decode(byteArray, ref p);
            Second = new Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.finality_grandpa.Precommit, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_finality_grandpa.app.Signature>();
            Second.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}