using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.SystemCore
{
    public class LastRuntimeUpgradeInfo : BaseType
    {
        public LastRuntimeUpgradeInfo() { }

        public LastRuntimeUpgradeInfo(U32 specVersion, Str specName)
        {
            Create(new BaseCom<U32>(new Ajuna.NetApi.CompactInteger(specVersion)), specName);
        }

        public void Create(BaseCom<U32> specVersion, Str specName)
        {
            SpecVersion = specVersion;
            SpecName = specName;

            Bytes = Encode();

            TypeSize = specVersion.TypeSize + specName.TypeSize;
        }

        public BaseCom<U32> SpecVersion { get; set; }
        public Str SpecName { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(SpecVersion.Encode());
            result.AddRange(SpecName.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            SpecVersion = new BaseCom<U32>();
            SpecVersion.Decode(byteArray, ref p);
            SpecName = new Str();
            SpecName.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
