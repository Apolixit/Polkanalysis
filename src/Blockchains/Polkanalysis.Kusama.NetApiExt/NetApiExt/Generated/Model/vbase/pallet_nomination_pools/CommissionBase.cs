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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_nomination_pools
{
    /// <summary>
    /// >> 20601 - Composite[pallet_nomination_pools.CommissionBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class CommissionBase : BaseType
    {
        /// <summary>
        /// >> current
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseValue Current { get; set; }
        /// <summary>
        /// >> max
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseValue Max { get; set; }
        /// <summary>
        /// >> change_rate
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseValue ChangeRate { get; set; }
        /// <summary>
        /// >> throttle_from
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseValue ThrottleFrom { get; set; }

        public override System.String TypeName()
        {
            return "CommissionBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Current.Encode());
            result.AddRange(Max.Encode());
            result.AddRange(ChangeRate.Encode());
            result.AddRange(ThrottleFrom.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.CommissionBase Create(byte[] data, uint version)
        {
            Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.CommissionBase instance = null;
            if (version == 9430U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_nomination_pools.Commission();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_nomination_pools.Commission();
                instance.Create(data);
            }

            return instance;
        }
    }
}