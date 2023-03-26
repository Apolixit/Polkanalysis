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
    /// >> 382 - Composite[polkadot_primitives.v2.InherentData]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class InherentData : BaseType
    {
        
        /// <summary>
        /// >> bitfields
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.signed.UncheckedSigned> _bitfields;
        
        /// <summary>
        /// >> backed_candidates
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.BackedCandidate> _backedCandidates;
        
        /// <summary>
        /// >> disputes
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.DisputeStatementSet> _disputes;
        
        /// <summary>
        /// >> parent_header
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.generic.header.Header _parentHeader;
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.signed.UncheckedSigned> Bitfields
        {
            get
            {
                return this._bitfields;
            }
            set
            {
                this._bitfields = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.BackedCandidate> BackedCandidates
        {
            get
            {
                return this._backedCandidates;
            }
            set
            {
                this._backedCandidates = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.DisputeStatementSet> Disputes
        {
            get
            {
                return this._disputes;
            }
            set
            {
                this._disputes = value;
            }
        }
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.generic.header.Header ParentHeader
        {
            get
            {
                return this._parentHeader;
            }
            set
            {
                this._parentHeader = value;
            }
        }
        
        public override string TypeName()
        {
            return "InherentData";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Bitfields.Encode());
            result.AddRange(BackedCandidates.Encode());
            result.AddRange(Disputes.Encode());
            result.AddRange(ParentHeader.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Bitfields = new Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.signed.UncheckedSigned>();
            Bitfields.Decode(byteArray, ref p);
            BackedCandidates = new Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.BackedCandidate>();
            BackedCandidates.Decode(byteArray, ref p);
            Disputes = new Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.DisputeStatementSet>();
            Disputes.Decode(byteArray, ref p);
            ParentHeader = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.generic.header.Header();
            ParentHeader.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
