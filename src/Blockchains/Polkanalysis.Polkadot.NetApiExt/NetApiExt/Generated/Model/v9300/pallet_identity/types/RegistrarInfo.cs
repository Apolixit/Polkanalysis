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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.pallet_identity.types
{
    /// <summary>
    /// >> 11515 - Composite[pallet_identity.types.RegistrarInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class RegistrarInfo : RegistrarInfoBase
    {
        public override System.String TypeName()
        {
            return "RegistrarInfo";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Account.Encode());
            result.AddRange(Fee.Encode());
            result.AddRange(Fields.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Account = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.sp_core.crypto.AccountId32();
            Account.Decode(byteArray, ref p);
            Fee = new Substrate.NetApi.Model.Types.Primitive.U128();
            Fee.Decode(byteArray, ref p);
            Fields = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.pallet_identity.types.BitFlags();
            Fields.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}