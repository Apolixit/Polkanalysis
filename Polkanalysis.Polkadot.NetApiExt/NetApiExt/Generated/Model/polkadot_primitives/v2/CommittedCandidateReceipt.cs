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
    /// >> 392 - Composite[polkadot_primitives.v2.CommittedCandidateReceipt]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class CommittedCandidateReceipt : BaseType
    {
        
        /// <summary>
        /// >> descriptor
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateDescriptor _descriptor;
        
        /// <summary>
        /// >> commitments
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateCommitments _commitments;
        
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
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateCommitments Commitments
        {
            get
            {
                return this._commitments;
            }
            set
            {
                this._commitments = value;
            }
        }
        
        public override string TypeName()
        {
            return "CommittedCandidateReceipt";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Descriptor.Encode());
            result.AddRange(Commitments.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Descriptor = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateDescriptor();
            Descriptor.Decode(byteArray, ref p);
            Commitments = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateCommitments();
            Commitments.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}