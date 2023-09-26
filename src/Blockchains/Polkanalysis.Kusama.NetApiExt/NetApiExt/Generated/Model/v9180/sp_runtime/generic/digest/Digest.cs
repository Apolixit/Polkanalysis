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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_runtime.generic.digest;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.sp_runtime.generic.digest
{
    /// <summary>
    /// >> 14612 - Composite[sp_runtime.generic.digest.Digest]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Digest : DigestBase
    {
        public override System.String TypeName()
        {
            return "Digest";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Logs.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Logs = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.sp_runtime.generic.digest.EnumDigestItem>();
            Logs.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}