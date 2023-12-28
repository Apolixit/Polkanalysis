using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums
{
    [DomainMapping("pallet_identity/types")]
    public enum Judgement
    {

        Unknown = 0,

        FeePaid = 1,

        Reasonable = 2,

        KnownGood = 3,

        OutOfDate = 4,

        LowQuality = 5,

        Erroneous = 6,
    }

    public sealed class EnumJudgement : BaseEnumExt<Judgement,
            BaseVoid,
            U128,
            BaseVoid,
            BaseVoid,
            BaseVoid,
            BaseVoid,
            BaseVoid
        >
    {
    }
}
