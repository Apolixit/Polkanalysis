//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Attributes;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.bajun_runtime
{
    
    
    /// <summary>
    /// >> 238 - Composite[bajun_runtime.SessionKeys]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class SessionKeys : BaseType
    {
        
        /// <summary>
        /// >> aura
        /// </summary>
        private Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_consensus_aura.sr25519.app_sr25519.Public _aura;
        
        public Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_consensus_aura.sr25519.app_sr25519.Public Aura
        {
            get
            {
                return this._aura;
            }
            set
            {
                this._aura = value;
            }
        }
        
        public override string TypeName()
        {
            return "SessionKeys";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Aura.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Aura = new Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_consensus_aura.sr25519.app_sr25519.Public();
            Aura.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
