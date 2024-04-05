using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools
{
    public class Commission : BaseType
    {
        public Commission() { }

        public Commission(BaseOpt<BaseTuple<Perbill, SubstrateAccount>> current, BaseOpt<Perbill> max, BaseOpt<CommissionChangeRate> changeRate, BaseOpt<U32> throttleFrom)
        {
            Create(current, max, changeRate, throttleFrom);
        }

        public void Create(BaseOpt<BaseTuple<Perbill, SubstrateAccount>> current, BaseOpt<Perbill> max, BaseOpt<CommissionChangeRate> changeRate, BaseOpt<U32> throttleFrom)
        {
            Current = current;
            Max = max;
            ChangeRate = changeRate;
            ThrottleFrom = throttleFrom;

            Bytes = Encode();
            TypeSize = Current.TypeSize + Max.TypeSize + ChangeRate.TypeSize + ThrottleFrom.TypeSize;
        }

        public BaseOpt<BaseTuple<Perbill, SubstrateAccount>> Current { get; set; }
        public BaseOpt<Perbill> Max { get; set; }
        public BaseOpt<CommissionChangeRate> ChangeRate { get; set; }
        public BaseOpt<U32> ThrottleFrom { get; set; }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Current = new BaseOpt<BaseTuple<Perbill, SubstrateAccount>>();
            Current.Decode(byteArray, ref p);
            Max = new BaseOpt<Perbill>();
            Max.Decode(byteArray, ref p);
            ChangeRate = new BaseOpt<CommissionChangeRate>();
            ChangeRate.Decode(byteArray, ref p);
            ThrottleFrom = new BaseOpt<U32>();
            ThrottleFrom.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Current.Encode());
            result.AddRange(Max.Encode());
            result.AddRange(ChangeRate.Encode());
            result.AddRange(ThrottleFrom.Encode());
            return result.ToArray();
            
        }
    }
}
