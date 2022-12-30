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


namespace Blazscan.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase
{
    
    
    /// <summary>
    /// >> 601 - Composite[pallet_election_provider_multi_phase.ReadySolution]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class ReadySolution : BaseType
    {
        
        /// <summary>
        /// >> supports
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Blazscan.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.Support>> _supports;
        
        /// <summary>
        /// >> score
        /// </summary>
        private Blazscan.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore _score;
        
        /// <summary>
        /// >> compute
        /// </summary>
        private Blazscan.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumElectionCompute _compute;
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Blazscan.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.Support>> Supports
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
        
        public Blazscan.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore Score
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
        
        public Blazscan.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumElectionCompute Compute
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
            Supports = new Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Blazscan.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.Support>>();
            Supports.Decode(byteArray, ref p);
            Score = new Blazscan.Polkadot.NetApiExt.Generated.Model.sp_npos_elections.ElectionScore();
            Score.Decode(byteArray, ref p);
            Compute = new Blazscan.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.EnumElectionCompute();
            Compute.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}