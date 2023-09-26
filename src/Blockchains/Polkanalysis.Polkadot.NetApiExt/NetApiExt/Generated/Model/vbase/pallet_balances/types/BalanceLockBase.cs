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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.types
{
    /// <summary>
    /// >> 15932 - Composite[pallet_balances.types.BalanceLockBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class BalanceLockBase : BaseType
    {
        /// <summary>
        /// >> id
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr8U8 Id { get; set; }
        /// <summary>
        /// >> amount
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Amount { get; set; }
        /// <summary>
        /// >> reasons
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnum Reasons { get; set; }

        public override System.String TypeName()
        {
            return "BalanceLockBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Amount.Encode());
            result.AddRange(Reasons.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.types.BalanceLockBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.types.BalanceLockBase instance = null;
            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_balances.types.BalanceLock();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_balances.types.BalanceLock();
                instance.Create(data);
            }

            return instance;
        }
    }
}