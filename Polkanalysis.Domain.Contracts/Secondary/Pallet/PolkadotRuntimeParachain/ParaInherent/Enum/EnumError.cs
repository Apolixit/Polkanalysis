using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeParachain.ParaInherent.Enum
{
    public enum Error
    {

        TooManyInclusionInherents = 0,

        InvalidParentHeader = 1,

        CandidateConcludedInvalid = 2,

        InherentOverweight = 3,

        DisputeStatementsUnsortedOrDuplicates = 4,

        DisputeInvalid = 5,
    }

    /// <summary>
    /// >> 652 - Variant[polkadot_runtime_parachains.paras_inherent.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
