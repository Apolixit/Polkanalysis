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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_runtime.bounded.weak_bounded_vec
{
    /// <summary>
    /// >> 20768 - Composite[sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT3Base]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class WeakBoundedVecT3Base : BaseType
    {
        /// <summary>
        /// >> value
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable Value { get; set; }

        public override System.String TypeName()
        {
            return "WeakBoundedVecT3Base";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT3Base Create(byte[] data, uint version)
        {
            Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT3Base instance = null;
            if (version == 9291U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT3();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT3();
                instance.Create(data);
            }

            if (version == 9271U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT3();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT3();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.sp_runtime.bounded.weak_bounded_vec.WeakBoundedVecT3();
                instance.Create(data);
            }

            return instance;
        }
    }
}