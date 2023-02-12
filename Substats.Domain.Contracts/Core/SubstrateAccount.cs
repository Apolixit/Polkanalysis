
using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core
{
    public class SubstrateAccount : IType
    {
        public SubstrateAccount(string address)
        {
            Address = address;
            Bytes = Utils.GetPublicKeyFrom(address);
        }

        public SubstrateAccount(Hash address) : this(address.Value)
        {

        }
        // From AccountId32
        public string Address { get; set; }
        public byte[] Bytes { get; set; }
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

        public string ToStringAddress(int ss58 = 42)
            => ToStringAddress((short)ss58);
        public string ToStringAddress(short ss58 = 42)
        {
            return Utils.GetAddressFrom(Bytes, ss58);
        }

        public string TypeName()
        {
            throw new NotImplementedException();
        }
    }
}
