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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_message_queue;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_message_queue
{
    /// <summary>
    /// >> 15542 - Composite[pallet_message_queue.Page]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Page : PageBase
    {
        public override System.String TypeName()
        {
            return "Page";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Remaining.Encode());
            result.AddRange(RemainingSize.Encode());
            result.AddRange(FirstIndex.Encode());
            result.AddRange(First.Encode());
            result.AddRange(Last.Encode());
            result.AddRange(Heap.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Remaining = new Substrate.NetApi.Model.Types.Primitive.U32();
            Remaining.Decode(byteArray, ref p);
            RemainingSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            RemainingSize.Decode(byteArray, ref p);
            FirstIndex = new Substrate.NetApi.Model.Types.Primitive.U32();
            FirstIndex.Decode(byteArray, ref p);
            First = new Substrate.NetApi.Model.Types.Primitive.U32();
            First.Decode(byteArray, ref p);
            Last = new Substrate.NetApi.Model.Types.Primitive.U32();
            Last.Decode(byteArray, ref p);
            Heap = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>();
            Heap.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}