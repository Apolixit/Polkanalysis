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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.crowdloan;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_runtime_common.crowdloan
{
    /// <summary>
    /// >> 11650 - Composite[polkadot_runtime_common.crowdloan.FundInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class FundInfo : FundInfoBase
    {
        public override System.String TypeName()
        {
            return "FundInfo";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Depositor.Encode());
            result.AddRange(Verifier.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Raised.Encode());
            result.AddRange(End.Encode());
            result.AddRange(Cap.Encode());
            result.AddRange(LastContribution.Encode());
            result.AddRange(FirstPeriod.Encode());
            result.AddRange(LastPeriod.Encode());
            result.AddRange(FundIndex.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Depositor = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.sp_core.crypto.AccountId32();
            Depositor.Decode(byteArray, ref p);
            Verifier = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.sp_runtime.EnumMultiSigner>();
            Verifier.Decode(byteArray, ref p);
            Deposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            Raised = new Substrate.NetApi.Model.Types.Primitive.U128();
            Raised.Decode(byteArray, ref p);
            End = new Substrate.NetApi.Model.Types.Primitive.U32();
            End.Decode(byteArray, ref p);
            Cap = new Substrate.NetApi.Model.Types.Primitive.U128();
            Cap.Decode(byteArray, ref p);
            LastContribution = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_runtime_common.crowdloan.EnumLastContribution();
            LastContribution.Decode(byteArray, ref p);
            FirstPeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            FirstPeriod.Decode(byteArray, ref p);
            LastPeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            LastPeriod.Decode(byteArray, ref p);
            FundIndex = new Substrate.NetApi.Model.Types.Primitive.U32();
            FundIndex.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}