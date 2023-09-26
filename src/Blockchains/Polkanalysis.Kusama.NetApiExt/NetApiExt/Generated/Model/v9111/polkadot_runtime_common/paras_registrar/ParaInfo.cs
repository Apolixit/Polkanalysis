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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.paras_registrar;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.polkadot_runtime_common.paras_registrar
{
    /// <summary>
    /// >> 20344 - Composite[polkadot_runtime_common.paras_registrar.ParaInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ParaInfo : ParaInfoBase
    {
        public override System.String TypeName()
        {
            return "ParaInfo";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Manager.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Locked.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Manager = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_core.crypto.AccountId32();
            Manager.Decode(byteArray, ref p);
            Deposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            Locked = new Substrate.NetApi.Model.Types.Primitive.Bool();
            Locked.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}