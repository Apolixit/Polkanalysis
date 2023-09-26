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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_consensus_slots
{
    /// <summary>
    /// >> 20398 - Composite[sp_consensus_slots.EquivocationProofBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class EquivocationProofBase : BaseType
    {
        /// <summary>
        /// >> offender
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_consensus_babe.app.PublicBase Offender { get; set; }
        /// <summary>
        /// >> slot
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_consensus_slots.SlotBase Slot { get; set; }
        /// <summary>
        /// >> first_header
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_runtime.generic.header.HeaderBase FirstHeader { get; set; }
        /// <summary>
        /// >> second_header
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_runtime.generic.header.HeaderBase SecondHeader { get; set; }

        public override System.String TypeName()
        {
            return "EquivocationProofBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Offender.Encode());
            result.AddRange(Slot.Encode());
            result.AddRange(FirstHeader.Encode());
            result.AddRange(SecondHeader.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_consensus_slots.EquivocationProofBase Create(byte[] data, uint version)
        {
            Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_consensus_slots.EquivocationProofBase instance = null;
            if (version == 9430U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9381U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9350U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9320U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9300U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9291U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9271U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9230U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9220U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9200U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9190U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9180U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9170U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9170.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9160U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9151U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9150U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9130U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9122U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            if (version == 9111U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_consensus_slots.EquivocationProof();
                instance.Create(data);
            }

            return instance;
        }
    }
}