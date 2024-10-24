using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums
{
    [DomainMapping("polkadot_runtime_parachains/disputes")]
    public enum DisputeResult
    {

        Valid = 0,

        Invalid = 1,
    }

    /// <summary>
    /// >> 480 - Variant[polkadot_runtime_parachains.disputes.DisputeResult]
    /// </summary>
    public sealed class EnumDisputeResult : BaseEnum<DisputeResult>
    {
    }
}
