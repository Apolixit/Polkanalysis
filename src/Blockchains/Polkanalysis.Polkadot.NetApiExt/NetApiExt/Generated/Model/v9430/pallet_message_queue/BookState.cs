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
    /// >> 15538 - Composite[pallet_message_queue.BookState]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BookState : BookStateBase
    {
        public override System.String TypeName()
        {
            return "BookState";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Begin.Encode());
            result.AddRange(End.Encode());
            result.AddRange(Count.Encode());
            result.AddRange(ReadyNeighbours.Encode());
            result.AddRange(MessageCount.Encode());
            result.AddRange(Size.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Begin = new Substrate.NetApi.Model.Types.Primitive.U32();
            Begin.Decode(byteArray, ref p);
            End = new Substrate.NetApi.Model.Types.Primitive.U32();
            End.Decode(byteArray, ref p);
            Count = new Substrate.NetApi.Model.Types.Primitive.U32();
            Count.Decode(byteArray, ref p);
            ReadyNeighbours = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_message_queue.Neighbours>();
            ReadyNeighbours.Decode(byteArray, ref p);
            MessageCount = new Substrate.NetApi.Model.Types.Primitive.U64();
            MessageCount.Decode(byteArray, ref p);
            Size = new Substrate.NetApi.Model.Types.Primitive.U64();
            Size.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}