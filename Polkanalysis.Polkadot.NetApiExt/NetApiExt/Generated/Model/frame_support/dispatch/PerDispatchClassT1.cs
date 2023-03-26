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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch
{
    
    
    /// <summary>
    /// >> 7 - Composite[frame_support.dispatch.PerDispatchClassT1]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class PerDispatchClassT1 : BaseType
    {
        
        /// <summary>
        /// >> normal
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight _normal;
        
        /// <summary>
        /// >> operational
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight _operational;
        
        /// <summary>
        /// >> mandatory
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight _mandatory;
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight Normal
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
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight Operational
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
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight Mandatory
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
            return "PerDispatchClassT1";
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
            Normal = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            Normal.Decode(byteArray, ref p);
            Operational = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            Operational.Decode(byteArray, ref p);
            Mandatory = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            Mandatory.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
