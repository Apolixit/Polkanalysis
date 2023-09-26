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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_treasury;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.pallet_treasury
{
    /// <summary>
    /// >> 7191 - Composite[pallet_treasury.Proposal]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Proposal : ProposalBase
    {
        public override System.String TypeName()
        {
            return "Proposal";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Proposer.Encode());
            result.AddRange(Value.Encode());
            result.AddRange(Beneficiary.Encode());
            result.AddRange(Bond.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Proposer = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.sp_core.crypto.AccountId32();
            Proposer.Decode(byteArray, ref p);
            Value = new Substrate.NetApi.Model.Types.Primitive.U128();
            Value.Decode(byteArray, ref p);
            Beneficiary = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.sp_core.crypto.AccountId32();
            Beneficiary.Decode(byteArray, ref p);
            Bond = new Substrate.NetApi.Model.Types.Primitive.U128();
            Bond.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}