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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.frame_system.limits;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.frame_system.limits
{
    /// <summary>
    /// >> 18405 - Composite[frame_system.limits.BlockLength]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BlockLength : BlockLengthBase
    {
        public override System.String TypeName()
        {
            return "BlockLength";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Max1.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Max1 = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.frame_support.weights.PerDispatchClassT3();
            Max1.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}