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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.signed
{
    /// <summary>
    /// >> 20667 - Composite[polkadot_primitives.v2.signed.UncheckedSignedBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class UncheckedSignedBase : BaseType
    {
        /// <summary>
        /// >> payload
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.AvailabilityBitfieldBase Payload { get; set; }
        /// <summary>
        /// >> validator_index
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.ValidatorIndexBase ValidatorIndex { get; set; }
        /// <summary>
        /// >> signature
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.validator_app.SignatureBase Signature { get; set; }

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

        public static Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.signed.UncheckedSignedBase Create(byte[] data, uint version)
        {
            Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.signed.UncheckedSignedBase instance = null;
            if (version == 9381U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9350U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9320U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9300U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9291U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9271U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9230U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9220U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9200U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            if (version == 9190U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.polkadot_primitives.v2.signed.UncheckedSigned();
                instance.Create(data);
            }

            return instance;
        }
    }
}