using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Domain.Contracts.Core.DispatchInfo
{
    public class DispatchInfo : BaseType
    {
        public DispatchInfo() { }

        public DispatchInfo(Weight weight, EnumDispatchClass @class, EnumPays paysFee)
        {
            Create(weight, @class, paysFee);
        }

        public Weight Weight { get; set; }
        public EnumDispatchClass Class { get; set; }
        public EnumPays PaysFee { get; set; }

        public void Create(Weight weight, EnumDispatchClass @class, EnumPays paysFee)
        {
            Weight = weight;
            Class = @class;
            PaysFee = paysFee;

            Bytes = Encode();
            TypeSize = Weight.TypeSize + Class.TypeSize + PaysFee.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Weight.Encode());
            result.AddRange(Class.Encode());
            result.AddRange(PaysFee.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Weight = new Weight();
            Weight.Decode(byteArray, ref p);
            Class = new EnumDispatchClass();
            Class.Decode(byteArray, ref p);
            PaysFee = new EnumPays();
            PaysFee.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
