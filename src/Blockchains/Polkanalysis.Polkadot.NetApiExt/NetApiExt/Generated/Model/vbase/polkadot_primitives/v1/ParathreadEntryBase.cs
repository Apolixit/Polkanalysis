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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1
{
    /// <summary>
    /// >> 15710 - Composite[polkadot_primitives.v1.ParathreadEntryBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class ParathreadEntryBase : BaseType
    {
        /// <summary>
        /// >> claim
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1.ParathreadClaimBase Claim { get; set; }
        /// <summary>
        /// >> retries
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Retries { get; set; }

        public override System.String TypeName()
        {
            return "ParathreadEntryBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Claim.Encode());
            result.AddRange(Retries.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1.ParathreadEntryBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1.ParathreadEntryBase instance = null;
            if (version == 9110U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_primitives.v1.ParathreadEntry();
                instance.Create(data);
            }

            if (version == 9122U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.polkadot_primitives.v1.ParathreadEntry();
                instance.Create(data);
            }

            if (version == 9140U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.polkadot_primitives.v1.ParathreadEntry();
                instance.Create(data);
            }

            if (version == 9151U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.polkadot_primitives.v1.ParathreadEntry();
                instance.Create(data);
            }

            if (version == 9170U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_primitives.v1.ParathreadEntry();
                instance.Create(data);
            }

            if (version == 9180U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.polkadot_primitives.v1.ParathreadEntry();
                instance.Create(data);
            }

            return instance;
        }
    }
}