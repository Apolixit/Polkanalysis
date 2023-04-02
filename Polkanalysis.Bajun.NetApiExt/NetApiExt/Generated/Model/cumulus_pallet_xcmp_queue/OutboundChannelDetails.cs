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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue
{
    
    
    /// <summary>
    /// >> 349 - Composite[cumulus_pallet_xcmp_queue.OutboundChannelDetails]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class OutboundChannelDetails : BaseType
    {
        
        /// <summary>
        /// >> recipient
        /// </summary>
        private Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id _recipient;
        
        /// <summary>
        /// >> state
        /// </summary>
        private Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.EnumOutboundState _state;
        
        /// <summary>
        /// >> signals_exist
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.Bool _signalsExist;
        
        /// <summary>
        /// >> first_index
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U16 _firstIndex;
        
        /// <summary>
        /// >> last_index
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U16 _lastIndex;
        
        public Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id Recipient
        {
            get
            {
                return this._recipient;
            }
            set
            {
                this._recipient = value;
            }
        }
        
        public Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.EnumOutboundState State
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.Bool SignalsExist
        {
            get
            {
                return this._signalsExist;
            }
            set
            {
                this._signalsExist = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U16 FirstIndex
        {
            get
            {
                return this._firstIndex;
            }
            set
            {
                this._firstIndex = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U16 LastIndex
        {
            get
            {
                return this._lastIndex;
            }
            set
            {
                this._lastIndex = value;
            }
        }
        
        public override string TypeName()
        {
            return "OutboundChannelDetails";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Recipient.Encode());
            result.AddRange(State.Encode());
            result.AddRange(SignalsExist.Encode());
            result.AddRange(FirstIndex.Encode());
            result.AddRange(LastIndex.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Recipient = new Polkanalysis.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id();
            Recipient.Decode(byteArray, ref p);
            State = new Polkanalysis.Bajun.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.EnumOutboundState();
            State.Decode(byteArray, ref p);
            SignalsExist = new Substrate.NetApi.Model.Types.Primitive.Bool();
            SignalsExist.Decode(byteArray, ref p);
            FirstIndex = new Substrate.NetApi.Model.Types.Primitive.U16();
            FirstIndex.Decode(byteArray, ref p);
            LastIndex = new Substrate.NetApi.Model.Types.Primitive.U16();
            LastIndex.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
