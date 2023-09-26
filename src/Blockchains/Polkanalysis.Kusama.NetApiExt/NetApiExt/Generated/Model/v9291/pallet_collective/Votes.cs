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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_collective;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.pallet_collective
{
    /// <summary>
    /// >> 8226 - Composite[pallet_collective.Votes]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Votes : VotesBase
    {
        public override System.String TypeName()
        {
            return "Votes";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Index.Encode());
            result.AddRange(Threshold.Encode());
            result.AddRange(Ayes.Encode());
            result.AddRange(Nays.Encode());
            result.AddRange(End.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Index = new Substrate.NetApi.Model.Types.Primitive.U32();
            Index.Decode(byteArray, ref p);
            Threshold = new Substrate.NetApi.Model.Types.Primitive.U32();
            Threshold.Decode(byteArray, ref p);
            Ayes = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.sp_core.crypto.AccountId32>();
            Ayes.Decode(byteArray, ref p);
            Nays = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.sp_core.crypto.AccountId32>();
            Nays.Decode(byteArray, ref p);
            End = new Substrate.NetApi.Model.Types.Primitive.U32();
            End.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}