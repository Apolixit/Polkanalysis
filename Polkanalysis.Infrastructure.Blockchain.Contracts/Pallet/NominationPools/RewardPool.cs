using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools
{
    public class RewardPool : BaseType
    {
        public U128 LastRecordedRewardCounter { get; set; }
        public U128 LastRecordedTotalPayouts { get; set; }
        public U128 TotalRewardsClaimed { get; set; }
        public U128? TotalCommissionPending { get; set; }
        public U128? TotalCommissionClaimed { get; set; }

        public RewardPool() { }

        public RewardPool(U128 lastRecordedRewardCounter, U128 lastRecordedTotalPayouts, U128 totalRewardsClaimed, U128? totalCommissionPending, U128? totalCommissionClaimed)
        {
            Create(lastRecordedRewardCounter, lastRecordedTotalPayouts, totalRewardsClaimed, totalCommissionPending, totalCommissionClaimed);
        }

        public void Create(U128 lastRecordedRewardCounter, U128 lastRecordedTotalPayouts, U128 totalRewardsClaimed, U128? totalCommissionPending, U128? totalCommissionClaimed)
        {
            LastRecordedRewardCounter = lastRecordedRewardCounter;
            LastRecordedTotalPayouts = lastRecordedTotalPayouts;
            TotalRewardsClaimed = totalRewardsClaimed;
            TotalCommissionPending = totalCommissionPending;
            TotalCommissionClaimed = totalCommissionClaimed;

            Bytes = Encode();
            TypeSize = LastRecordedRewardCounter.TypeSize + LastRecordedTotalPayouts.TypeSize + TotalRewardsClaimed.TypeSize;
        }

        public override byte[] Encode()
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
            LastRecordedRewardCounter = new U128();
            LastRecordedRewardCounter.Decode(byteArray, ref p);
            LastRecordedTotalPayouts = new U128();
            LastRecordedTotalPayouts.Decode(byteArray, ref p);
            TotalRewardsClaimed = new U128();
            TotalRewardsClaimed.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
