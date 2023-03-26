using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums
{
    public enum Error
    {

        FirstPeriodInPast = 0,

        FirstPeriodTooFarInFuture = 1,

        LastPeriodBeforeFirstPeriod = 2,

        LastPeriodTooFarInFuture = 3,

        CannotEndInPast = 4,

        EndTooFarInFuture = 5,

        Overflow = 6,

        ContributionTooSmall = 7,

        InvalidParaId = 8,

        CapExceeded = 9,

        ContributionPeriodOver = 10,

        InvalidOrigin = 11,

        NotParachain = 12,

        LeaseActive = 13,

        BidOrLeaseActive = 14,

        FundNotEnded = 15,

        NoContributions = 16,

        NotReadyToDissolve = 17,

        InvalidSignature = 18,

        MemoTooLarge = 19,

        AlreadyInNewRaise = 20,

        VrfDelayInProgress = 21,

        NoLeasePeriod = 22,
    }

    /// <summary>
    /// >> 714 - Variant[polkadot_runtime_common.crowdloan.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
