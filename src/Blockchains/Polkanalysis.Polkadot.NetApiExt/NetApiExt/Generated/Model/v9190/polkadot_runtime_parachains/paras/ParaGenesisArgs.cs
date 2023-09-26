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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_runtime_parachains.paras
{
    /// <summary>
    /// >> 4498 - Composite[polkadot_runtime_parachains.paras.ParaGenesisArgs]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ParaGenesisArgs : ParaGenesisArgsBase
    {
        public override System.String TypeName()
        {
            return "ParaGenesisArgs";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(GenesisHead.Encode());
            result.AddRange(ValidationCode.Encode());
            result.AddRange(Parachain.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            GenesisHead = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_parachain.primitives.HeadData();
            GenesisHead.Decode(byteArray, ref p);
            ValidationCode = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_parachain.primitives.ValidationCode();
            ValidationCode.Decode(byteArray, ref p);
            Parachain = new Substrate.NetApi.Model.Types.Primitive.Bool();
            Parachain.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}