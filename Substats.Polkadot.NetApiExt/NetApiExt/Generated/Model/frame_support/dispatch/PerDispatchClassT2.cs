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


namespace Substats.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch
{
    
    
    /// <summary>
    /// >> 168 - Composite[frame_support.dispatch.PerDispatchClassT2]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class PerDispatchClassT2 : BaseType
    {
        
        /// <summary>
        /// >> normal
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass _normal;
        
        /// <summary>
        /// >> operational
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass _operational;
        
        /// <summary>
        /// >> mandatory
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass _mandatory;
        
        public Substats.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass Normal
        {
            get
            {
                return this._normal;
            }
            set
            {
                this._normal = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass Operational
        {
            get
            {
                return this._operational;
            }
            set
            {
                this._operational = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass Mandatory
        {
            get
            {
                return this._mandatory;
            }
            set
            {
                this._mandatory = value;
            }
        }
        
        public override string TypeName()
        {
            return "PerDispatchClassT2";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Normal.Encode());
            result.AddRange(Operational.Encode());
            result.AddRange(Mandatory.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Normal = new Substats.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass();
            Normal.Decode(byteArray, ref p);
            Operational = new Substats.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass();
            Operational.Decode(byteArray, ref p);
            Mandatory = new Substats.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass();
            Mandatory.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
