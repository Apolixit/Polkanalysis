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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.frame_system;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.frame_system
{
    /// <summary>
    /// >> 19820 - Composite[frame_system.LastRuntimeUpgradeInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class LastRuntimeUpgradeInfo : LastRuntimeUpgradeInfoBase
    {
        public override System.String TypeName()
        {
            return "LastRuntimeUpgradeInfo";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(SpecVersion.Encode());
            result.AddRange(SpecName.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            SpecVersion = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>();
            SpecVersion.Decode(byteArray, ref p);
            SpecName = new Substrate.NetApi.Model.Types.Primitive.Str();
            SpecName.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}