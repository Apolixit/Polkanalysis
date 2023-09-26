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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2
{
    /// <summary>
    /// >> 15774 - Composite[polkadot_primitives.v2.CandidateCommitmentsBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class CandidateCommitmentsBase : BaseType
    {
        /// <summary>
        /// >> upward_messages
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable UpwardMessages { get; set; }
        /// <summary>
        /// >> horizontal_messages
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable HorizontalMessages { get; set; }
        /// <summary>
        /// >> new_validation_code
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseValue NewValidationCode { get; set; }
        /// <summary>
        /// >> head_data
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.HeadDataBase HeadData { get; set; }
        /// <summary>
        /// >> processed_downward_messages
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 ProcessedDownwardMessages { get; set; }
        /// <summary>
        /// >> hrmp_watermark
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 HrmpWatermark { get; set; }

        public override System.String TypeName()
        {
            return "CandidateCommitmentsBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(UpwardMessages.Encode());
            result.AddRange(HorizontalMessages.Encode());
            result.AddRange(NewValidationCode.Encode());
            result.AddRange(HeadData.Encode());
            result.AddRange(ProcessedDownwardMessages.Encode());
            result.AddRange(HrmpWatermark.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.CandidateCommitmentsBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.CandidateCommitmentsBase instance = null;
            if (version == 9190U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            if (version == 9200U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            if (version == 9220U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            if (version == 9230U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            if (version == 9270U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9280.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            if (version == 9281U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            if (version == 9291U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            if (version == 9300U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_primitives.v2.CandidateCommitments();
                instance.Create(data);
            }

            return instance;
        }
    }
}