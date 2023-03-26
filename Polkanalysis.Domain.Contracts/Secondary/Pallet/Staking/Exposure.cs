using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.AjunaExtension;
using Polkanalysis.AjunaExtension.Encoding;
using System.Numerics;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking
{
    public class Exposure : BaseType
    {
        public BaseCom<U128> Total { get; set; }
        public BaseCom<U128> Own { get; set; }
        public BaseVec<IndividualExposure> Others { get; set; }

        public Exposure() { }

        public Exposure(BaseCom<U128> total, BaseCom<U128> own, BaseVec<IndividualExposure> others)
        {
            Create(total, own, others);
        }

        public void Create(BaseCom<U128> total, BaseCom<U128> own, BaseVec<IndividualExposure> others)
        {
            Total = total;
            Own = own;
            Others = others;

            Bytes = Encode();
            TypeSize = Total.TypeSize + Own.TypeSize + Others.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Total.Encode());
            result.AddRange(Own.Encode());
            result.AddRange(Others.Encode());
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
