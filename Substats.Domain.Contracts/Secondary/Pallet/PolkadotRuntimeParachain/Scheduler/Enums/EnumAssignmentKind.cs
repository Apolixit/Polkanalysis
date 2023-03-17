using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeParachain.Scheduler.Enums
{
    public enum AssignmentKind
    {

        Parachain = 0,

        Parathread = 1,
    }

    /// <summary>
    /// >> 665 - Variant[polkadot_runtime_parachains.scheduler.AssignmentKind]
    /// </summary>
    public sealed class EnumAssignmentKind : BaseEnumExt<AssignmentKind, BaseVoid, BaseTuple<PublicSr25519, U32>>
    {
    }
}
