using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums
{
    [DomainMapping("frame_system")]
    public enum Phase
    {

        ApplyExtrinsic = 0,

        Finalization = 1,

        Initialization = 2,
    }

    public sealed class EnumPhase : BaseEnumExt<Phase, Substrate.NetApi.Model.Types.Primitive.U32, BaseVoid, BaseVoid>
    {
    }
}
