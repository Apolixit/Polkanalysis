//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.frame_system.pallet
{
    public enum Error
    {
        InvalidSpecName = 0,
        SpecVersionNeedsToIncrease = 1,
        FailedToExtractRuntimeVersion = 2,
        NonDefaultComposite = 3,
        NonZeroRefCount = 4,
        CallFiltered = 5
    }

    /// <summary>
    /// >> 1990 - Variant[frame_system.pallet.Error]
    /// Error for the System pallet
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}