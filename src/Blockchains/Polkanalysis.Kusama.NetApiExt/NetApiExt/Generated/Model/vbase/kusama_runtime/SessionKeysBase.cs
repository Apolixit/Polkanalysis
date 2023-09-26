//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Attributes;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.kusama_runtime
{
    /// <summary>
    /// >> 20405 - Composite[kusama_runtime.SessionKeysBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class SessionKeysBase : BaseType
    {
        /// <summary>
        /// >> grandpa
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_consensus_grandpa.app.PublicBase Grandpa { get; set; }
        /// <summary>
        /// >> babe
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_consensus_babe.app.PublicBase Babe { get; set; }
        /// <summary>
        /// >> im_online
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_im_online.sr25519.app_sr25519.PublicBase ImOnline { get; set; }
        /// <summary>
        /// >> para_validator
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.validator_app.PublicBase ParaValidator { get; set; }
        /// <summary>
        /// >> para_assignment
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.assignment_app.PublicBase ParaAssignment { get; set; }
        /// <summary>
        /// >> authority_discovery
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_authority_discovery.app.PublicBase AuthorityDiscovery { get; set; }
        /// <summary>
        /// >> grandpa1
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_finality_grandpa.app.PublicBase Grandpa1 { get; set; }
        /// <summary>
        /// >> para_validator1
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.validator_app.PublicBase ParaValidator1 { get; set; }
        /// <summary>
        /// >> para_assignment1
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.assignment_app.PublicBase ParaAssignment1 { get; set; }
        /// <summary>
        /// >> para_validator2
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v0.validator_app.PublicBase ParaValidator2 { get; set; }
        /// <summary>
        /// >> para_assignment2
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1.assignment_app.PublicBase ParaAssignment2 { get; set; }

        public override System.String TypeName()
        {
            return "SessionKeysBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Grandpa.Encode());
            result.AddRange(Babe.Encode());
            result.AddRange(ImOnline.Encode());
            result.AddRange(ParaValidator.Encode());
            result.AddRange(ParaAssignment.Encode());
            result.AddRange(AuthorityDiscovery.Encode());
            result.AddRange(Grandpa1.Encode());
            result.AddRange(ParaValidator1.Encode());
            result.AddRange(ParaAssignment1.Encode());
            result.AddRange(ParaValidator2.Encode());
            result.AddRange(ParaAssignment2.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.kusama_runtime.SessionKeysBase Create(byte[] data, uint version)
        {
            Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.kusama_runtime.SessionKeysBase instance = null;
            if (version == 9430U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9381U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9350U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9320U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9300U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9291U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9271U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9230U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9220U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9200U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9190U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9180U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9170U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9170.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9160U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9151U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9150U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9130U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9122U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            if (version == 9111U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.kusama_runtime.SessionKeys();
                instance.Create(data);
            }

            return instance;
        }
    }
}