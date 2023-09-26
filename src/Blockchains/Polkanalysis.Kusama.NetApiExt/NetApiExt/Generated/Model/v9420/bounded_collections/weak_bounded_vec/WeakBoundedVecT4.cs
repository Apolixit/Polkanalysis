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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.bounded_collections.weak_bounded_vec;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.bounded_collections.weak_bounded_vec
{
    /// <summary>
    /// >> 1449 - Composite[bounded_collections.weak_bounded_vec.WeakBoundedVecT4]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class WeakBoundedVecT4 : WeakBoundedVecT4Base
    {
        public override System.String TypeName()
        {
            return "WeakBoundedVecT4";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_consensus_grandpa.app.Public, Substrate.NetApi.Model.Types.Primitive.U64>>();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}