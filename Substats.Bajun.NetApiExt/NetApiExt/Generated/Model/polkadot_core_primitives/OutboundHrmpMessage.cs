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


namespace Substats.Bajun.NetApiExt.Generated.Model.polkadot_core_primitives
{
    
    
    /// <summary>
    /// >> 154 - Composite[polkadot_core_primitives.OutboundHrmpMessage]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class OutboundHrmpMessage : BaseType
    {
        
        /// <summary>
        /// >> recipient
        /// </summary>
        private Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id _recipient;
        
        /// <summary>
        /// >> data
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> _data;
        
        public Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id Recipient
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
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
            }
        }
        
        public override string TypeName()
        {
            return "OutboundHrmpMessage";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Recipient.Encode());
            result.AddRange(Data.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Recipient = new Substats.Bajun.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id();
            Recipient.Decode(byteArray, ref p);
            Data = new Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>();
            Data.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
