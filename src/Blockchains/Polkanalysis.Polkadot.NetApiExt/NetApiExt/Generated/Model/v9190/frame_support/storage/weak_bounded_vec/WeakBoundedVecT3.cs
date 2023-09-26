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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.storage.weak_bounded_vec;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.frame_support.storage.weak_bounded_vec
{
    /// <summary>
    /// >> 4360 - Composite[frame_support.storage.weak_bounded_vec.WeakBoundedVecT3]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class WeakBoundedVecT3 : WeakBoundedVecT3Base
    {
        public override System.String TypeName()
        {
            return "WeakBoundedVecT3";
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
            Value = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.sp_finality_grandpa.app.Public, Substrate.NetApi.Model.Types.Primitive.U64>>();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}