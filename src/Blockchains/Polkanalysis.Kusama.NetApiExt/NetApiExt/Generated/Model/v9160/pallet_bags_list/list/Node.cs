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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_bags_list.list;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.pallet_bags_list.list
{
    /// <summary>
    /// >> 16713 - Composite[pallet_bags_list.list.Node]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Node : NodeBase
    {
        public override System.String TypeName()
        {
            return "Node";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Prev.Encode());
            result.AddRange(Next.Encode());
            result.AddRange(BagUpper.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32();
            Id.Decode(byteArray, ref p);
            Prev = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32>();
            Prev.Decode(byteArray, ref p);
            Next = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32>();
            Next.Decode(byteArray, ref p);
            BagUpper = new Substrate.NetApi.Model.Types.Primitive.U64();
            BagUpper.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}