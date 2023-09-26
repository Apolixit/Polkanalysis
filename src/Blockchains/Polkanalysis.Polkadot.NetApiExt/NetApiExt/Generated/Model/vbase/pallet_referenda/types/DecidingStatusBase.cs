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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_referenda.types
{
    /// <summary>
    /// >> 15959 - Composite[pallet_referenda.types.DecidingStatusBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class DecidingStatusBase : BaseType
    {
        /// <summary>
        /// >> since
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Since { get; set; }
        /// <summary>
        /// >> confirming
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseValue Confirming { get; set; }

        public override System.String TypeName()
        {
            return "DecidingStatusBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Since.Encode());
            result.AddRange(Confirming.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_referenda.types.DecidingStatusBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_referenda.types.DecidingStatusBase instance = null;
            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_referenda.types.DecidingStatus();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_referenda.types.DecidingStatus();
                instance.Create(data);
            }

            return instance;
        }
    }
}