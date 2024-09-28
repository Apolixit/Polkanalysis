using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Crowdloan
{
    [DomainMapping("polkadot_runtime_common/crowdloan")]
    public enum LastContribution
    {

        Never = 0,

        PreEnding = 1,

        Ending = 2,
    }

    public sealed class EnumLastContribution : BaseEnumExt<LastContribution, BaseVoid, U32, U32>
    {
    }
}
