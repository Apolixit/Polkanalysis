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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1.signed
{
    /// <summary>
    /// >> 15633 - Composite[polkadot_primitives.v1.signed.UncheckedSignedBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class UncheckedSignedBase : BaseType
    {
        /// <summary>
        /// >> payload
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1.AvailabilityBitfieldBase Payload { get; set; }
        /// <summary>
        /// >> validator_index
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v0.ValidatorIndexBase ValidatorIndex { get; set; }
        /// <summary>
        /// >> signature
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v0.validator_app.SignatureBase Signature { get; set; }

        public override System.String TypeName()
        {
            return "UncheckedSignedBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Payload.Encode());
            result.AddRange(ValidatorIndex.Encode());
            result.AddRange(Signature.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1.signed.UncheckedSignedBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1.signed.UncheckedSignedBase instance = null;
            if (version == 9110U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_primitives.v1.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9122U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.polkadot_primitives.v1.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9140U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.polkadot_primitives.v1.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9151U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.polkadot_primitives.v1.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9170U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_primitives.v1.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9180U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.polkadot_primitives.v1.signed.UncheckedSigned();
                instance.Create(data);
            }

            return instance;
        }
    }
}