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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_message_queue
{
    /// <summary>
    /// >> 15995 - Composite[pallet_message_queue.NeighboursBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class NeighboursBase : BaseType
    {
        /// <summary>
        /// >> prev
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnum Prev { get; set; }
        /// <summary>
        /// >> next
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnum Next { get; set; }

        public override System.String TypeName()
        {
            return "NeighboursBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Prev.Encode());
            result.AddRange(Next.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_message_queue.NeighboursBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_message_queue.NeighboursBase instance = null;
            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_message_queue.Neighbours();
                instance.Create(data);
            }

            return instance;
        }
    }
}