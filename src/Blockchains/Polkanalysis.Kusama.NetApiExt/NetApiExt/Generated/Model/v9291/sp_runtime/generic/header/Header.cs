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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_runtime.generic.header;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.sp_runtime.generic.header
{
    /// <summary>
    /// >> 7859 - Composite[sp_runtime.generic.header.Header]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Header : HeaderBase
    {
        public override System.String TypeName()
        {
            return "Header";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ParentHash.Encode());
            result.AddRange(Number.Encode());
            result.AddRange(StateRoot.Encode());
            result.AddRange(ExtrinsicsRoot.Encode());
            result.AddRange(Digest.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ParentHash = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.primitive_types.H256();
            ParentHash.Decode(byteArray, ref p);
            Number = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>();
            Number.Decode(byteArray, ref p);
            StateRoot = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.primitive_types.H256();
            StateRoot.Decode(byteArray, ref p);
            ExtrinsicsRoot = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.primitive_types.H256();
            ExtrinsicsRoot.Decode(byteArray, ref p);
            Digest = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.sp_runtime.generic.digest.Digest();
            Digest.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}