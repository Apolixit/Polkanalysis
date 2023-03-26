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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.signed
{
    
    
    /// <summary>
    /// >> 338 - Composite[polkadot_primitives.v2.signed.UncheckedSigned]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class UncheckedSigned : BaseType
    {
        
        /// <summary>
        /// >> payload
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.AvailabilityBitfield _payload;
        
        /// <summary>
        /// >> validator_index
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex _validatorIndex;
        
        /// <summary>
        /// >> signature
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Signature _signature;
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.AvailabilityBitfield Payload
        {
            get
            {
                return this._payload;
            }
            set
            {
                this._payload = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex ValidatorIndex
        {
            get
            {
                return this._validatorIndex;
            }
            set
            {
                this._validatorIndex = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Signature Signature
        {
            get
            {
                return this._signature;
            }
            set
            {
                this._signature = value;
            }
        }
        
        public override string TypeName()
        {
            return "UncheckedSigned";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Payload.Encode());
            result.AddRange(ValidatorIndex.Encode());
            result.AddRange(Signature.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Payload = new Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.AvailabilityBitfield();
            Payload.Decode(byteArray, ref p);
            ValidatorIndex = new Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex();
            ValidatorIndex.Decode(byteArray, ref p);
            Signature = new Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Signature();
            Signature.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
