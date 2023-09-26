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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1
{
    /// <summary>
    /// >> 20846 - Composite[polkadot_primitives.v1.CommittedCandidateReceiptBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class CommittedCandidateReceiptBase : BaseType
    {
        /// <summary>
        /// >> descriptor
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1.CandidateDescriptorBase Descriptor { get; set; }
        /// <summary>
        /// >> commitments
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1.CandidateCommitmentsBase Commitments { get; set; }

        public override System.String TypeName()
        {
            return "CommittedCandidateReceiptBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Descriptor.Encode());
            result.AddRange(Commitments.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1.CommittedCandidateReceiptBase Create(byte[] data, uint version)
        {
            Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1.CommittedCandidateReceiptBase instance = null;
            if (version == 9180U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.polkadot_primitives.v1.CommittedCandidateReceipt();
                instance.Create(data);
            }

            if (version == 9170U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9170.polkadot_primitives.v1.CommittedCandidateReceipt();
                instance.Create(data);
            }

            if (version == 9160U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.polkadot_primitives.v1.CommittedCandidateReceipt();
                instance.Create(data);
            }

            if (version == 9151U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.polkadot_primitives.v1.CommittedCandidateReceipt();
                instance.Create(data);
            }

            if (version == 9150U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.polkadot_primitives.v1.CommittedCandidateReceipt();
                instance.Create(data);
            }

            if (version == 9130U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.polkadot_primitives.v1.CommittedCandidateReceipt();
                instance.Create(data);
            }

            if (version == 9122U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.polkadot_primitives.v1.CommittedCandidateReceipt();
                instance.Create(data);
            }

            if (version == 9111U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.polkadot_primitives.v1.CommittedCandidateReceipt();
                instance.Create(data);
            }

            return instance;
        }
    }
}