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


namespace Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.initializer
{
    
    
    /// <summary>
    /// >> 680 - Composite[polkadot_runtime_parachains.initializer.BufferedSessionChange]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class BufferedSessionChange : BaseType
    {
        
        /// <summary>
        /// >> validators
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public> _validators;
        
        /// <summary>
        /// >> queued
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public> _queued;
        
        /// <summary>
        /// >> session_index
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _sessionIndex;
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public> Validators
        {
            get
            {
                return this._validators;
            }
            set
            {
                this._validators = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public> Queued
        {
            get
            {
                return this._queued;
            }
            set
            {
                this._queued = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 SessionIndex
        {
            get
            {
                return this._sessionIndex;
            }
            set
            {
                this._sessionIndex = value;
            }
        }
        
        public override string TypeName()
        {
            return "BufferedSessionChange";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Validators.Encode());
            result.AddRange(Queued.Encode());
            result.AddRange(SessionIndex.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Validators = new Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public>();
            Validators.Decode(byteArray, ref p);
            Queued = new Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public>();
            Queued.Decode(byteArray, ref p);
            SessionIndex = new Ajuna.NetApi.Model.Types.Primitive.U32();
            SessionIndex.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
