using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core.Random
{
    public class Hexa : Nameable
    {
        public Hexa() {
            IntegerSize = 32;
        }

        public Hexa(string hex) : this() {
            Create(Utils.HexToByteArray(hex));
        }
        public Hexa(BaseType value) : base(value) { }
        public override string Display()
        {
            return Utils.Bytes2HexString(Value.ToBytes());
        }
    }
}
