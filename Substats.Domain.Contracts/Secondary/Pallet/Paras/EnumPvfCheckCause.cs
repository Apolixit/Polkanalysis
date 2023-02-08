using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Paras
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
        BaseTuple<Id, Ajuna.NetApi.Model.Types.Primitive.U32>>
    {
    }
}
