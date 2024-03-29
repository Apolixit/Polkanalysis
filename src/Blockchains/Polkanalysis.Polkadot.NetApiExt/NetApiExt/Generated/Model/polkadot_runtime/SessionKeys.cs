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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime
{
    
    
    /// <summary>
    /// >> 215 - Composite[polkadot_runtime.SessionKeys]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SessionKeys : BaseType
    {
        
        /// <summary>
        /// >> grandpa
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_finality_grandpa.app.Public _grandpa;
        
        /// <summary>
        /// >> babe
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.app.Public _babe;
        
        /// <summary>
        /// >> im_online
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_im_online.sr25519.app_sr25519.Public _imOnline;
        
        /// <summary>
        /// >> para_validator
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public _paraValidator;
        
        /// <summary>
        /// >> para_assignment
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public _paraAssignment;
        
        /// <summary>
        /// >> authority_discovery
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_authority_discovery.app.Public _authorityDiscovery;
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_finality_grandpa.app.Public Grandpa
        {
            get
            {
                return this._grandpa;
            }
            set
            {
                this._grandpa = value;
            }
        }
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.app.Public Babe
        {
            get
            {
                return this._babe;
            }
            set
            {
                this._babe = value;
            }
        }
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_im_online.sr25519.app_sr25519.Public ImOnline
        {
            get
            {
                return this._imOnline;
            }
            set
            {
                this._imOnline = value;
            }
        }
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public ParaValidator
        {
            get
            {
                return this._paraValidator;
            }
            set
            {
                this._paraValidator = value;
            }
        }
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public ParaAssignment
        {
            get
            {
                return this._paraAssignment;
            }
            set
            {
                this._paraAssignment = value;
            }
        }
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_authority_discovery.app.Public AuthorityDiscovery
        {
            get
            {
                return this._authorityDiscovery;
            }
            set
            {
                this._authorityDiscovery = value;
            }
        }
        
        public override string TypeName()
        {
            return "SessionKeys";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Grandpa.Encode());
            result.AddRange(Babe.Encode());
            result.AddRange(ImOnline.Encode());
            result.AddRange(ParaValidator.Encode());
            result.AddRange(ParaAssignment.Encode());
            result.AddRange(AuthorityDiscovery.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Grandpa = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_finality_grandpa.app.Public();
            Grandpa.Decode(byteArray, ref p);
            Babe = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.app.Public();
            Babe.Decode(byteArray, ref p);
            ImOnline = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_im_online.sr25519.app_sr25519.Public();
            ImOnline.Decode(byteArray, ref p);
            ParaValidator = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public();
            ParaValidator.Decode(byteArray, ref p);
            ParaAssignment = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public();
            ParaAssignment.Decode(byteArray, ref p);
            AuthorityDiscovery = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_authority_discovery.app.Public();
            AuthorityDiscovery.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
