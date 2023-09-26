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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.frame_support.weights
{
    /// <summary>
    /// >> 20764 - Composite[frame_support.weights.PerDispatchClassT3Base]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class PerDispatchClassT3Base : BaseType
    {
        /// <summary>
        /// >> normal
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Normal { get; set; }
        /// <summary>
        /// >> operational
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Operational { get; set; }
        /// <summary>
        /// >> mandatory
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Mandatory { get; set; }

        public override System.String TypeName()
        {
            return "PerDispatchClassT3Base";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Normal.Encode());
            result.AddRange(Operational.Encode());
            result.AddRange(Mandatory.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.frame_support.weights.PerDispatchClassT3Base Create(byte[] data, uint version)
        {
            Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.frame_support.weights.PerDispatchClassT3Base instance = null;
            if (version == 9291U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9271U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9230U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9220U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9200U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9190U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9180U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9170U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9170.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9160U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9151U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9150U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9130U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9122U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            if (version == 9111U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.frame_support.weights.PerDispatchClassT3();
                instance.Create(data);
            }

            return instance;
        }
    }
}