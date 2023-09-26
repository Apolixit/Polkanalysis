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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_elections_phragmen;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.pallet_elections_phragmen
{
    /// <summary>
    /// >> 5788 - Composite[pallet_elections_phragmen.SeatHolder]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SeatHolder : SeatHolderBase
    {
        public override System.String TypeName()
        {
            return "SeatHolder";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Who.Encode());
            result.AddRange(Stake.Encode());
            result.AddRange(Deposit.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Who = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32();
            Who.Decode(byteArray, ref p);
            Stake = new Substrate.NetApi.Model.Types.Primitive.U128();
            Stake.Decode(byteArray, ref p);
            Deposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}