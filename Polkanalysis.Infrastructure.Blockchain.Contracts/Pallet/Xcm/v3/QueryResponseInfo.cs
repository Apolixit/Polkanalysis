//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Attributes;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v3
{
    /// <summary>
    /// >> 16797 - Composite[xcm.v3.QueryResponseInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class QueryResponseInfo : BaseType
    {
        public MultiLocation Destination { get; set; }
        /// <summary>
        /// >> query_id
        /// </summary>
        public BaseCom<Substrate.NetApi.Model.Types.Primitive.U64> QueryId { get; set; }
        /// <summary>
        /// >> max_weight
        /// </summary>
        public Weight MaxWeight { get; set; }
        /// <summary>
        /// >> destination1
        /// </summary>
        public MultiLocation Destination1 { get; set; }

        public override string TypeName()
        {
            return "QueryResponseInfo";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Destination1.Encode());
            result.AddRange(QueryId.Encode());
            result.AddRange(MaxWeight.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Destination1 = new MultiLocation();
            Destination1.Decode(byteArray, ref p);
            QueryId = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>();
            QueryId.Decode(byteArray, ref p);
            MaxWeight = new Weight();
            MaxWeight.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}