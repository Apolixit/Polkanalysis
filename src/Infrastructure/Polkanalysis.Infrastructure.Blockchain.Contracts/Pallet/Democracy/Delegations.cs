using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy
{
    public class Delegations : BaseType
    {
        public U128 Votes { get; set; }
        public U128 Capital { get; set; }

        public Delegations() { }

        public Delegations(U128 votes, U128 capital)
        {
            Create(votes, capital);
        }

        public void Create(U128 votes, U128 capital)
        {
            Votes = votes;
            Capital = capital;

            Bytes = Encode();
            TypeSize = Votes.TypeSize + Capital.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Votes.Encode());
            result.AddRange(Capital.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Votes = new Substrate.NetApi.Model.Types.Primitive.U128();
            Votes.Decode(byteArray, ref p);
            Capital = new Substrate.NetApi.Model.Types.Primitive.U128();
            Capital.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
