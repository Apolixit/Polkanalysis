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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_babe.digests
{
    /// <summary>
    /// >> 15783 - Composite[sp_consensus_babe.digests.SecondaryVRFPreDigestBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class SecondaryVRFPreDigestBase : BaseType
    {
        /// <summary>
        /// >> authority_index
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 AuthorityIndex { get; set; }
        /// <summary>
        /// >> slot
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_slots.SlotBase Slot { get; set; }
        /// <summary>
        /// >> vrf_output
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8 VrfOutput { get; set; }
        /// <summary>
        /// >> vrf_proof
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr64U8 VrfProof { get; set; }
        /// <summary>
        /// >> vrf_signature
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.vrf.VrfSignatureBase VrfSignature { get; set; }

        public override System.String TypeName()
        {
            return "SecondaryVRFPreDigestBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(AuthorityIndex.Encode());
            result.AddRange(Slot.Encode());
            result.AddRange(VrfOutput.Encode());
            result.AddRange(VrfProof.Encode());
            result.AddRange(VrfSignature.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_babe.digests.SecondaryVRFPreDigestBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_babe.digests.SecondaryVRFPreDigestBase instance = null;
            if (version == 9220U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            if (version == 9230U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            if (version == 9270U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9280.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            if (version == 9281U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            if (version == 9291U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            if (version == 9300U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_consensus_babe.digests.SecondaryVRFPreDigest();
                instance.Create(data);
            }

            return instance;
        }
    }
}