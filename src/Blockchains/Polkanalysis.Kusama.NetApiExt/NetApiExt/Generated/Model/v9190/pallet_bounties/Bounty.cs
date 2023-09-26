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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_bounties;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.pallet_bounties
{
    /// <summary>
    /// >> 14470 - Composite[pallet_bounties.Bounty]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Bounty : BountyBase
    {
        public override System.String TypeName()
        {
            return "Bounty";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Proposer.Encode());
            result.AddRange(Value.Encode());
            result.AddRange(Fee.Encode());
            result.AddRange(CuratorDeposit.Encode());
            result.AddRange(Bond.Encode());
            result.AddRange(Status.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Proposer = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.sp_core.crypto.AccountId32();
            Proposer.Decode(byteArray, ref p);
            Value = new Substrate.NetApi.Model.Types.Primitive.U128();
            Value.Decode(byteArray, ref p);
            Fee = new Substrate.NetApi.Model.Types.Primitive.U128();
            Fee.Decode(byteArray, ref p);
            CuratorDeposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            CuratorDeposit.Decode(byteArray, ref p);
            Bond = new Substrate.NetApi.Model.Types.Primitive.U128();
            Bond.Decode(byteArray, ref p);
            Status = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.pallet_bounties.EnumBountyStatus();
            Status.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}