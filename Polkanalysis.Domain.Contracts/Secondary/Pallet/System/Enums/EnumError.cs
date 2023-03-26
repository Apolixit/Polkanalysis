using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore.Enums
{
    public enum Error
    {

        InvalidSpecName = 0,

        SpecVersionNeedsToIncrease = 1,

        FailedToExtractRuntimeVersion = 2,

        NonDefaultComposite = 3,

        NonZeroRefCount = 4,

        CallFiltered = 5,
    }

    /// <summary>
    /// >> 176 - Variant[frame_system.pallet.Error]
    /// Error for the System pallet
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
