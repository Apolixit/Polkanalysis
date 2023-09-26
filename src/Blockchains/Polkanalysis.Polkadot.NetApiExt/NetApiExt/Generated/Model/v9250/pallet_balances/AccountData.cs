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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.pallet_balances
{
    /// <summary>
    /// >> 6657 - Composite[pallet_balances.AccountData]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class AccountData : AccountDataBase
    {
        public override System.String TypeName()
        {
            return "AccountData";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Free.Encode());
            result.AddRange(Reserved.Encode());
            result.AddRange(MiscFrozen.Encode());
            result.AddRange(FeeFrozen.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Free = new Substrate.NetApi.Model.Types.Primitive.U128();
            Free.Decode(byteArray, ref p);
            Reserved = new Substrate.NetApi.Model.Types.Primitive.U128();
            Reserved.Decode(byteArray, ref p);
            MiscFrozen = new Substrate.NetApi.Model.Types.Primitive.U128();
            MiscFrozen.Decode(byteArray, ref p);
            FeeFrozen = new Substrate.NetApi.Model.Types.Primitive.U128();
            FeeFrozen.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}