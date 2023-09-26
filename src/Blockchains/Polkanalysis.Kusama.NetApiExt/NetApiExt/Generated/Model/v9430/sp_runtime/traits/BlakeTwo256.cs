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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_runtime.traits;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_runtime.traits
{
    /// <summary>
    /// >> 70 - Composite[sp_runtime.traits.BlakeTwo256]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BlakeTwo256 : BlakeTwo256Base
    {
        public override System.String TypeName()
        {
            return "BlakeTwo256";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}