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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_child_bounties;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.pallet_child_bounties
{
    /// <summary>
    /// >> 8298 - Composite[pallet_child_bounties.ChildBounty]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ChildBounty : ChildBountyBase
    {
        public override System.String TypeName()
        {
            return "ChildBounty";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ParentBounty.Encode());
            result.AddRange(Value.Encode());
            result.AddRange(Fee.Encode());
            result.AddRange(CuratorDeposit.Encode());
            result.AddRange(Status.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ParentBounty = new Substrate.NetApi.Model.Types.Primitive.U32();
            ParentBounty.Decode(byteArray, ref p);
            Value = new Substrate.NetApi.Model.Types.Primitive.U128();
            Value.Decode(byteArray, ref p);
            Fee = new Substrate.NetApi.Model.Types.Primitive.U128();
            Fee.Decode(byteArray, ref p);
            CuratorDeposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            CuratorDeposit.Decode(byteArray, ref p);
            Status = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.pallet_child_bounties.EnumChildBountyStatus();
            Status.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}