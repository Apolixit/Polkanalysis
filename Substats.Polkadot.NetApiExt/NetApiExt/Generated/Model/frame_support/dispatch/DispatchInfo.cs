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
    /// >> 20 - Composite[frame_support.dispatch.DispatchInfo]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class DispatchInfo : BaseType
    {
        
        /// <summary>
        /// >> weight
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight _weight;
        
        /// <summary>
        /// >> class
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch.EnumDispatchClass _class;
        
        /// <summary>
        /// >> pays_fee
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch.EnumPays _paysFee;
        
        public Substats.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight Weight
        {
            get
            {
                return this._weight;
            }
            set
            {
                this._weight = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch.EnumDispatchClass Class
        {
            get
            {
                return this._class;
            }
            set
            {
                this._class = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch.EnumPays PaysFee
        {
            get
            {
                return this._paysFee;
            }
            set
            {
                this._paysFee = value;
            }
        }
        
        public override string TypeName()
        {
            return "DispatchInfo";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Weight.Encode());
            result.AddRange(Class.Encode());
            result.AddRange(PaysFee.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Weight = new Substats.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            Weight.Decode(byteArray, ref p);
            Class = new Substats.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch.EnumDispatchClass();
            Class.Decode(byteArray, ref p);
            PaysFee = new Substats.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch.EnumPays();
            PaysFee.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
