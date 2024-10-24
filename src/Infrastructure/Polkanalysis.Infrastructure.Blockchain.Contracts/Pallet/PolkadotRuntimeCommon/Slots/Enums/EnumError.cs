using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Slots.Enums
{
    [DomainMapping("polkadot_runtime_common/slots/pallet")]
    public enum Error
    {

        ParaNotOnboarding = 0,

        LeaseError = 1,
    }

    /// <summary>
    /// >> 706 - Variant[polkadot_runtime_common.slots.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
