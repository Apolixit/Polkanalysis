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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_nomination_pools
{
    /// <summary>
    /// >> 15023 - Composite[pallet_nomination_pools.CommissionChangeRate]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CommissionChangeRate : CommissionChangeRateBase
    {
        public override System.String TypeName()
        {
            return "CommissionChangeRate";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(MaxIncrease.Encode());
            result.AddRange(MinDelay.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            MaxIncrease = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_arithmetic.per_things.Perbill();
            MaxIncrease.Decode(byteArray, ref p);
            MinDelay = new Substrate.NetApi.Model.Types.Primitive.U32();
            MinDelay.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}