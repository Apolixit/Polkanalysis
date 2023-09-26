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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_conviction_voting.vote
{
    /// <summary>
    /// >> 15955 - Composite[pallet_conviction_voting.vote.DelegatingBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class DelegatingBase : BaseType
    {
        /// <summary>
        /// >> balance
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Balance { get; set; }
        /// <summary>
        /// >> target
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base Target { get; set; }
        /// <summary>
        /// >> conviction
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnum Conviction { get; set; }
        /// <summary>
        /// >> delegations
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_conviction_voting.types.DelegationsBase Delegations { get; set; }
        /// <summary>
        /// >> prior
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_conviction_voting.vote.PriorLockBase Prior { get; set; }

        public override System.String TypeName()
        {
            return "DelegatingBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Balance.Encode());
            result.AddRange(Target.Encode());
            result.AddRange(Conviction.Encode());
            result.AddRange(Delegations.Encode());
            result.AddRange(Prior.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_conviction_voting.vote.DelegatingBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_conviction_voting.vote.DelegatingBase instance = null;
            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_conviction_voting.vote.Delegating();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_conviction_voting.vote.Delegating();
                instance.Create(data);
            }

            return instance;
        }
    }
}