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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.bounded_collections.weak_bounded_vec
{
    /// <summary>
    /// >> 15941 - Composite[bounded_collections.weak_bounded_vec.WeakBoundedVecT5Base]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class WeakBoundedVecT5Base : BaseType
    {
        /// <summary>
        /// >> value
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable Value { get; set; }

        public override System.String TypeName()
        {
            return "WeakBoundedVecT5Base";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.bounded_collections.weak_bounded_vec.WeakBoundedVecT5Base Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.bounded_collections.weak_bounded_vec.WeakBoundedVecT5Base instance = null;
            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.bounded_collections.weak_bounded_vec.WeakBoundedVecT5();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.bounded_collections.weak_bounded_vec.WeakBoundedVecT5();
                instance.Create(data);
            }

            return instance;
        }
    }
}