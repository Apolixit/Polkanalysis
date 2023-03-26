using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v2.Enums
{
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
