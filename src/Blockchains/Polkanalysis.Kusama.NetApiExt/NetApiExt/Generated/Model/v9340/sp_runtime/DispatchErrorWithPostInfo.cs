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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_runtime;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.sp_runtime
{
    /// <summary>
    /// >> 5613 - Composite[sp_runtime.DispatchErrorWithPostInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class DispatchErrorWithPostInfo : DispatchErrorWithPostInfoBase
    {
        public override System.String TypeName()
        {
            return "DispatchErrorWithPostInfo";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(PostInfo.Encode());
            result.AddRange(Error.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            PostInfo = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.frame_support.dispatch.PostDispatchInfo();
            PostInfo.Decode(byteArray, ref p);
            Error = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.sp_runtime.EnumDispatchError();
            Error.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}