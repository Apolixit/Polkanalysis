using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Babe
{
    public class PrimaryPreDigest : IType
    {
        public U32 AuthorityIndex { get; set; }
        public U64 Slot { get; set; }
        public Hash VrfOutput { get; set; }
        public Hash64 VrfProof { get; set; }
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
