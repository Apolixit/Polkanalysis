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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_fast_unstake.types;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_fast_unstake.types
{
    /// <summary>
    /// >> 744 - Composite[pallet_fast_unstake.types.UnstakeRequest]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class UnstakeRequest : UnstakeRequestBase
    {
        public override System.String TypeName()
        {
            return "UnstakeRequest";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Stashes.Encode());
            result.AddRange(Checked.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Stashes = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>();
            Stashes.Decode(byteArray, ref p);
            Checked = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>();
            Checked.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}