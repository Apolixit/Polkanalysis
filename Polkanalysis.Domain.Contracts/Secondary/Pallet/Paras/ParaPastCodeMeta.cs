using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras
{
    public class ParaPastCodeMeta : BaseType
    {
        public BaseVec<ReplacementTimes> UpgradeTimes { get; set; }
        public BaseOpt<U32> LastPruned { get; set; }

        public ParaPastCodeMeta() { }

        public ParaPastCodeMeta(BaseVec<ReplacementTimes> upgradeTimes, BaseOpt<U32> lastPruned)
        {
            Create(upgradeTimes, lastPruned);
        }

        public void Create(BaseVec<ReplacementTimes> upgradeTimes, BaseOpt<U32> lastPruned)
        {
            UpgradeTimes = upgradeTimes;
            LastPruned = lastPruned;

            Bytes = Encode();
            TypeSize = UpgradeTimes.TypeSize + LastPruned.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(UpgradeTimes.Encode());
            result.AddRange(LastPruned.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            UpgradeTimes = new BaseVec<ReplacementTimes>();
            UpgradeTimes.Decode(byteArray, ref p);
            LastPruned = new BaseOpt<U32>();
            LastPruned.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
