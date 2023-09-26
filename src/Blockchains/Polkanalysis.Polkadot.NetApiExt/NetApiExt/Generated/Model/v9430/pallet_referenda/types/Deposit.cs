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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_referenda.types;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_referenda.types
{
    /// <summary>
    /// >> 15343 - Composite[pallet_referenda.types.Deposit]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Deposit : DepositBase
    {
        public override System.String TypeName()
        {
            return "Deposit";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Who.Encode());
            result.AddRange(Amount.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Who = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32();
            Who.Decode(byteArray, ref p);
            Amount = new Substrate.NetApi.Model.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}