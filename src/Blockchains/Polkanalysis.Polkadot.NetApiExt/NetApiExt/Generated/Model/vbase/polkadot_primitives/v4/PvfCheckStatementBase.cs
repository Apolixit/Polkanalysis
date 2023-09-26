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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4
{
    /// <summary>
    /// >> 15904 - Composite[polkadot_primitives.v4.PvfCheckStatementBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class PvfCheckStatementBase : BaseType
    {
        /// <summary>
        /// >> accept
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.Bool Accept { get; set; }
        /// <summary>
        /// >> subject
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase Subject { get; set; }
        /// <summary>
        /// >> session_index
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 SessionIndex { get; set; }
        /// <summary>
        /// >> validator_index
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.ValidatorIndexBase ValidatorIndex { get; set; }

        public override System.String TypeName()
        {
            return "PvfCheckStatementBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Accept.Encode());
            result.AddRange(Subject.Encode());
            result.AddRange(SessionIndex.Encode());
            result.AddRange(ValidatorIndex.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.PvfCheckStatementBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.PvfCheckStatementBase instance = null;
            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_primitives.v4.PvfCheckStatement();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.polkadot_primitives.v4.PvfCheckStatement();
                instance.Create(data);
            }

            return instance;
        }
    }
}