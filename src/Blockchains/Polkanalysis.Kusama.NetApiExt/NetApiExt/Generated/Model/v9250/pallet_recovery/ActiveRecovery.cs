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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.pallet_recovery
{
    /// <summary>
    /// >> 11378 - Composite[pallet_recovery.ActiveRecovery]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ActiveRecovery : ActiveRecoveryBase
    {
        public override System.String TypeName()
        {
            return "ActiveRecovery";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Created.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Friends.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Created = new Substrate.NetApi.Model.Types.Primitive.U32();
            Created.Decode(byteArray, ref p);
            Deposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            Friends = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.sp_core.crypto.AccountId32>();
            Friends.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}