using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.ParasRegistar.Enums
{
    [DomainMapping("polkadot_runtime_common/paras_registrar/pallet")]
    public enum Error
    {

        NotRegistered = 0,

        AlreadyRegistered = 1,

        NotOwner = 2,

        CodeTooLarge = 3,

        HeadDataTooLarge = 4,

        NotParachain = 5,

        NotParathread = 6,

        CannotDeregister = 7,

        CannotDowngrade = 8,

        CannotUpgrade = 9,

        ParaLocked = 10,

        NotReserved = 11,

        EmptyCode = 12,

        CannotSwap = 13,
    }

    /// <summary>
    /// >> 704 - Variant[polkadot_runtime_common.paras_registrar.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
