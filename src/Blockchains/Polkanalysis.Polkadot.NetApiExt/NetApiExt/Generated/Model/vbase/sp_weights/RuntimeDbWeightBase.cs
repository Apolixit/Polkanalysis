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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_weights
{
    /// <summary>
    /// >> 15830 - Composite[sp_weights.RuntimeDbWeightBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class RuntimeDbWeightBase : BaseType
    {
        /// <summary>
        /// >> read
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 Read { get; set; }
        /// <summary>
        /// >> write
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 Write { get; set; }

        public override System.String TypeName()
        {
            return "RuntimeDbWeightBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Read.Encode());
            result.AddRange(Write.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_weights.RuntimeDbWeightBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_weights.RuntimeDbWeightBase instance = null;
            if (version == 9300U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.sp_weights.RuntimeDbWeight();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_weights.RuntimeDbWeight();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_weights.RuntimeDbWeight();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_weights.RuntimeDbWeight();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_weights.RuntimeDbWeight();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_weights.RuntimeDbWeight();
                instance.Create(data);
            }

            return instance;
        }
    }
}