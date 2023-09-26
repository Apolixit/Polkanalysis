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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.pallet_nomination_pools
{
    /// <summary>
    /// >> 12301 - Composite[pallet_nomination_pools.RewardPool]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class RewardPool : RewardPoolBase
    {
        public override System.String TypeName()
        {
            return "RewardPool";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(LastRecordedRewardCounter.Encode());
            result.AddRange(LastRecordedTotalPayouts.Encode());
            result.AddRange(TotalRewardsClaimed.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            LastRecordedRewardCounter = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_arithmetic.fixed_point.FixedU128();
            LastRecordedRewardCounter.Decode(byteArray, ref p);
            LastRecordedTotalPayouts = new Substrate.NetApi.Model.Types.Primitive.U128();
            LastRecordedTotalPayouts.Decode(byteArray, ref p);
            TotalRewardsClaimed = new Substrate.NetApi.Model.Types.Primitive.U128();
            TotalRewardsClaimed.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}