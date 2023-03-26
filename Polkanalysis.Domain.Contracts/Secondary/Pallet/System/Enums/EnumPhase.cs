using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.SystemCore.Enums
{
    public enum Phase
    {

        ApplyExtrinsic = 0,

        Finalization = 1,

        Initialization = 2,
    }

    public sealed class EnumPhase : BaseEnumExt<Phase, Ajuna.NetApi.Model.Types.Primitive.U32, BaseVoid, BaseVoid>
    {
    }
}
