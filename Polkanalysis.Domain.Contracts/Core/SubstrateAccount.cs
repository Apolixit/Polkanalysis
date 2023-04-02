
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Newtonsoft.Json.Linq;
using Polkanalysis.AjunaExtension;
using Polkanalysis.Domain.Contracts.Core.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Core
{
    public class SubstrateAccount : BaseType
    {
        // TODO : override Equals !
        public SubstrateAccount() {
            Address = new Hash();
            Bytes = new byte[0];
            TypeSize = 32;
        }
        public SubstrateAccount(string address) : this(Utils.GetPublicKeyFrom(address))
        {
            //Address.Create(address);
            //Bytes = Utils.GetPublicKeyFrom(address);
            
        }

        public SubstrateAccount(U8[] value) : this(value.ToBytes()) { }
        protected SubstrateAccount(byte[] value) : this()
        {
            Create(value);
        }

        // From AccountId32
        public Hexa Value { get; set; }
        public Hash Address { get; set; }

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

        public string ToStringAddress(int ss58 = 42)
            => ToStringAddress((short)ss58);
        public string ToStringAddress(short ss58 = 42)
        {
            return Utils.GetAddressFrom(Bytes, ss58);
        }

       
    }
}
