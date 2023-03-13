using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Identity.Enums
{
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
