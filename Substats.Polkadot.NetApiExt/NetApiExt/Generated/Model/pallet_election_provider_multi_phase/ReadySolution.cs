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


namespace Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase
{
    
    
    /// <summary>
    /// >> 602 - Composite[pallet_election_provider_multi_phase.ReadySolution]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class ReadySolution : BaseType
    {
        
        /// <summary>
        /// >> supports
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT26 _supports;
        
        /// <summary>
        /// >> score
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore _score;
        
        /// <summary>
        /// >> compute
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumElectionCompute _compute;
        
        public Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT26 Supports
        {
            get
            {
                return this._supports;
            }
            set
            {
                this._supports = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore Score
        {
            get
            {
                return this._score;
            }
            set
            {
                this._score = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumElectionCompute Compute
        {
            get
            {
                return this._compute;
            }
            set
            {
                this._compute = value;
            }
        }
        
        public override string TypeName()
        {
            return "ReadySolution";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Supports.Encode());
            result.AddRange(Score.Encode());
            result.AddRange(Compute.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Supports = new Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT26();
            Supports.Decode(byteArray, ref p);
            Score = new Substats.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore();
            Score.Decode(byteArray, ref p);
            Compute = new Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumElectionCompute();
            Compute.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
