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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_nomination_pools
{
    /// <summary>
    /// >> 13042 - Composite[pallet_nomination_pools.SubPools]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SubPools : SubPoolsBase
    {
        public override System.String TypeName()
        {
            return "SubPools";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(NoEra.Encode());
            result.AddRange(WithEra.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            NoEra = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_nomination_pools.UnbondPool();
            NoEra.Decode(byteArray, ref p);
            WithEra = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.pallet_nomination_pools.UnbondPool>>();
            WithEra.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}