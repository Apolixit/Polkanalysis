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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2
{
    
    
    /// <summary>
    /// >> 99 - Composite[polkadot_primitives.v2.CandidateReceipt]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class CandidateReceipt : BaseType
    {
        
        /// <summary>
        /// >> descriptor
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateDescriptor _descriptor;
        
        /// <summary>
        /// >> commitments_hash
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 _commitmentsHash;
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateDescriptor Descriptor
        {
            get
            {
                return this._descriptor;
            }
            set
            {
                this._descriptor = value;
            }
        }
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 CommitmentsHash
        {
            get
            {
                return this._commitmentsHash;
            }
            set
            {
                this._commitmentsHash = value;
            }
        }
        
        public override string TypeName()
        {
            return "CandidateReceipt";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Descriptor.Encode());
            result.AddRange(CommitmentsHash.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Descriptor = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateDescriptor();
            Descriptor.Decode(byteArray, ref p);
            CommitmentsHash = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256();
            CommitmentsHash.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
