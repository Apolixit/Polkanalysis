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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9170.pallet_bags_list.list
{
    /// <summary>
    /// >> 15981 - Composite[pallet_bags_list.list.Bag]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Bag : BagBase
    {
        public override System.String TypeName()
        {
            return "Bag";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Head.Encode());
            result.AddRange(Tail.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Head = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9170.sp_core.crypto.AccountId32>();
            Head.Decode(byteArray, ref p);
            Tail = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9170.sp_core.crypto.AccountId32>();
            Tail.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}