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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_core.bounded.bounded_btree_map;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.sp_core.bounded.bounded_btree_map
{
    /// <summary>
    /// >> 5904 - Composite[sp_core.bounded.bounded_btree_map.BoundedBTreeMapT1]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BoundedBTreeMapT1 : BoundedBTreeMapT1Base
    {
        public override System.String TypeName()
        {
            return "BoundedBTreeMapT1";
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
            Value = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}