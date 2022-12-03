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


namespace Blazscan.NetApiExt.Generated.Model.frame_system
{
    
    
    /// <summary>
    /// >> 17 - Composite[frame_system.EventRecord]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class EventRecord : BaseType
    {
        
        /// <summary>
        /// >> phase
        /// </summary>
        private Blazscan.NetApiExt.Generated.Model.frame_system.EnumPhase _phase;
        
        /// <summary>
        /// >> event
        /// </summary>
        private Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent _event;
        
        /// <summary>
        /// >> topics
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.primitive_types.H256> _topics;
        
        public Blazscan.NetApiExt.Generated.Model.frame_system.EnumPhase Phase
        {
            get
            {
                return this._phase;
            }
            set
            {
                this._phase = value;
            }
        }
        
        public Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent Event
        {
            get
            {
                return this._event;
            }
            set
            {
                this._event = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.primitive_types.H256> Topics
        {
            get
            {
                return this._topics;
            }
            set
            {
                this._topics = value;
            }
        }
        
        public override string TypeName()
        {
            return "EventRecord";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Phase.Encode());
            result.AddRange(Event.Encode());
            result.AddRange(Topics.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Phase = new Blazscan.NetApiExt.Generated.Model.frame_system.EnumPhase();
            Phase.Decode(byteArray, ref p);
            Event = new Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent();
            Event.Decode(byteArray, ref p);
            Topics = new Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.NetApiExt.Generated.Model.primitive_types.H256>();
            Topics.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
