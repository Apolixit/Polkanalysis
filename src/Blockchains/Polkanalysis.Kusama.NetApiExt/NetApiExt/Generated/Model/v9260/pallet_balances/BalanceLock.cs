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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_balances;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.pallet_balances
{
    /// <summary>
    /// >> 10203 - Composite[pallet_balances.BalanceLock]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BalanceLock : BalanceLockBase
    {
        public override System.String TypeName()
        {
            return "BalanceLock";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Amount.Encode());
            result.AddRange(Reasons.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr8U8();
            Id.Decode(byteArray, ref p);
            Amount = new Substrate.NetApi.Model.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);
            Reasons = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.pallet_balances.EnumReasons();
            Reasons.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}