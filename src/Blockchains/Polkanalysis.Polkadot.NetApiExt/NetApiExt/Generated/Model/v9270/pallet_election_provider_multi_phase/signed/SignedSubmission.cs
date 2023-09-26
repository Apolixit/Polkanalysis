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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_election_provider_multi_phase.signed;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.pallet_election_provider_multi_phase.signed
{
    /// <summary>
    /// >> 8652 - Composite[pallet_election_provider_multi_phase.signed.SignedSubmission]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SignedSubmission : SignedSubmissionBase
    {
        public override System.String TypeName()
        {
            return "SignedSubmission";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Who.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(RawSolution.Encode());
            result.AddRange(CallFee.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Who = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.sp_core.crypto.AccountId32();
            Who.Decode(byteArray, ref p);
            Deposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            RawSolution = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.pallet_election_provider_multi_phase.RawSolution();
            RawSolution.Decode(byteArray, ref p);
            CallFee = new Substrate.NetApi.Model.Types.Primitive.U128();
            CallFee.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}