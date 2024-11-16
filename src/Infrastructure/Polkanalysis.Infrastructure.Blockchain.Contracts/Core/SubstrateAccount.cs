using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Random;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using System.Collections.Generic;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core
{
    [DomainMapping("sp_core/crypto >> AccountId32")]
    [DomainMapping("account >> AccountId20")]
    public class SubstrateAccount : BaseType
    {
        public static bool IsSubstrate = true;
        //public static Bool IsSubstrateRomain = new Bool(true);

        // TODO : override Equals !
        public SubstrateAccount()
        {
            
        }

        public SubstrateAccount(string address) 
            : this(address.Length == 32 || address.Length == 48 ? 
                  Utils.GetPublicKeyFrom(address) :
                  Utils.HexToByteArray(address))
        {
            
        }

        public SubstrateAccount(U8[] value) : this(value.ToBytes()) { }
        protected SubstrateAccount(byte[] value) : this()
        {
            TypeSize = value.Length;

            Create(value);
        }

        public FlexibleNameable Value { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            //result.AddRange(IsSubstrateRomain.Encode());
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            //IsSubstrateRomain.Decode(byteArray, ref p);

            if (IsSubstrate)
            {
                Value = new Hexa32();

            }
            else
            {
                Value = new Hexa20();
            }
            //if (byteArray.Length == 20)
            //{
            //    Value = new Hexa20();
            //}
            //else if(byteArray.Length == 32)
            //{
            //    Value = new Hexa32();
            //}
            //else
            //{
            //    throw new InvalidCastException("Invalid account length");
            //}

            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
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

        public string ToPublicKey()
        {
            return Utils.Bytes2HexString(Utils.GetPublicKeyFrom(ToStringAddress()));
        }

        public string ToEthereumAddress()
        {
            return ToPublicKey().Substring(0, 42);
        }

        public string ToStringAddress(short ss58 = 42)
        {
            return Utils.GetAddressFrom(Encode(), ss58);
        }

        public string ToPolkadotAddress() => ToStringAddress(0);
        public string ToKusamaAddress() => ToStringAddress(2);
    }
}
