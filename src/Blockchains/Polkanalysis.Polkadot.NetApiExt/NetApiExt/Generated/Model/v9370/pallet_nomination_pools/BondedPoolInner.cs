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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_nomination_pools
{
    /// <summary>
    /// >> 13778 - Composite[pallet_nomination_pools.BondedPoolInner]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BondedPoolInner : BondedPoolInnerBase
    {
        public override System.String TypeName()
        {
            return "BondedPoolInner";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Points.Encode());
            result.AddRange(State.Encode());
            result.AddRange(MemberCounter.Encode());
            result.AddRange(Roles.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Points = new Substrate.NetApi.Model.Types.Primitive.U128();
            Points.Decode(byteArray, ref p);
            State = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_nomination_pools.EnumPoolState();
            State.Decode(byteArray, ref p);
            MemberCounter = new Substrate.NetApi.Model.Types.Primitive.U32();
            MemberCounter.Decode(byteArray, ref p);
            Roles = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_nomination_pools.PoolRoles();
            Roles.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}