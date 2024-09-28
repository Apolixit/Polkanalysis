using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums
{
    [DomainMapping("xcm/v2")]
    public enum WeightLimit
    {

        Unlimited = 0,

        Limited = 1,
    }

    /// <summary>
    /// >> 148 - Variant[xcm.v2.WeightLimit]
    /// </summary>
    public sealed class EnumWeightLimit : BaseEnumExt<WeightLimit, BaseVoid, BaseCom<U64>>
    {
    }
}
