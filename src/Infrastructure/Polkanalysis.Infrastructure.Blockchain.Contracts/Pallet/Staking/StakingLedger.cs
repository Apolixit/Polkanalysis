using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking
{
    public class StakingLedger : BaseType
    {
        public SubstrateAccount Stash { get; set; }
        public BaseCom<U128> Total { get; set; }
        public BaseCom<U128> Active { get; set; }
        public BaseVec<UnlockChunk> Unlocking { get; set; }
        public BaseVec<U32> ClaimedRewards { get; set; }

        public StakingLedger() { }

        public StakingLedger(SubstrateAccount stash, BaseCom<U128> total, BaseCom<U128> active, BaseVec<UnlockChunk> unlocking, BaseVec<U32> claimedRewards)
        {
            Stash = stash;
            Total = total;
            Active = active;
            Unlocking = unlocking;
            ClaimedRewards = claimedRewards;
        }

        public void Create(SubstrateAccount stash, BaseCom<U128> total, BaseCom<U128> active, BaseVec<UnlockChunk> unlocking, BaseVec<U32> claimedRewards)
        {
            Stash = stash;
            Total = total;
            Active = active;
            Unlocking = unlocking;
            ClaimedRewards = claimedRewards;

            Bytes = Encode();
            TypeSize = Stash.TypeSize + Total.TypeSize + Active.TypeSize + Unlocking.TypeSize + ClaimedRewards.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Stash.Encode());
            result.AddRange(Total.Encode());
            result.AddRange(Active.Encode());
            result.AddRange(Unlocking.Encode());
            result.AddRange(ClaimedRewards.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Stash = new SubstrateAccount();
            Stash.Decode(byteArray, ref p);
            Total = new BaseCom<U128>();
            Total.Decode(byteArray, ref p);
            Active = new BaseCom<U128>();
            Active.Decode(byteArray, ref p);
            Unlocking = new BaseVec<UnlockChunk>();
            Unlocking.Decode(byteArray, ref p);
            ClaimedRewards = new BaseVec<U32>();
            ClaimedRewards.Decode(byteArray, ref p);
            TypeSize = p - start;
        }

    }
}
