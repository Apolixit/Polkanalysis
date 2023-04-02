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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_pallet_parachain_system.relay_state_snapshot
{
    
    
    /// <summary>
    /// >> 144 - Composite[cumulus_pallet_parachain_system.relay_state_snapshot.MessagingStateSnapshot]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class MessagingStateSnapshot : BaseType
    {
        
        /// <summary>
        /// >> dmq_mqc_head
        /// </summary>
        private Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256 _dmqMqcHead;
        
        /// <summary>
        /// >> relay_dispatch_queue_size
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32> _relayDispatchQueueSize;
        
        /// <summary>
        /// >> ingress_channels
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.AbridgedHrmpChannel>> _ingressChannels;
        
        /// <summary>
        /// >> egress_channels
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.AbridgedHrmpChannel>> _egressChannels;
        
        public Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256 DmqMqcHead
        {
            get
            {
                return this._dmqMqcHead;
            }
            set
            {
                this._dmqMqcHead = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32> RelayDispatchQueueSize
        {
            get
            {
                return this._relayDispatchQueueSize;
            }
            set
            {
                this._relayDispatchQueueSize = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.AbridgedHrmpChannel>> IngressChannels
        {
            get
            {
                return this._ingressChannels;
            }
            set
            {
                this._ingressChannels = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.AbridgedHrmpChannel>> EgressChannels
        {
            get
            {
                return this._egressChannels;
            }
            set
            {
                this._egressChannels = value;
            }
        }
        
        public override string TypeName()
        {
            return "MessagingStateSnapshot";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(DmqMqcHead.Encode());
            result.AddRange(RelayDispatchQueueSize.Encode());
            result.AddRange(IngressChannels.Encode());
            result.AddRange(EgressChannels.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            DmqMqcHead = new Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types.H256();
            DmqMqcHead.Decode(byteArray, ref p);
            RelayDispatchQueueSize = new Ajuna.NetApi.Model.Types.Base.BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>();
            RelayDispatchQueueSize.Decode(byteArray, ref p);
            IngressChannels = new Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.AbridgedHrmpChannel>>();
            IngressChannels.Decode(byteArray, ref p);
            EgressChannels = new Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_primitives.v2.AbridgedHrmpChannel>>();
            EgressChannels.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}