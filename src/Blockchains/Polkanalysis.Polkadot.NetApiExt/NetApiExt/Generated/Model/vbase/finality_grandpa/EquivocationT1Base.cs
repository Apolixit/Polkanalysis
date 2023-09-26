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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.finality_grandpa
{
    /// <summary>
    /// >> 15610 - Composite[finality_grandpa.EquivocationT1Base]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class EquivocationT1Base : BaseType
    {
        /// <summary>
        /// >> round_number
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 RoundNumber { get; set; }
        /// <summary>
        /// >> identity
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_finality_grandpa.app.PublicBase Identity { get; set; }
        /// <summary>
        /// >> first
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable First { get; set; }
        /// <summary>
        /// >> second
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable Second { get; set; }
        /// <summary>
        /// >> identity1
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_grandpa.app.PublicBase Identity1 { get; set; }

        public override System.String TypeName()
        {
            return "EquivocationT1Base";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(RoundNumber.Encode());
            result.AddRange(Identity.Encode());
            result.AddRange(First.Encode());
            result.AddRange(Second.Encode());
            result.AddRange(Identity1.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.finality_grandpa.EquivocationT1Base Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.finality_grandpa.EquivocationT1Base instance = null;
            if (version == 9110U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9122U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9140U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9151U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9170U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9180U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9190U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9200U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9220U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9230U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9270U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9280.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9281U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9291U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9300U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.finality_grandpa.EquivocationT1();
                instance.Create(data);
            }

            return instance;
        }
    }
}