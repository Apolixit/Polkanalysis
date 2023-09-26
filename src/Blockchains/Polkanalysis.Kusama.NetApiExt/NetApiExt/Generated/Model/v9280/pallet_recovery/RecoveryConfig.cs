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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_recovery;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.pallet_recovery
{
    /// <summary>
    /// >> 9043 - Composite[pallet_recovery.RecoveryConfig]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class RecoveryConfig : RecoveryConfigBase
    {
        public override System.String TypeName()
        {
            return "RecoveryConfig";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(DelayPeriod.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Friends.Encode());
            result.AddRange(Threshold.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            DelayPeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            DelayPeriod.Decode(byteArray, ref p);
            Deposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            Friends = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.sp_core.crypto.AccountId32>();
            Friends.Decode(byteArray, ref p);
            Threshold = new Substrate.NetApi.Model.Types.Primitive.U16();
            Threshold.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}