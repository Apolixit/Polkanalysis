using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums
{
    [DomainMapping("polkadot_runtime_parachains/paras")]
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
