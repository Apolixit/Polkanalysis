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
    /// >> 15824 - Composite[frame_support.dispatch.PerDispatchClassT1Base]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class PerDispatchClassT1Base : BaseType
    {
        /// <summary>
        /// >> normal
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_weights.weight_v2.WeightBase Normal { get; set; }
        /// <summary>
        /// >> operational
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_weights.weight_v2.WeightBase Operational { get; set; }
        /// <summary>
        /// >> mandatory
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_weights.weight_v2.WeightBase Mandatory { get; set; }

        public override System.String TypeName()
        {
            return "PerDispatchClassT1Base";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Normal.Encode());
            result.AddRange(Operational.Encode());
            result.AddRange(Mandatory.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.dispatch.PerDispatchClassT1Base Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.dispatch.PerDispatchClassT1Base instance = null;
            if (version == 9300U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.frame_support.dispatch.PerDispatchClassT1();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.frame_support.dispatch.PerDispatchClassT1();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.frame_support.dispatch.PerDispatchClassT1();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.frame_support.dispatch.PerDispatchClassT1();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.frame_support.dispatch.PerDispatchClassT1();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.frame_support.dispatch.PerDispatchClassT1();
                instance.Create(data);
            }

            return instance;
        }
    }
}