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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.limits
{
    
    
    /// <summary>
    /// >> 170 - Composite[frame_system.limits.WeightsPerClass]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class WeightsPerClass : BaseType
    {
        
        /// <summary>
        /// >> base_extrinsic
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight _baseExtrinsic;
        
        /// <summary>
        /// >> max_extrinsic
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight> _maxExtrinsic;
        
        /// <summary>
        /// >> max_total
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight> _maxTotal;
        
        /// <summary>
        /// >> reserved
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight> _reserved;
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight BaseExtrinsic
        {
            get
            {
                return this._baseExtrinsic;
            }
            set
            {
                this._baseExtrinsic = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight> MaxExtrinsic
        {
            get
            {
                return this._maxExtrinsic;
            }
            set
            {
                this._maxExtrinsic = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight> MaxTotal
        {
            get
            {
                return this._maxTotal;
            }
            set
            {
                this._maxTotal = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight> Reserved
        {
            get
            {
                return this._reserved;
            }
            set
            {
                this._reserved = value;
            }
        }
        
        public override string TypeName()
        {
            return "WeightsPerClass";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(BaseExtrinsic.Encode());
            result.AddRange(MaxExtrinsic.Encode());
            result.AddRange(MaxTotal.Encode());
            result.AddRange(Reserved.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            BaseExtrinsic = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            BaseExtrinsic.Decode(byteArray, ref p);
            MaxExtrinsic = new Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight>();
            MaxExtrinsic.Decode(byteArray, ref p);
            MaxTotal = new Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight>();
            MaxTotal.Decode(byteArray, ref p);
            Reserved = new Ajuna.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight>();
            Reserved.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
