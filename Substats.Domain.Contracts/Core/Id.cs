using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core
{
    /// <summary>
    /// Model.polkadot_parachain.primitives.Id
    /// </summary>
    public class Id : IType
    {
        public Id() { }
        public Id(uint value)
        {
            Value = new U32().With(value);
        }

        public U32 Value { get; set; }
        public int TypeSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create(string str)
        {
            throw new NotImplementedException();
        }

        public void Create(byte[] byteArray)
        {
            throw new NotImplementedException();
        }

        public void CreateFromJson(string str)
        {
            throw new NotImplementedException();
        }

        public void Decode(byte[] byteArray, ref int p)
        {
            throw new NotImplementedException();
        }

        public byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public IType New()
        {
            throw new NotImplementedException();
        }

        public string TypeName()
        {
            throw new NotImplementedException();
        }
    }
}
