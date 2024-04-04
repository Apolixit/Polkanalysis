using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums
{
    [DomainMapping("polkadot_runtime_common/crowdloan/pallet")]
    public enum LastContribution
    {

        Never = 0,

        PreEnding = 1,

        Ending = 2,
    }

    /// <summary>
    /// >> 713 - Variant[polkadot_runtime_common.crowdloan.LastContribution]
    /// </summary>
    public sealed class EnumLastContribution : BaseEnumExt<LastContribution, BaseVoid, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>
    {
    }
}
