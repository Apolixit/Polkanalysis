using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking
{
    public class Exposure : BaseType
    {
        public BaseCom<U128> Total { get; set; }
        public BaseCom<U128> Own { get; set; }
        public BaseVec<IndividualExposure>? Others { get; set; }
        public U32 NominatorCount { get; set; }
        public U32? PageCount { get; set; }

        public Exposure() { }

        public Exposure(BaseCom<U128> total, BaseCom<U128> own, BaseVec<IndividualExposure> others)
        {
            Create(total, own, others);

            NominatorCount = new U32((uint)others.Value.Length);
        }

        public Exposure(BaseCom<U128> total, BaseCom<U128> own, U32 nominatorCount, U32 pageCount)
        {
            Create(total, own, nominatorCount, pageCount);
        }

        public void Create(BaseCom<U128> total, BaseCom<U128> own, BaseVec<IndividualExposure> others)
        {
            Total = total;
            Own = own;
            Others = others;

            Bytes = Encode();
            TypeSize = Total.TypeSize + Own.TypeSize + Others.TypeSize;
        }

        public void Create(BaseCom<U128> total, BaseCom<U128> own, U32 nominatorCount, U32 pageCount)
        {
            Total = total;
            Own = own;
            NominatorCount = nominatorCount;
            PageCount = pageCount;

            Bytes = Encode();
            TypeSize = Total.TypeSize + Own.TypeSize + Others?.TypeSize ?? 0 + NominatorCount?.TypeSize ?? 0 + pageCount?.TypeSize ?? 0;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Total.Encode());
            result.AddRange(Own.Encode());

            if(Others is not null)
                result.AddRange(Others.Encode());

            if (NominatorCount is not null)
                result.AddRange(NominatorCount.Encode());

            if (PageCount is not null)
                result.AddRange(PageCount.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Total = new BaseCom<U128>();
            Total.Decode(byteArray, ref p);
            Own = new BaseCom<U128>();
            Own.Decode(byteArray, ref p);
            Others = new BaseVec<IndividualExposure>();
            Others.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
