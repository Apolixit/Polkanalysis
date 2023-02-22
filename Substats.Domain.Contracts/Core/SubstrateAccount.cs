
using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core
{
    public class SubstrateAccount : BaseType
    {
        // TODO : override Equals !
        public SubstrateAccount() {
            Address = new Hash();
            Bytes = new byte[0];
            TypeSize = 32;
        }
        public SubstrateAccount(string address) : this()
        {
            Address.Create(address);
            Bytes = Utils.GetPublicKeyFrom(address);
        }

        public SubstrateAccount(Hash address) : this(address.Value)
        {

        }
        // From AccountId32
        public Hash Address { get; set; }
        public byte[] Bytes { get; set; }
        public int TypeSize { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Address.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Address = new Hash();
            Address.Decode(byteArray, ref p);
            TypeSize = p - start;
        }

        public string ToStringAddress(int ss58 = 42)
            => ToStringAddress((short)ss58);
        public string ToStringAddress(short ss58 = 42)
        {
            return Utils.GetAddressFrom(Bytes, ss58);
        }

       
    }
}
