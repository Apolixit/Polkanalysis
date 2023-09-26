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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_version;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.sp_version
{
    /// <summary>
    /// >> 14766 - Composite[sp_version.RuntimeVersion]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class RuntimeVersion : RuntimeVersionBase
    {
        public override System.String TypeName()
        {
            return "RuntimeVersion";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(SpecName.Encode());
            result.AddRange(ImplName.Encode());
            result.AddRange(AuthoringVersion.Encode());
            result.AddRange(SpecVersion.Encode());
            result.AddRange(ImplVersion.Encode());
            result.AddRange(Apis.Encode());
            result.AddRange(TransactionVersion.Encode());
            result.AddRange(StateVersion.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            SpecName = new Substrate.NetApi.Model.Types.Primitive.Str();
            SpecName.Decode(byteArray, ref p);
            ImplName = new Substrate.NetApi.Model.Types.Primitive.Str();
            ImplName.Decode(byteArray, ref p);
            AuthoringVersion = new Substrate.NetApi.Model.Types.Primitive.U32();
            AuthoringVersion.Decode(byteArray, ref p);
            SpecVersion = new Substrate.NetApi.Model.Types.Primitive.U32();
            SpecVersion.Decode(byteArray, ref p);
            ImplVersion = new Substrate.NetApi.Model.Types.Primitive.U32();
            ImplVersion.Decode(byteArray, ref p);
            Apis = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.Cow();
            Apis.Decode(byteArray, ref p);
            TransactionVersion = new Substrate.NetApi.Model.Types.Primitive.U32();
            TransactionVersion.Decode(byteArray, ref p);
            StateVersion = new Substrate.NetApi.Model.Types.Primitive.U8();
            StateVersion.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}