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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_conviction_voting.vote;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_conviction_voting.vote
{
    /// <summary>
    /// >> 4067 - Composite[pallet_conviction_voting.vote.Delegating]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Delegating : DelegatingBase
    {
        public override System.String TypeName()
        {
            return "Delegating";
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

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Balance = new Substrate.NetApi.Model.Types.Primitive.U128();
            Balance.Decode(byteArray, ref p);
            Target = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32();
            Target.Decode(byteArray, ref p);
            Conviction = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_conviction_voting.conviction.EnumConviction();
            Conviction.Decode(byteArray, ref p);
            Delegations = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_conviction_voting.types.Delegations();
            Delegations.Decode(byteArray, ref p);
            Prior = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_conviction_voting.vote.PriorLock();
            Prior.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}