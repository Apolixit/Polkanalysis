using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.SystemCore
{
    public class FrameSupportDispatchPerDispatchClassWeight : BaseType
    {
        public FrameSupportDispatchPerDispatchClassWeight() { }
        public FrameSupportDispatchPerDispatchClassWeight(Weight normal, Weight operational, Weight mandatory)
        {
            Create(normal, operational, mandatory);
        }

        public Weight Normal { get; set; } = new Weight();
        public Weight Operational { get; set; } = new Weight();
        public Weight Mandatory { get; set; } = new Weight();

        public void Create(Weight normal, Weight operational, Weight mandatory)
        {
            Normal = normal;
            Operational = operational;
            Mandatory = mandatory;

            Bytes = Encode();
            TypeSize = Normal.TypeSize + Operational.TypeSize + mandatory.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Normal.Encode());
            result.AddRange(Operational.Encode());
            result.AddRange(Mandatory.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Normal = new Weight();
            Normal.Decode(byteArray, ref p);
            Operational = new Weight();
            Operational.Decode(byteArray, ref p);
            Mandatory = new Weight();
            Mandatory.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
