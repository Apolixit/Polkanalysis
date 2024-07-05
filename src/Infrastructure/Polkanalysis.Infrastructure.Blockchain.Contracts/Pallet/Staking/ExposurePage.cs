using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking
{
    public class ExposurePage : BaseType
    {
        public BaseCom<U128> PageTotal { get; set; }
        public BaseVec<IndividualExposure> Others { get; set; }

        public ExposurePage() { }

        public ExposurePage(BaseCom<U128> pageTotal, BaseVec<IndividualExposure> others)
        {
            Create(pageTotal, others);
        }

        public void Create(BaseCom<U128> pageTotal, BaseVec<IndividualExposure> others)
        {
            PageTotal = pageTotal;
            Others = others;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(PageTotal.Encode());
            result.AddRange(Others.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            PageTotal = new BaseCom<U128>();
            PageTotal.Decode(byteArray, ref p);
            Others = new BaseVec<IndividualExposure>();
            Others.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
