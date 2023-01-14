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


namespace Substats.Kusama.NetApiExt.Generated.Model.pallet_referenda.types
{
    
    
    /// <summary>
    /// >> 633 - Composite[pallet_referenda.types.TrackInfo]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class TrackInfo : BaseType
    {
        
        /// <summary>
        /// >> name
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.Str _name;
        
        /// <summary>
        /// >> max_deciding
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _maxDeciding;
        
        /// <summary>
        /// >> decision_deposit
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _decisionDeposit;
        
        /// <summary>
        /// >> prepare_period
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _preparePeriod;
        
        /// <summary>
        /// >> decision_period
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _decisionPeriod;
        
        /// <summary>
        /// >> confirm_period
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _confirmPeriod;
        
        /// <summary>
        /// >> min_enactment_period
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _minEnactmentPeriod;
        
        /// <summary>
        /// >> min_approval
        /// </summary>
        private Substats.Kusama.NetApiExt.Generated.Model.pallet_referenda.types.EnumCurve _minApproval;
        
        /// <summary>
        /// >> min_support
        /// </summary>
        private Substats.Kusama.NetApiExt.Generated.Model.pallet_referenda.types.EnumCurve _minSupport;
        
        public Ajuna.NetApi.Model.Types.Primitive.Str Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaxDeciding
        {
            get
            {
                return this._maxDeciding;
            }
            set
            {
                this._maxDeciding = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 DecisionDeposit
        {
            get
            {
                return this._decisionDeposit;
            }
            set
            {
                this._decisionDeposit = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 PreparePeriod
        {
            get
            {
                return this._preparePeriod;
            }
            set
            {
                this._preparePeriod = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 DecisionPeriod
        {
            get
            {
                return this._decisionPeriod;
            }
            set
            {
                this._decisionPeriod = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 ConfirmPeriod
        {
            get
            {
                return this._confirmPeriod;
            }
            set
            {
                this._confirmPeriod = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 MinEnactmentPeriod
        {
            get
            {
                return this._minEnactmentPeriod;
            }
            set
            {
                this._minEnactmentPeriod = value;
            }
        }
        
        public Substats.Kusama.NetApiExt.Generated.Model.pallet_referenda.types.EnumCurve MinApproval
        {
            get
            {
                return this._minApproval;
            }
            set
            {
                this._minApproval = value;
            }
        }
        
        public Substats.Kusama.NetApiExt.Generated.Model.pallet_referenda.types.EnumCurve MinSupport
        {
            get
            {
                return this._minSupport;
            }
            set
            {
                this._minSupport = value;
            }
        }
        
        public override string TypeName()
        {
            return "TrackInfo";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Name.Encode());
            result.AddRange(MaxDeciding.Encode());
            result.AddRange(DecisionDeposit.Encode());
            result.AddRange(PreparePeriod.Encode());
            result.AddRange(DecisionPeriod.Encode());
            result.AddRange(ConfirmPeriod.Encode());
            result.AddRange(MinEnactmentPeriod.Encode());
            result.AddRange(MinApproval.Encode());
            result.AddRange(MinSupport.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Name = new Ajuna.NetApi.Model.Types.Primitive.Str();
            Name.Decode(byteArray, ref p);
            MaxDeciding = new Ajuna.NetApi.Model.Types.Primitive.U32();
            MaxDeciding.Decode(byteArray, ref p);
            DecisionDeposit = new Ajuna.NetApi.Model.Types.Primitive.U128();
            DecisionDeposit.Decode(byteArray, ref p);
            PreparePeriod = new Ajuna.NetApi.Model.Types.Primitive.U32();
            PreparePeriod.Decode(byteArray, ref p);
            DecisionPeriod = new Ajuna.NetApi.Model.Types.Primitive.U32();
            DecisionPeriod.Decode(byteArray, ref p);
            ConfirmPeriod = new Ajuna.NetApi.Model.Types.Primitive.U32();
            ConfirmPeriod.Decode(byteArray, ref p);
            MinEnactmentPeriod = new Ajuna.NetApi.Model.Types.Primitive.U32();
            MinEnactmentPeriod.Decode(byteArray, ref p);
            MinApproval = new Substats.Kusama.NetApiExt.Generated.Model.pallet_referenda.types.EnumCurve();
            MinApproval.Decode(byteArray, ref p);
            MinSupport = new Substats.Kusama.NetApiExt.Generated.Model.pallet_referenda.types.EnumCurve();
            MinSupport.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
