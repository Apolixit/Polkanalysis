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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.disputes.slashing
{
    /// <summary>
    /// >> 20635 - Composite[polkadot_runtime_parachains.disputes.slashing.PendingSlashesBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class PendingSlashesBase : BaseType
    {
        /// <summary>
        /// >> keys
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable Keys { get; set; }
        /// <summary>
        /// >> kind
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnum Kind { get; set; }

        public override System.String TypeName()
        {
            return "PendingSlashesBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Keys.Encode());
            result.AddRange(Kind.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.disputes.slashing.PendingSlashesBase Create(byte[] data, uint version)
        {
            Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.disputes.slashing.PendingSlashesBase instance = null;
            if (version == 9430U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.polkadot_runtime_parachains.disputes.slashing.PendingSlashes();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_runtime_parachains.disputes.slashing.PendingSlashes();
                instance.Create(data);
            }

            return instance;
        }
    }
}