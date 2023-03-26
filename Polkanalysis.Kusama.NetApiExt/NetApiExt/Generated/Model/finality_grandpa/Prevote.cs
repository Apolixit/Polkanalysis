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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.finality_grandpa
{
    
    
    /// <summary>
    /// >> 115 - Composite[finality_grandpa.Prevote]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class Prevote : BaseType
    {
        
        /// <summary>
        /// >> target_hash
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.primitive_types.H256 _targetHash;
        
        /// <summary>
        /// >> target_number
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _targetNumber;
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.primitive_types.H256 TargetHash
        {
            get
            {
                return this._targetHash;
            }
            set
            {
                this._targetHash = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 TargetNumber
        {
            get
            {
                return this._targetNumber;
            }
            set
            {
                this._targetNumber = value;
            }
        }
        
        public override string TypeName()
        {
            return "Prevote";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(TargetHash.Encode());
            result.AddRange(TargetNumber.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            TargetHash = new Polkanalysis.Kusama.NetApiExt.Generated.Model.primitive_types.H256();
            TargetHash.Decode(byteArray, ref p);
            TargetNumber = new Ajuna.NetApi.Model.Types.Primitive.U32();
            TargetNumber.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
