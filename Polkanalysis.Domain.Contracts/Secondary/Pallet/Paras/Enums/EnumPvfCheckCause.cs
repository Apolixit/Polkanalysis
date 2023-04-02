using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras.Enums
{
    public enum PvfCheckCause
    {

        Onboarding = 0,

        Upgrade = 1,
    }

    /// <summary>
    /// >> 668 - Variant[polkadot_runtime_parachains.paras.PvfCheckCause]
    /// </summary>
    public sealed class EnumPvfCheckCause : BaseEnumExt<PvfCheckCause, Id,
        BaseTuple<Id, U32>>
    {
    }
}
