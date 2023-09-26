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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_tips;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.pallet_tips
{
    /// <summary>
    /// >> 7234 - Composite[pallet_tips.OpenTip]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class OpenTip : OpenTipBase
    {
        public override System.String TypeName()
        {
            return "OpenTip";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Reason.Encode());
            result.AddRange(Who.Encode());
            result.AddRange(Finder.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Closes.Encode());
            result.AddRange(Tips.Encode());
            result.AddRange(FindersFee.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Reason = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.primitive_types.H256();
            Reason.Decode(byteArray, ref p);
            Who = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.sp_core.crypto.AccountId32();
            Who.Decode(byteArray, ref p);
            Finder = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.sp_core.crypto.AccountId32();
            Finder.Decode(byteArray, ref p);
            Deposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            Closes = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
            Closes.Decode(byteArray, ref p);
            Tips = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>();
            Tips.Decode(byteArray, ref p);
            FindersFee = new Substrate.NetApi.Model.Types.Primitive.Bool();
            FindersFee.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}