//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Substats.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe
{
    
    
    public enum AllowedSlots
    {
        
        PrimarySlots = 0,
        
        PrimaryAndSecondaryPlainSlots = 1,
        
        PrimaryAndSecondaryVRFSlots = 2,
    }
    
    /// <summary>
    /// >> 194 - Variant[sp_consensus_babe.AllowedSlots]
    /// </summary>
    public sealed class EnumAllowedSlots : BaseEnum<AllowedSlots>
    {
    }
}
