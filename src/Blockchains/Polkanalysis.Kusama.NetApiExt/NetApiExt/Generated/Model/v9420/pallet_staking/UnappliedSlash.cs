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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_staking;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_staking
{
    /// <summary>
    /// >> 1433 - Composite[pallet_staking.UnappliedSlash]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class UnappliedSlash : UnappliedSlashBase
    {
        public override System.String TypeName()
        {
            return "UnappliedSlash";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Validator.Encode());
            result.AddRange(Own.Encode());
            result.AddRange(Others.Encode());
            result.AddRange(Reporters.Encode());
            result.AddRange(Payout.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Validator = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32();
            Validator.Decode(byteArray, ref p);
            Own = new Substrate.NetApi.Model.Types.Primitive.U128();
            Own.Decode(byteArray, ref p);
            Others = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>();
            Others.Decode(byteArray, ref p);
            Reporters = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32>();
            Reporters.Decode(byteArray, ref p);
            Payout = new Substrate.NetApi.Model.Types.Primitive.U128();
            Payout.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}