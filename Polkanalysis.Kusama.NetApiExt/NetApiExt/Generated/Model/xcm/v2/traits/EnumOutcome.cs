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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.xcm.v2.traits
{
    
    
    public enum Outcome
    {
        
        Complete = 0,
        
        Incomplete = 1,
        
        Error = 2,
    }
    
    /// <summary>
    /// >> 476 - Variant[xcm.v2.traits.Outcome]
    /// </summary>
    public sealed class EnumOutcome : BaseEnumExt<Outcome, Substrate.NetApi.Model.Types.Primitive.U64, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Polkanalysis.Kusama.NetApiExt.Generated.Model.xcm.v2.traits.EnumError>, Polkanalysis.Kusama.NetApiExt.Generated.Model.xcm.v2.traits.EnumError>
    {
    }
}
