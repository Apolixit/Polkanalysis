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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.polkadot_runtime
{
    /// <summary>
    /// >> 12416 - Composite[polkadot_runtime.Runtime]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Runtime : RuntimeBase
    {
        public override System.String TypeName()
        {
            return "Runtime";
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