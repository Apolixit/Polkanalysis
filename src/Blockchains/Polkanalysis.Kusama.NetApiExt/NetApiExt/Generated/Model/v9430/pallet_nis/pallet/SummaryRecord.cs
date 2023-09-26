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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_nis.pallet;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nis.pallet
{
    /// <summary>
    /// >> 713 - Composite[pallet_nis.pallet.SummaryRecord]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SummaryRecord : SummaryRecordBase
    {
        public override System.String TypeName()
        {
            return "SummaryRecord";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ProportionOwed.Encode());
            result.AddRange(Index.Encode());
            result.AddRange(Thawed.Encode());
            result.AddRange(LastPeriod.Encode());
            result.AddRange(ReceiptsOnHold.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ProportionOwed = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_arithmetic.per_things.Perquintill();
            ProportionOwed.Decode(byteArray, ref p);
            Index = new Substrate.NetApi.Model.Types.Primitive.U32();
            Index.Decode(byteArray, ref p);
            Thawed = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_arithmetic.per_things.Perquintill();
            Thawed.Decode(byteArray, ref p);
            LastPeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            LastPeriod.Decode(byteArray, ref p);
            ReceiptsOnHold = new Substrate.NetApi.Model.Types.Primitive.U128();
            ReceiptsOnHold.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}