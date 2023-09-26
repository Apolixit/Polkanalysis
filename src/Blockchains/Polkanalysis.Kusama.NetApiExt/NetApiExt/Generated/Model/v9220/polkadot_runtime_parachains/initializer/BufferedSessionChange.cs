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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.initializer;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_runtime_parachains.initializer
{
    /// <summary>
    /// >> 13049 - Composite[polkadot_runtime_parachains.initializer.BufferedSessionChange]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BufferedSessionChange : BufferedSessionChangeBase
    {
        public override System.String TypeName()
        {
            return "BufferedSessionChange";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Validators.Encode());
            result.AddRange(Queued.Encode());
            result.AddRange(SessionIndex.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Validators = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_primitives.v2.validator_app.Public>();
            Validators.Decode(byteArray, ref p);
            Queued = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_primitives.v2.validator_app.Public>();
            Queued.Decode(byteArray, ref p);
            SessionIndex = new Substrate.NetApi.Model.Types.Primitive.U32();
            SessionIndex.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}