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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4
{
    /// <summary>
    /// >> 20619 - Composite[polkadot_primitives.v4.ParathreadClaimBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class ParathreadClaimBase : BaseType
    {
        /// <summary>
        /// >> Id
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase Id { get; set; }
        /// <summary>
        /// >> CollatorId
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.collator_app.PublicBase CollatorId { get; set; }

        public override System.String TypeName()
        {
            return "ParathreadClaimBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(CollatorId.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.ParathreadClaimBase Create(byte[] data, uint version)
        {
            Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.ParathreadClaimBase instance = null;
            if (version == 9430U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.polkadot_primitives.v4.ParathreadClaim();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_primitives.v4.ParathreadClaim();
                instance.Create(data);
            }

            return instance;
        }
    }
}