using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public class SubPools : BaseType
    {
        public UnbondPool NoEra { get; set; }
        public BaseVec<BaseTuple<U32, UnbondPool>> WithEra { get; set; }

        public SubPools() { }

        public SubPools(UnbondPool noEra, BaseVec<BaseTuple<U32, UnbondPool>> withEra)
        {
            Create(noEra, withEra);
        }

        public void Create(UnbondPool noEra, BaseVec<BaseTuple<U32, UnbondPool>> withEra)
        {
            NoEra = noEra;
            WithEra = withEra;

            Bytes = Encode();
            TypeSize = NoEra.TypeSize + WithEra.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(NoEra.Encode());
            result.AddRange(WithEra.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            NoEra = new UnbondPool();
            NoEra.Decode(byteArray, ref p);
            WithEra = new BaseVec<BaseTuple<U32, UnbondPool>>();
            WithEra.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
