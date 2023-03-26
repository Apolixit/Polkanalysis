using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Democracy
{
    public class Tally : BaseType
    {
        public U128 Ayes { get; set; }
        public U128 Nays { get; set; }
        public U128 Turnout { get; set; }

        public Tally() { }

        public Tally(U128 ayes, U128 nays, U128 turnout)
        {
            Create(ayes, nays, turnout);
        }

        public void Create(U128 ayes, U128 nays, U128 turnout)
        {
            Ayes = ayes;
            Nays = nays;
            Turnout = turnout;

            Bytes = Encode();
            TypeSize = Ayes.TypeSize + Nays.TypeSize + Turnout.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Ayes.Encode());
            result.AddRange(Nays.Encode());
            result.AddRange(Turnout.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Ayes = new U128();
            Ayes.Decode(byteArray, ref p);
            Nays = new U128();
            Nays.Decode(byteArray, ref p);
            Turnout = new U128();
            Turnout.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
