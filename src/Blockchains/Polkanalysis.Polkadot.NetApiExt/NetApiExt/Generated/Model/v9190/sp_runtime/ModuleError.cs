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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_runtime;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.sp_runtime
{
    /// <summary>
    /// >> 3884 - Composite[sp_runtime.ModuleError]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ModuleError : ModuleErrorBase
    {
        public override System.String TypeName()
        {
            return "ModuleError";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Index.Encode());
            result.AddRange(Error1.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Index = new Substrate.NetApi.Model.Types.Primitive.U8();
            Index.Decode(byteArray, ref p);
            Error1 = new Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr4U8();
            Error1.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}