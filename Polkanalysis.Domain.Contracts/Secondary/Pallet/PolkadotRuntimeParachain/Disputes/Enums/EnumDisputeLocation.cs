using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeParachain.Disputes.Enums
{
    public enum DisputeLocation
    {

        Local = 0,

        Remote = 1,
    }

    /// <summary>
    /// >> 115 - Variant[polkadot_runtime_parachains.disputes.DisputeLocation]
    /// </summary>
    public sealed class EnumDisputeLocation : BaseEnum<DisputeLocation>
    {
    }
}
