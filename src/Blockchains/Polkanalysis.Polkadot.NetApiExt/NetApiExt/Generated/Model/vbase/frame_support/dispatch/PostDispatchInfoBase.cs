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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.dispatch
{
    /// <summary>
    /// >> 15920 - Composite[frame_support.dispatch.PostDispatchInfoBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class PostDispatchInfoBase : BaseType
    {
        /// <summary>
        /// >> actual_weight
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseValue ActualWeight { get; set; }
        /// <summary>
        /// >> pays_fee
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnum PaysFee { get; set; }

        public override System.String TypeName()
        {
            return "PostDispatchInfoBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ActualWeight.Encode());
            result.AddRange(PaysFee.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.dispatch.PostDispatchInfoBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.dispatch.PostDispatchInfoBase instance = null;
            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.frame_support.dispatch.PostDispatchInfo();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.frame_support.dispatch.PostDispatchInfo();
                instance.Create(data);
            }

            return instance;
        }
    }
}