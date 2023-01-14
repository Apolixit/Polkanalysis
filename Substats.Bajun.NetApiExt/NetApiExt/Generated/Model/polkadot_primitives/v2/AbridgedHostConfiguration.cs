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


namespace Substats.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2
{
    
    
    /// <summary>
    /// >> 148 - Composite[polkadot_primitives.v2.AbridgedHostConfiguration]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class AbridgedHostConfiguration : BaseType
    {
        
        /// <summary>
        /// >> max_code_size
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _maxCodeSize;
        
        /// <summary>
        /// >> max_head_data_size
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _maxHeadDataSize;
        
        /// <summary>
        /// >> max_upward_queue_count
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _maxUpwardQueueCount;
        
        /// <summary>
        /// >> max_upward_queue_size
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _maxUpwardQueueSize;
        
        /// <summary>
        /// >> max_upward_message_size
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _maxUpwardMessageSize;
        
        /// <summary>
        /// >> max_upward_message_num_per_candidate
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _maxUpwardMessageNumPerCandidate;
        
        /// <summary>
        /// >> hrmp_max_message_num_per_candidate
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _hrmpMaxMessageNumPerCandidate;
        
        /// <summary>
        /// >> validation_upgrade_cooldown
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _validationUpgradeCooldown;
        
        /// <summary>
        /// >> validation_upgrade_delay
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _validationUpgradeDelay;
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaxCodeSize
        {
            get
            {
                return this._maxCodeSize;
            }
            set
            {
                this._maxCodeSize = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaxHeadDataSize
        {
            get
            {
                return this._maxHeadDataSize;
            }
            set
            {
                this._maxHeadDataSize = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaxUpwardQueueCount
        {
            get
            {
                return this._maxUpwardQueueCount;
            }
            set
            {
                this._maxUpwardQueueCount = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaxUpwardQueueSize
        {
            get
            {
                return this._maxUpwardQueueSize;
            }
            set
            {
                this._maxUpwardQueueSize = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaxUpwardMessageSize
        {
            get
            {
                return this._maxUpwardMessageSize;
            }
            set
            {
                this._maxUpwardMessageSize = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaxUpwardMessageNumPerCandidate
        {
            get
            {
                return this._maxUpwardMessageNumPerCandidate;
            }
            set
            {
                this._maxUpwardMessageNumPerCandidate = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 HrmpMaxMessageNumPerCandidate
        {
            get
            {
                return this._hrmpMaxMessageNumPerCandidate;
            }
            set
            {
                this._hrmpMaxMessageNumPerCandidate = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 ValidationUpgradeCooldown
        {
            get
            {
                return this._validationUpgradeCooldown;
            }
            set
            {
                this._validationUpgradeCooldown = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 ValidationUpgradeDelay
        {
            get
            {
                return this._validationUpgradeDelay;
            }
            set
            {
                this._validationUpgradeDelay = value;
            }
        }
        
        public override string TypeName()
        {
            return "AbridgedHostConfiguration";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(MaxCodeSize.Encode());
            result.AddRange(MaxHeadDataSize.Encode());
            result.AddRange(MaxUpwardQueueCount.Encode());
            result.AddRange(MaxUpwardQueueSize.Encode());
            result.AddRange(MaxUpwardMessageSize.Encode());
            result.AddRange(MaxUpwardMessageNumPerCandidate.Encode());
            result.AddRange(HrmpMaxMessageNumPerCandidate.Encode());
            result.AddRange(ValidationUpgradeCooldown.Encode());
            result.AddRange(ValidationUpgradeDelay.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            MaxCodeSize = new Ajuna.NetApi.Model.Types.Primitive.U32();
            MaxCodeSize.Decode(byteArray, ref p);
            MaxHeadDataSize = new Ajuna.NetApi.Model.Types.Primitive.U32();
            MaxHeadDataSize.Decode(byteArray, ref p);
            MaxUpwardQueueCount = new Ajuna.NetApi.Model.Types.Primitive.U32();
            MaxUpwardQueueCount.Decode(byteArray, ref p);
            MaxUpwardQueueSize = new Ajuna.NetApi.Model.Types.Primitive.U32();
            MaxUpwardQueueSize.Decode(byteArray, ref p);
            MaxUpwardMessageSize = new Ajuna.NetApi.Model.Types.Primitive.U32();
            MaxUpwardMessageSize.Decode(byteArray, ref p);
            MaxUpwardMessageNumPerCandidate = new Ajuna.NetApi.Model.Types.Primitive.U32();
            MaxUpwardMessageNumPerCandidate.Decode(byteArray, ref p);
            HrmpMaxMessageNumPerCandidate = new Ajuna.NetApi.Model.Types.Primitive.U32();
            HrmpMaxMessageNumPerCandidate.Decode(byteArray, ref p);
            ValidationUpgradeCooldown = new Ajuna.NetApi.Model.Types.Primitive.U32();
            ValidationUpgradeCooldown.Decode(byteArray, ref p);
            ValidationUpgradeDelay = new Ajuna.NetApi.Model.Types.Primitive.U32();
            ValidationUpgradeDelay.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
