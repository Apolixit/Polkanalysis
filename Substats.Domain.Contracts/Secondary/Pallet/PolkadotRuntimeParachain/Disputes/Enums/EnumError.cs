using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeParachain.Disputes.Enums
{
    public enum Error
    {

        DuplicateDisputeStatementSets = 0,

        AncientDisputeStatement = 1,

        ValidatorIndexOutOfBounds = 2,

        InvalidSignature = 3,

        DuplicateStatement = 4,

        PotentialSpam = 5,

        SingleSidedDispute = 6,
    }

    /// <summary>
    /// >> 702 - Variant[polkadot_runtime_parachains.disputes.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
