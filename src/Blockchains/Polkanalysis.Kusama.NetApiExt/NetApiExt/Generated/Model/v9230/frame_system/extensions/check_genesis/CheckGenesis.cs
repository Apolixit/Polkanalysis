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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.frame_system.extensions.check_genesis;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.frame_system.extensions.check_genesis
{
    /// <summary>
    /// >> 12321 - Composite[frame_system.extensions.check_genesis.CheckGenesis]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CheckGenesis : CheckGenesisBase
    {
        public override System.String TypeName()
        {
            return "CheckGenesis";
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