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
    [DomainMapping("xcm/v2/traits")]
    public enum Outcome
    {

        Complete = 0,

        Incomplete = 1,

        Error = 2,
    }

    /// <summary>
    /// >> 109 - Variant[xcm.v2.traits.Outcome]
    /// </summary>
    public sealed class EnumOutcome : BaseEnumExt<Outcome, U64, BaseTuple<U64, EnumError>, EnumError>
    {
    }
}
