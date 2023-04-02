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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2
{
    
    
    /// <summary>
    /// >> 814 - Composite[polkadot_primitives.v2.SessionInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SessionInfo : BaseType
    {
        
        /// <summary>
        /// >> active_validator_indices
        /// </summary>
        private Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex> _activeValidatorIndices;
        
        /// <summary>
        /// >> random_seed
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8 _randomSeed;
        
        /// <summary>
        /// >> dispute_period
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _disputePeriod;
        
        /// <summary>
        /// >> validators
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.IndexedVecT1 _validators;
        
        /// <summary>
        /// >> discovery_keys
        /// </summary>
        private Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_authority_discovery.app.Public> _discoveryKeys;
        
        /// <summary>
        /// >> assignment_keys
        /// </summary>
        private Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public> _assignmentKeys;
        
        /// <summary>
        /// >> validator_groups
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.IndexedVecT2 _validatorGroups;
        
        /// <summary>
        /// >> n_cores
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _nCores;
        
        /// <summary>
        /// >> zeroth_delay_tranche_width
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _zerothDelayTrancheWidth;
        
        /// <summary>
        /// >> relay_vrf_modulo_samples
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _relayVrfModuloSamples;
        
        /// <summary>
        /// >> n_delay_tranches
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _nDelayTranches;
        
        /// <summary>
        /// >> no_show_slots
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _noShowSlots;
        
        /// <summary>
        /// >> needed_approvals
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _neededApprovals;
        
        public Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex> ActiveValidatorIndices
        {
            get
            {
                return this._activeValidatorIndices;
            }
            set
            {
                this._activeValidatorIndices = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8 RandomSeed
        {
            get
            {
                return this._randomSeed;
            }
            set
            {
                this._randomSeed = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 DisputePeriod
        {
            get
            {
                return this._disputePeriod;
            }
            set
            {
                this._disputePeriod = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.IndexedVecT1 Validators
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
        
        public Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_authority_discovery.app.Public> DiscoveryKeys
        {
            get
            {
                return this._discoveryKeys;
            }
            set
            {
                this._discoveryKeys = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public> AssignmentKeys
        {
            get
            {
                return this._assignmentKeys;
            }
            set
            {
                this._assignmentKeys = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.IndexedVecT2 ValidatorGroups
        {
            get
            {
                return this._validatorGroups;
            }
            set
            {
                this._validatorGroups = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 NCores
        {
            get
            {
                return this._nCores;
            }
            set
            {
                this._nCores = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 ZerothDelayTrancheWidth
        {
            get
            {
                return this._zerothDelayTrancheWidth;
            }
            set
            {
                this._zerothDelayTrancheWidth = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 RelayVrfModuloSamples
        {
            get
            {
                return this._relayVrfModuloSamples;
            }
            set
            {
                this._relayVrfModuloSamples = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 NDelayTranches
        {
            get
            {
                return this._nDelayTranches;
            }
            set
            {
                this._nDelayTranches = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 NoShowSlots
        {
            get
            {
                return this._noShowSlots;
            }
            set
            {
                this._noShowSlots = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 NeededApprovals
        {
            get
            {
                return this._neededApprovals;
            }
            set
            {
                this._neededApprovals = value;
            }
        }
        
        public override string TypeName()
        {
            return "SessionInfo";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ActiveValidatorIndices.Encode());
            result.AddRange(RandomSeed.Encode());
            result.AddRange(DisputePeriod.Encode());
            result.AddRange(Validators.Encode());
            result.AddRange(DiscoveryKeys.Encode());
            result.AddRange(AssignmentKeys.Encode());
            result.AddRange(ValidatorGroups.Encode());
            result.AddRange(NCores.Encode());
            result.AddRange(ZerothDelayTrancheWidth.Encode());
            result.AddRange(RelayVrfModuloSamples.Encode());
            result.AddRange(NDelayTranches.Encode());
            result.AddRange(NoShowSlots.Encode());
            result.AddRange(NeededApprovals.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ActiveValidatorIndices = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex>();
            ActiveValidatorIndices.Decode(byteArray, ref p);
            RandomSeed = new Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8();
            RandomSeed.Decode(byteArray, ref p);
            DisputePeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            DisputePeriod.Decode(byteArray, ref p);
            Validators = new Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.IndexedVecT1();
            Validators.Decode(byteArray, ref p);
            DiscoveryKeys = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_authority_discovery.app.Public>();
            DiscoveryKeys.Decode(byteArray, ref p);
            AssignmentKeys = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public>();
            AssignmentKeys.Decode(byteArray, ref p);
            ValidatorGroups = new Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.IndexedVecT2();
            ValidatorGroups.Decode(byteArray, ref p);
            NCores = new Substrate.NetApi.Model.Types.Primitive.U32();
            NCores.Decode(byteArray, ref p);
            ZerothDelayTrancheWidth = new Substrate.NetApi.Model.Types.Primitive.U32();
            ZerothDelayTrancheWidth.Decode(byteArray, ref p);
            RelayVrfModuloSamples = new Substrate.NetApi.Model.Types.Primitive.U32();
            RelayVrfModuloSamples.Decode(byteArray, ref p);
            NDelayTranches = new Substrate.NetApi.Model.Types.Primitive.U32();
            NDelayTranches.Decode(byteArray, ref p);
            NoShowSlots = new Substrate.NetApi.Model.Types.Primitive.U32();
            NoShowSlots.Decode(byteArray, ref p);
            NeededApprovals = new Substrate.NetApi.Model.Types.Primitive.U32();
            NeededApprovals.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
