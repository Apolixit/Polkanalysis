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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.pallet_session.pallet
{
    public enum Error
    {
        InvalidProof = 0,
        NoAssociatedValidatorId = 1,
        DuplicatedKey = 2,
        NoKeys = 3,
        NoAccount = 4
    }

    /// <summary>
    /// >> 13364 - Variant[pallet_session.pallet.Error]
    /// Error for the session pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}