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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras
{
    
    
    public enum ParaLifecycle
    {
        
        Onboarding = 0,
        
        Parathread = 1,
        
        Parachain = 2,
        
        UpgradingParathread = 3,
        
        DowngradingParachain = 4,
        
        OffboardingParathread = 5,
        
        OffboardingParachain = 6,
    }
    
    /// <summary>
    /// >> 669 - Variant[polkadot_runtime_parachains.paras.ParaLifecycle]
    /// </summary>
    public sealed class EnumParaLifecycle : BaseEnum<ParaLifecycle>
    {
    }
}
