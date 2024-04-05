using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Referenda
{
    public sealed class Tally : BaseType
    {
        public Tally() { }

        public Tally(U128 ayes, U128 nays, U128 support)
        {
            Create(ayes, nays, support);
        }

        public void Create(U128 ayes, U128 nays, U128 support)
        {
            Ayes = ayes;
            Nays = nays;
            Support = support;
        }

        public U128 Ayes { get; set; }
        public U128 Nays { get; set; }
        public U128 Support { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Ayes.Encode());
            result.AddRange(Nays.Encode());
            result.AddRange(Support.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Ayes = new U128();
            Ayes.Decode(byteArray, ref p);
            Nays = new U128();
            Nays.Decode(byteArray, ref p);
            Support = new U128();
            Support.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
