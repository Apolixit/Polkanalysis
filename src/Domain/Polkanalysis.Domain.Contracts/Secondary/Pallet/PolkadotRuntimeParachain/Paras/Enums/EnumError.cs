using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeParachain.Paras.Enums
{
    public enum Error
    {

        NotRegistered = 0,

        CannotOnboard = 1,

        CannotOffboard = 2,

        CannotUpgrade = 3,

        CannotDowngrade = 4,

        PvfCheckStatementStale = 5,

        PvfCheckStatementFuture = 6,

        PvfCheckValidatorIndexOutOfBounds = 7,

        PvfCheckInvalidSignature = 8,

        PvfCheckDoubleVote = 9,

        PvfCheckSubjectInvalid = 10,

        PvfCheckDisabled = 11,

        CannotUpgradeCode = 12,
    }

    /// <summary>
    /// >> 679 - Variant[polkadot_runtime_parachains.paras.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
