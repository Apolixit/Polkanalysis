//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Attributes;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch
{
    
    
    /// <summary>
    /// >> 169 - Composite[frame_support.dispatch.PerDispatchClassT2]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PerDispatchClassT2 : BaseType
    {
        
        /// <summary>
        /// >> normal
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass _normal;
        
        /// <summary>
        /// >> operational
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass _operational;
        
        /// <summary>
        /// >> mandatory
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass _mandatory;
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass Normal
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
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass Operational
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
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass Mandatory
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
            Normal = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass();
            Normal.Decode(byteArray, ref p);
            Operational = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass();
            Operational.Decode(byteArray, ref p);
            Mandatory = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.limits.WeightsPerClass();
            Mandatory.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
