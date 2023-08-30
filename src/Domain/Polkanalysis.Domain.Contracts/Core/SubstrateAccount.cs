
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Newtonsoft.Json.Linq;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Polkanalysis.Domain.Contracts.Core
{
    public class SubstrateAccount : BaseType
    {
        // TODO : override Equals !
        public SubstrateAccount() {
            TypeSize = 32;
        }
        public SubstrateAccount(string address) : this(Utils.GetPublicKeyFrom(address))
        {
            
        }

        public SubstrateAccount(U8[] value) : this(value.ToBytes()) { }
        protected SubstrateAccount(byte[] value) : this()
        {
            Create(value);
        }

        // From AccountId32
        public Hexa Value { get; set; }
        //public Hash Address { get; internal set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new Hexa();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
                return false;
            else
            {
                SubstrateAccount account = (SubstrateAccount)obj;
                return Encode().SequenceEqual(account.Encode());
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TypeSize, Bytes, Value);
        }

        public override string ToString()
        {
            return ToPolkadotAddress();
        }

        public string ToStringAddress(short ss58 = 42)
        {
            return Utils.GetAddressFrom(Encode(), ss58);
        }

        public string ToPolkadotAddress() => ToStringAddress(0);
        public string ToKusamaAddress() => ToStringAddress(2);
    }
}
