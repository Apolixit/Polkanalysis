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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_multisig;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.pallet_multisig
{
    /// <summary>
    /// >> 9065 - Composite[pallet_multisig.Multisig]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Multisig : MultisigBase
    {
        public override System.String TypeName()
        {
            return "Multisig";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(When.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Depositor.Encode());
            result.AddRange(Approvals.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            When = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.pallet_multisig.Timepoint();
            When.Decode(byteArray, ref p);
            Deposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            Depositor = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.sp_core.crypto.AccountId32();
            Depositor.Decode(byteArray, ref p);
            Approvals = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.sp_core.crypto.AccountId32>();
            Approvals.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}