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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.paras;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.polkadot_runtime_parachains.paras
{
    /// <summary>
    /// >> 5187 - Composite[polkadot_runtime_parachains.paras.ParaPastCodeMeta]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ParaPastCodeMeta : ParaPastCodeMetaBase
    {
        public override System.String TypeName()
        {
            return "ParaPastCodeMeta";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(UpgradeTimes.Encode());
            result.AddRange(LastPruned.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            UpgradeTimes = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.polkadot_runtime_parachains.paras.ReplacementTimes>();
            UpgradeTimes.Decode(byteArray, ref p);
            LastPruned = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
            LastPruned.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}