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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_collective
{
    /// <summary>
    /// >> 15679 - Composite[pallet_collective.VotesBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class VotesBase : BaseType
    {
        /// <summary>
        /// >> index
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Index { get; set; }
        /// <summary>
        /// >> threshold
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Threshold { get; set; }
        /// <summary>
        /// >> ayes
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable Ayes { get; set; }
        /// <summary>
        /// >> nays
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable Nays { get; set; }
        /// <summary>
        /// >> end
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 End { get; set; }

        public override System.String TypeName()
        {
            return "VotesBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Index.Encode());
            result.AddRange(Threshold.Encode());
            result.AddRange(Ayes.Encode());
            result.AddRange(Nays.Encode());
            result.AddRange(End.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_collective.VotesBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_collective.VotesBase instance = null;
            if (version == 9110U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9122U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9140U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9151U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9170U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9180U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9190U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9200U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9220U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9230U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9270U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9280.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9281U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9291U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9300U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_collective.Votes();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_collective.Votes();
                instance.Create(data);
            }

            return instance;
        }
    }
}