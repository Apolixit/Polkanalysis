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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_core_primitives
{
    
    
    /// <summary>
    /// >> 361 - Composite[polkadot_core_primitives.CandidateHash]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CandidateHash : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.primitive_types.H256 _value;
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.primitive_types.H256 Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
        
        public override string TypeName()
        {
            return "CandidateHash";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new Polkanalysis.Kusama.NetApiExt.Generated.Model.primitive_types.H256();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
