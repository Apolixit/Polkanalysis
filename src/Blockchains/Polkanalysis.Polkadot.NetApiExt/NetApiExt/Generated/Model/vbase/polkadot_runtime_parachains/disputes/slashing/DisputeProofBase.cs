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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.disputes.slashing
{
    /// <summary>
    /// >> 15990 - Composite[polkadot_runtime_parachains.disputes.slashing.DisputeProofBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class DisputeProofBase : BaseType
    {
        /// <summary>
        /// >> time_slot
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.disputes.slashing.DisputesTimeSlotBase TimeSlot { get; set; }
        /// <summary>
        /// >> kind
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnum Kind { get; set; }
        /// <summary>
        /// >> validator_index
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.ValidatorIndexBase ValidatorIndex { get; set; }
        /// <summary>
        /// >> validator_id
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.validator_app.PublicBase ValidatorId { get; set; }

        public override System.String TypeName()
        {
            return "DisputeProofBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(TimeSlot.Encode());
            result.AddRange(Kind.Encode());
            result.AddRange(ValidatorIndex.Encode());
            result.AddRange(ValidatorId.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.disputes.slashing.DisputeProofBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.disputes.slashing.DisputeProofBase instance = null;
            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.polkadot_runtime_parachains.disputes.slashing.DisputeProof();
                instance.Create(data);
            }

            return instance;
        }
    }
}