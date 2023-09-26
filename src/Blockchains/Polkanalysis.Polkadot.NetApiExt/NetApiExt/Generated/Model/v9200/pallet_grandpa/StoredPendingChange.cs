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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_grandpa;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_grandpa
{
    /// <summary>
    /// >> 5055 - Composite[pallet_grandpa.StoredPendingChange]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class StoredPendingChange : StoredPendingChangeBase
    {
        public override System.String TypeName()
        {
            return "StoredPendingChange";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ScheduledAt.Encode());
            result.AddRange(Delay.Encode());
            result.AddRange(NextAuthorities.Encode());
            result.AddRange(Forced.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ScheduledAt = new Substrate.NetApi.Model.Types.Primitive.U32();
            ScheduledAt.Decode(byteArray, ref p);
            Delay = new Substrate.NetApi.Model.Types.Primitive.U32();
            Delay.Decode(byteArray, ref p);
            NextAuthorities = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_finality_grandpa.app.Public, Substrate.NetApi.Model.Types.Primitive.U64>>();
            NextAuthorities.Decode(byteArray, ref p);
            Forced = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
            Forced.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}