using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.AjunaExtension;
using System.Numerics;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public class RewardPool : BaseType
    {
        public U128 LastRecordedRewardCounter { get; set; }
        public U128 LastRecordedTotalPayouts { get; set; }
        public U128 TotalRewardsClaimed { get; set; }

        public RewardPool() { }

        public RewardPool(U128 lastRecordedRewardCounter, U128 lastRecordedTotalPayouts, U128 totalRewardsClaimed)
        {
            Create(lastRecordedRewardCounter, lastRecordedTotalPayouts, totalRewardsClaimed);
        }

        public void Create(U128 lastRecordedRewardCounter, U128 lastRecordedTotalPayouts, U128 totalRewardsClaimed)
        {
            LastRecordedRewardCounter = lastRecordedRewardCounter;
            LastRecordedTotalPayouts = lastRecordedTotalPayouts;
            TotalRewardsClaimed = totalRewardsClaimed;

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
